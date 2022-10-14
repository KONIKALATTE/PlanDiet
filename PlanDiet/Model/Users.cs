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

        //ADD
        public async Task<bool> DietPlan(string week, string bfast, string lunch, string dinner, string mssge)
        {
            try
            {
                var evaluateweek = (await food
                    .Child("Users")
                    .OnceAsync<Users>()).FirstOrDefault
                    (a => a.Object.Week == week);
                if (evaluateweek == null)
                {
                    var users = new Users()
                    {

                        Week = week,
                        Breakfast = bfast,
                        Lunch = lunch,
                        Dinner = dinner,
                        Message = mssge
                    };
                    await food
                        .Child("Users")
                        .PostAsync(users);
                    food.Dispose();
                    return true;

                }

                return false;
            }
            catch
            {

                return false;
            }


        }
        //EDIT or UPDATE
        public async Task<bool> Editdata(string week, string bfast, string lunch, string dinner)
        {
            try
            {
                var evaluteuser = (await food
                    .Child("Users")
                    .OnceAsync<Users>())
                    .FirstOrDefault
                    (a => a.Object.Week == week);
                if (evaluteuser != null)
                {
                    Users user = new Users
                    {
                        Week = week,
                        Breakfast = bfast,
                        Lunch = lunch,
                        Dinner = dinner
                    };
                    await food.Child("Users").Child(key).PatchAsync(user);
                    food.Dispose();
                }
                food.Dispose();
                return false;
            }
            catch (Exception ex)
            {
                food.Dispose();
                return false;
            }
        }

        //DELETE
        public async Task<string> Deletedata()
        {
            try
            {
                await food
                    .Child($"Users/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception ex)
            {
                return " error";
            }
        }




        public ObservableCollection<Users> GetUserList()
        {
            var userlist = food
                 .Child("Users")
                .AsObservable<Users>()
                .AsObservableCollection();
            return userlist;

        }

        public async Task<string> GetUserKey(string week)
        {
            try
            {
                var getuserkey = (await food.Child("Users").OnceAsync<Users>()).
                    FirstOrDefault(a => a.Object.Week == week);
                if (getuserkey == null) return null;

                Breakfast = getuserkey.Object.Breakfast;
                Lunch = getuserkey.Object.Lunch;
                Dinner = getuserkey.Object.Dinner;

                return getuserkey?.Key;
            }
            catch (Exception ex)
            {
                return null;
            }

        }



    }
}