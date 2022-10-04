using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlanDiet.App;
namespace PlanDiet.Model
{
    public class Users
    {
        public string Week { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public string Message { get; set; }
        public async Task<bool> DietPlan(string week, string bfast, string lunch, string dinner, string mssge)
        {
            try
            {
                var evaluateEmail = (await client
                    .Child("Users")
                    .OnceAsync<Users>()).FirstOrDefault
                    (a => a.Object.Week == week);
                if (evaluateEmail == null)
                {
                    var users = new Users()
                    {

                        Week = week,
                        Breakfast = bfast,
                        Lunch = lunch,
                        Dinner = dinner,
                        Message = mssge
                    };
                    await client
                        .Child("Users")
                        .PostAsync(users);
                    client.Dispose();
                    return true;

                }

                return false;
            }
            catch
            {

                return false;
            }

        }


    }
}


