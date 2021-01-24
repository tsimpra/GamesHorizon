using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public static class UserProcessor
    {
        public static int UpdateUser(string fname,string lname,int age,string id)
        {
            GameUserModel user = new GameUserModel
            {
                Fname = fname,
                Lname = lname,
                Age = age
            };
            string sql = @"update dbo.GameUsers set fname = @Fname, lname = @Lname, Age = @Age where UserId ='"+id+"';";
            return SqlDataAccess.UpdateUser(sql, user);
        }

        public static int UpdateUserBalance(float balance,string id) 
        {
            GameUserModel user = new GameUserModel
            {
                Balance = balance
            };
            string sql = @"update dbo.GameUsers set Balance += @Balance where UserId ='"+id+ "';";
            return SqlDataAccess.UpdateUser(sql, user);
        }

        public static GameUserModel LoadUser(string id)
        {
            string sql = @"select fname,lname,Age,Balance from dbo.GameUsers where UserId = '"+id+ "';";
            return SqlDataAccess.LoadUser<GameUserModel>(sql);
        }

        public static bool CheckBalance(string id)
        {
            string sql = @"select Balance from dbo.GameUsers where UserId = '" + id + "';";
            GameUserModel user = SqlDataAccess.LoadSingleData<GameUserModel>(sql);
            if(user.Balance>=10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
