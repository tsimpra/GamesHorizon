using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;



namespace DataLibrary.Logic
{
    public static class PurchaseProcessor
    {

        public static int PurchaseGame(string name, string owner, string buyer)
        {
            PurchaseModel pur = new PurchaseModel
            {
                Gname = name,
                Owner = owner,
                Buyer = buyer,
            };
            string sql = @"insert into dbo.Purchases(gname,sellerId,buyerId) values(@Gname,@Owner,@Buyer);";
            return SqlDataAccess.SaveData(sql, pur);
        }

        public static List<string> GetGamesBought(string id)
        {
            string sql = @"select gname from dbo.Purchases where buyerId = '" + id + "';";
            return SqlDataAccess.LoadData<string>(sql);
        }

        public static List<string> GetGamesSold(string id)
        {
            string sql = @"select gname from dbo.Purchases where sellerId = '" + id + "';";
            return SqlDataAccess.LoadData<string>(sql);
        }
    }
}
