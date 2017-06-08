using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- start ----");
            var userDal = new DataAccess.UserDal();
            userDal.Delete();

            var user1 = new Models.User { Name = "清水", Age = 26 };
            var user2 = new Models.User { Name = "桂", Age = 29 };

            userDal.Insert(user1);
            userDal.Insert(user2);

            var users = userDal.GetAll();
            disp(users);


            Console.WriteLine("---- end ----");
            Console.ReadLine();
        }

        static void disp(IEnumerable<Models.User> users)
        {
            foreach (var user in users.ToList())
            {
                Console.WriteLine(string.Format("{0}, {1}, {2}", user.Id, user.Name, user.Age));
            }
        }
    }
}
