using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAdo.Net
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("What you want to do:");
                Console.WriteLine("1: Get all users");
                Console.WriteLine("2: Get a user");
                Console.WriteLine("3: Add a user");
                Console.WriteLine("4: Update a user");
                Console.WriteLine("5: Delete a user");
                Console.WriteLine("6: Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        GetAllUsers();
                        isExit = AskToExit();
                        break;
                    case "2":
                        GetUser();
                        isExit = AskToExit();
                        break;
                    case "3":
                        AddUser();
                        isExit = AskToExit();
                        break;
                    case "4":
                        UpdateUser();
                        isExit = AskToExit();
                        break;
                    case "5":
                        DeleteUser();
                        isExit = AskToExit();
                        break;
                    case "6":
                        isExit = true;
                        break;
                }
            }
        }

        public static bool AskToExit()
        {
            Console.WriteLine("Please enter y/Y if you want to exit");
            var res = Console.ReadLine();
            return res == "y" || res == "Y";
        }

        public static void GetAllUsers()
        {
            var userDbService = new UserDbService();
            var users = userDbService.IGetUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName} {user.Email}");
            }
        }

        public static void GetUser()
        {
            Console.WriteLine("Please enter userId: ");
            var userId = Console.ReadLine();
            var userDbService = new UserDbService();
            var user = userDbService.GetUser(Guid.Parse(userId));
            Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName} {user.Email}");
        }

        public static void AddUser()
        {
            var user = new User
            {
                Id = Guid.NewGuid()
            };
            Console.WriteLine("Enter UserName: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter LastName: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            user.Email = Console.ReadLine();

            var userDbService = new UserDbService();/////
            userDbService.AddUser(user);
        }

        public static void UpdateUser()
        {
            Console.WriteLine("Please enter userId you want to update: ");
            var userId = Console.ReadLine();

            var userDbService = new UserDbService();
            var user = userDbService.GetUser(Guid.Parse(userId));
            if (user == null)
            {
                Console.WriteLine("Current user does not exist");
            }

            Console.WriteLine("Enter UserName: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter LastName: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            user.Email = Console.ReadLine();

            userDbService.UpdateUser(user);
        }

        public static void DeleteUser()
        {
            Console.WriteLine("Please enter userId you want to update: ");
            var userId = Console.ReadLine();

            var userDbService = new UserDbService();
            var user = userDbService.GetUser(Guid.Parse(userId));
            if (user == null)
            {
                Console.WriteLine("Current user does not exist");
            }

            userDbService.DeleteUser(Guid.Parse(userId));
        }
    }
}
