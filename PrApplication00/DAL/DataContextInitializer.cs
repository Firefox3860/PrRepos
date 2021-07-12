using PrApplication00.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrApplication00.DAL
{
    public class DataContextInitializer
    {
        public static void Initialize(DataContext context)
        {
            //var context = new DataContext();
            if (!context.Users.Any())
            {
                var user = new User();
                user.Name = "sys";
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
