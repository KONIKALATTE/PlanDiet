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
    public class RegUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public async Task<bool> AddUser(string fname, string lname, string mail, string Pass)
        {
            try
            {
                var evaluateEmail = (await food
                    .Child("RegUser")
                    .OnceAsync<RegUser>()).FirstOrDefault
                    (a => a.Object.Email == mail);
                if (evaluateEmail == null)
                {
                    var R_users = new RegUser()
                    {

                        FirstName = fname,
                        LastName = lname,
                        Email = mail,
                        Password = Pass
                    };
                    await food
                        .Child("Users")
                        .PostAsync(R_users);
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
        public async Task<bool> UserLogin(string mail, string Pass)
        {
            try
            {
                var evaluateEmail = (await food
                    .Child("RegUser")
                    .OnceAsync<RegUser>()).FirstOrDefault
                    (a => a.Object.Email == mail && a.Object.Password == Pass);
                return evaluateEmail! == null;
            }
            catch
            {
                return false;
            }
        }
        public ObservableCollection<Users> GetUserlist()
        {
            var userlist = food.Child("Users")
                .AsObservable<RegUser>()
                .AsObservableCollection();
            return userlist;
        }

    }
}
