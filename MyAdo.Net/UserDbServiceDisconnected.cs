using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyAdo.Net
{
    public class UserDbServiceDisconnected
    {
        //private string connectionString =
        //    "Data Source=DESKTOP-SRPRSKU;Initial Catalog=TestDb;Integrated Security=SSPI";

        //public SqlDataAdapter GetAdapter(SqlConnection sqlConnection)
        //{
        //    return new SqlDataAdapter("SELECT * FROM dbo.Users", sqlConnection);
        //}

        //public DataTable GetUsersDataTable(SqlDataAdapter adapter)
        //{
        //    var usersDataSet = new DataSet();
        //    adapter.Fill(usersDataSet);
        //    return usersDataSet.Tables[0];
        //}

        //public void AddUser(User user)
        //{
        //    using (var sqlConnection = new SqlConnection(connectionString))
        //    {
        //        var adapter = GetAdapter(sqlConnection);
        //        var usersTable = GetUsersDataTable(adapter);
        //        var newUser = usersTable.NewRow();
        //        newUser["Id"] = user.Id;
        //        newUser["FirstName"] = user.FirstName;
        //        newUser["LastName"] = user.LastName;
        //        newUser["Email"] = user.Email;

        //        usersTable.Rows.Add(newUser);

        //        var commandBuilder = new SqlCommandBuilder(adapter);
        //        adapter.Update(usersTable);
        //    }
        //}







        //public IEnumerable<User> GetUsers()
        //{
        //    var users = new List<User>();
        //    using (var sqlConnection = new SqlConnection(connectionString))
        //    {
        //        var adapter = GetAdapter(sqlConnection);
        //        var usersTable = GetUsersDataTable(adapter);
        //        foreach (DataRow user in usersTable.Rows)
        //        {
        //            users.Add(new User
        //            {
        //                Id = Guid.Parse(user["Id"].ToString()),
        //                FirstName = user["FirstName"].ToString(),
        //                LastName = user["LastName"].ToString(),
        //                Email = user["Email"].ToString()
        //            });
        //        }
        //    }

        //    return users;
        //}

        //public User GetUser(Guid userId)
        //{
        //    using (var sqlConnection = new SqlConnection(connectionString))
        //    {
        //        var adapter = GetAdapter(sqlConnection);
        //        var usersTable = GetUsersDataTable(adapter);
        //        foreach (DataRow user in usersTable.Rows)
        //        {
        //            if (Guid.Parse(user["Id"].ToString()) == userId)
        //            {
        //                return new User
        //                {
        //                    Id = Guid.Parse(user["Id"].ToString()),
        //                    FirstName = user["FirstName"].ToString(),
        //                    LastName = user["LastName"].ToString(),
        //                    Email = user["Email"].ToString()
        //                };
        //            }
        //        }

        //        return null;
        //    }
        //}


    }
}
