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
                var evaluateEmail = (await prod
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
                    await prod
                        .Child("RegUser")
                        .PostAsync(user);
                   prod.Dispose();
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
                var evaluateEmail = (await prod
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
        //public async Task<string> Getuserlist(string mail)
        //{
        //    try
        //    {
        //        var getuserlist = (await food
        //            .Child("RegUser")
        //            .OnceAsync<RegUser>()).
        //            FirstOrDefault(a => a.Object.Email == mail);
        //        if (getuserlist == null) return null;

        //        FirstName = getuserlist.Object.FirstName;
        //        LastName = getuserlist.Object.LastName;
        //        Email = getuserlist.Object.Email;
        //        return getuserlist?.Key;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //} 


        //Update
        public async Task<bool> Editdata(string lname, string fname)
        {
            try
            {
                var evaluteuser = (await prod
                    .Child("RegUser")
                    .OnceAsync<RegUser>())
                    .FirstOrDefault
                    (a => a.Object.Email == mail);
                if (evaluteuser != null)
                {
                    RegUser user = new RegUser
                    {
                        Email = Email,
                        FirstName = fname,
                        LastName = lname,
                        Password = Password,
                    };
                    await prod.Child("RegUser").Child(key).PatchAsync(user);
                    prod.Dispose();
                }
                prod.Dispose();
                return false;
            }
            catch (Exception)
            {
                prod.Dispose();
                return false;
            }
        }
        public async Task<string> Deletedata()
        {
            try
            {
                await prod
                    .Child($"RegUser/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception)
            {
                return " error";
            }
        }




        public ObservableCollection<RegUser> GetUserList()
        {
            var userlist = prod
                 .Child("RegUser")
                .AsObservable<RegUser>()
                .AsObservableCollection();
            return userlist;

        }

        public async Task<string> GetUserKey(string week)
        {
            try
            {
                var getuserkey = (await prod.Child("RegUser").OnceAsync<RegUser>()).
                    FirstOrDefault(a => a.Object.Email == mail);
                if (getuserkey == null) return null;

                Firstname = getuserkey.Object.FirstName;
                Lastname = getuserkey.Object.LastName;
                Email = getuserkey.Object.Email;

                return getuserkey?.Key;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
