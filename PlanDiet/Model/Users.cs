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
        public string Day { get; set; }
        public string Week { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public string Message { get; set; }

        //ADD
        public async Task<bool> DietPlan(string day, string week, string bfast, string lunch, string dinner, string mssg)
        {
            try
            {
                var evaluateweek = (await food
                    .Child("Users")
                    .OnceAsync<Users>()).FirstOrDefault
                    (a => a.Object.Day == day);
                if (evaluateweek == null)
                {
                    var users = new Users()
                    {
                        Day = day,
                        Week = week,
                        Breakfast = bfast,
                        Lunch = lunch,
                        Dinner = dinner,
                        Message = mssg
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
        public async Task<bool> Editdata(string day, string week, string bfast, string lunch, string dinner, string mssg)
        {
            try
            {
                var evaluteuser = (await food
                    .Child("Users")
                    .OnceAsync<Users>())
                    .FirstOrDefault
                    (a => a.Object.Day == day);
                if (evaluteuser != null)
                {
                    Users user = new Users
                    {
                        Day = day,
                        Week = week,
                        Breakfast = bfast,
                        Lunch = lunch,
                        Dinner = dinner,
                        Message = mssg
                    };
                    await food.Child("Users").Child(key).PatchAsync(user);
                    food.Dispose();
                }
                food.Dispose();
                return false;
            }
            catch (Exception )
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
            catch (Exception)
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

        public async Task<string> GetUserKey(string day)
        {
            try
            {
                var getuserkey = (await food.Child("Users").OnceAsync<Users>()).
                    FirstOrDefault(a => a.Object.Day == day);
                if (getuserkey == null) return null;
                day1 = getuserkey.Object.Day;
                week1 = getuserkey.Object.Week;
                Breakfast1 = getuserkey.Object.Breakfast;
                Lunch1 = getuserkey.Object.Lunch;
                Dinner1 = getuserkey.Object.Dinner;

                return getuserkey?.Key;
            }
            catch (Exception)
            {
                return null;
            }

        }



    }
}