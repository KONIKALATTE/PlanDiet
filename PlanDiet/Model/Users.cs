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
        public string ProductID { get; set; }
        public string Medicine { get; set; }
        public string BabyProduct { get; set; }
        public string SchoolSupply { get; set; }
        public string Grocery { get; set; }
        public string Message { get; set; }

        //ADD
        public async Task<bool> DietPlan(string prodid, string med, string bbyprod, string school, string grocery, string mssg)
        {
            try
            {
                var evaluateweek = (await prod
                    .Child("Users")
                    .OnceAsync<Users>()).FirstOrDefault
                    (a => a.Object.ProductID == prodid);
                if (evaluateweek == null)
                {
                    var users = new Users()
                    {
                        ProductID = prodid,
                        Medicine = med,
                        BabyProduct = bbyprod,
                        SchoolSupply = school,
                        Grocery = grocery,
                        Message = mssg
                    };
                    await prod
                        .Child("Users")
                        .PostAsync(users);
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
        //EDIT or UPDATE
        public async Task<bool> Editdata(string prodid, string med, string bbyprod, string school, string grocery, string mssg)
        {
            try
            {
                var evaluteuser = (await prod
                    .Child("Users")
                    .OnceAsync<Users>())
                    .FirstOrDefault
                    (a => a.Object.ProductID == prodid);
                if (evaluteuser != null)
                {
                    Users user = new Users
                    {
                        ProductID = prodid,
                        Medicine = med,
                        BabyProduct = bbyprod,
                        SchoolSupply = school,
                        Grocery = grocery,
                        Message = mssg
                    };
                    await prod.Child("Users").Child(key).PatchAsync(user);
                    prod.Dispose();
                }
                prod.Dispose();
                return false;
            }
            catch (Exception )
            {
                prod.Dispose();
                return false;
            }
        }

        //DELETE
        public async Task<string> Deletedata()
        {
            try
            {
                await prod
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
            var userlist = prod
                 .Child("Users")
                .AsObservable<Users>()
                .AsObservableCollection();
            return userlist;

        }

        public async Task<string> GetUserKey(string prodid)
        {
            try
            {
                var getuserkey = (await prod.Child("Users").OnceAsync<Users>()).
                    FirstOrDefault(a => a.Object.ProductID == prodid);
                if (getuserkey == null) return null;
                ProductID1 = getuserkey.Object.ProductID;
                Medicine1 = getuserkey.Object.Medicine;
                BabyProd1 = getuserkey.Object.BabyProduct;
                SchoolSupply1 = getuserkey.Object.SchoolSupply;
                Grocery1 = getuserkey.Object.Grocery;
                Message1 = getuserkey.Object.Message;

                return getuserkey?.Key;
            }
            catch (Exception)
            {
                return null;
            }

        }



    }
}