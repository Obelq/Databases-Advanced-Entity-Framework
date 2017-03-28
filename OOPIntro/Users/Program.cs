using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new UsersContext();
            //context.Database.Initialize(true);
            //GetUserByEmailProvider(context);
            RemoveInactiveUsers(context);


        }

        private static void RemoveInactiveUsers(UsersContext context)
        {
            var date = DateTime.Parse(Console.ReadLine());
            var usersToDelete = context.Users.Where(u => u.LastTimeLoggedIn < date).ToArray();
            foreach (var u in usersToDelete)
            {
                u.IsDeleted = true;
            }
            var counter = usersToDelete.Length;
            context.SaveChanges();
            var usersDeleted = context.Users.Where(u => u.IsDeleted == true).ToArray();
            foreach (var user in usersDeleted)
            {
                context.Users.Remove(user);
            }
            context.SaveChanges();
            if (counter == 0)
            {
                Console.WriteLine("No users have been deleted");
            }
            else
            {
                Console.WriteLine($"{counter} users have been deleted");
            }
        }

        private static void GetUserByEmailProvider(UsersContext context)
        {
            var input = Console.ReadLine();
            var users = context.Users.Where(u => u.Email.Contains(input)).ToArray();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Username} {user.Email}");
            }
        }
    }
}
