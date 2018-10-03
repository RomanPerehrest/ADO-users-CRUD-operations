using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyAdo.Net
{
    public class UserDbService
    {
        private string connectionString =
            "Data Source=DESKTOP-SRPRSKU;Initial Catalog=TestDb;Integrated Security=SSPI";

        public User GetUser(Guid userId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sqlSelectUsers = $"SELECT * FROM dbo.USERS WHERE Id = '{userId}'";
                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = sqlSelectUsers;

                var sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                return this.ReadUser(sqlDataReader);
            }
        }

        public IEnumerable<User> IGetUsers()
        {
            var users = new List<User>();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sqlSelectUsers = $"SELECT * FROM dbo.USERS";
                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = sqlSelectUsers;

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    users.Add(this.ReadUser(sqlDataReader));
                }
            }

            return users;
        }







        public SqlDataAdapter GetAdapter(SqlConnection sqlConnection)
        {
            return new SqlDataAdapter("SELECT * FROM dbo.Users", sqlConnection);
        }

        public DataTable GetUsersDataTable(SqlDataAdapter adapter)
        {
            var usersDataSet = new DataSet();
            adapter.Fill(usersDataSet);
            return usersDataSet.Tables[0];
        }


        public void AddUser(User user)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sqlInsertUser =
                    $"INSERT INTO dbo.Users VALUES('{user.Id}', '{user.FirstName}', '{user.LastName}', '{user.Email}')";

                var sqlCommand = new SqlCommand(sqlInsertUser, sqlConnection);
                


                var adapter = GetAdapter(sqlConnection);
                var usersTable = GetUsersDataTable(adapter);
                var newUser = usersTable.NewRow();
                newUser["Id"] = user.Id;
                newUser["FirstName"] = user.FirstName;
                newUser["LastName"] = user.LastName;
                newUser["Email"] = user.Email;

                usersTable.Rows.Add(newUser);

                var commandBuilder = new SqlCommandBuilder(adapter);
                sqlCommand.ExecuteNonQuery();
               //adapter.Update(usersTable);
               
            }
        }



        public void UpdateUser(User user)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();   
                var sqlInsertUser =
                    $"UPDATE dbo.Users SET FirstName = '{user.FirstName}', LastName = '{user.LastName}', Email = '{user.Email}'"
                    + $" WHERE Id = '{user.Id}'";

                var sqlCommand = new SqlCommand(sqlInsertUser, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteUser(Guid userId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sqlInsertUser =
                    $"DELETE FROM dbo.Users WHERE Id = '{userId}'";

                var sqlCommand = new SqlCommand(sqlInsertUser, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }
         
        private User ReadUser(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetGuidSafe("Id"),
                FirstName = reader.GetStringSafe("FirstName"),
                LastName = reader.GetStringSafe("LastName"),
                Email = reader.GetStringSafe("Email")
            };
        }
    }
}
