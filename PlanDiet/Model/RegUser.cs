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

        //ADD
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
                    var user = new RegUser()
                    {

                        FirstName = fname,
                        LastName = lname,
                        Email = mail,
                        Password = Pass
                    };
                    await food
                        .Child("RegUser")
                        .PostAsync(user);
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

        //LOGIN
        public async Task<bool> UserLogin(string mail, string Pass)
        {
            try
            {
                var evaluateEmail = (await food
                    .Child("RegUser")
                    .OnceAsync<RegUser>())
                    .FirstOrDefault
                    (a => a.Object.Email == mail && a.Object.Password == Pass);
                return evaluateEmail! == null;
            }
            catch
            {
                return false;
            }
        }
        // GETUSER or REtrieve
        public async Task<string> Getuserlist(string mail)
        {
            try
            {
                var getuserlist = (await food
                    .Child("RegUser")
                    .OnceAsync<RegUser>()).
                    FirstOrDefault(a => a.Object.Email == mail);
                if (getuserlist == null) return null;

                FirstName = getuserlist.Object.FirstName;
                LastName = getuserlist.Object.LastName;
                Password = getuserlist.Object.Password;
                return getuserlist?.Key;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        //Update
        public async Task<bool> editdata(string lname, string fname)
        {
            try
            {
                var evaluteuser = (await food
                    .Child("RegUsers")
                    .OnceAsync<RegUser>())
                    .FirstOrDefault
                    (a => a.Object.Email == mail);
                if (evaluteuser != null)
                {
                    RegUser user = new RegUser
                    {
                        FirstName = fname,
                        LastName = lname
                    };
                    await food.Child("RegUser").Child(key).PatchAsync(user);
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
        public async Task<string> Deletedata()
        {
            try
            {
                await food
                    .Child($"RegUser/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception ex)
            {
                return " error";
            }
        }




        public ObservableCollection<RegUser> GetUserList()
        {
            var userlist = food
                 .Child("RegUser")
                .AsObservable<RegUser>()
                .AsObservableCollection();
            return userlist;

        }

    }
}
