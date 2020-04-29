using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any())
            {
               var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            //    var user = JsonConvert.DeserializedObject<List<User>>(userData);
            // 6. Seeding Data to the Database Part 2...
            }
        }
    }
}