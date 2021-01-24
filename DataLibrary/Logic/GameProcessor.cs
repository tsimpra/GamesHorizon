using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public static  class GameProcessor
    {
        public static int CreateGame(string name, string createdBy, string year, string console, string ownerID)
        {
            GameModel data = new GameModel
            {
                Name = name,
                CreatedBy = createdBy,
                Year = year,
                Console = console,
                OwnerId = ownerID
            };

            string sql = @"INSERT INTO dbo.Games(Name,CreatedBy,Year,Console,OwnerId) values(@Name,@CreatedBy,@Year,@Console,@OwnerId);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<GameModel> LoadGames(String search)
        {           
            if (search == null)
            {
                string sql = @"select Id,Name,CreatedBy,Year,Console from dbo.Games;";
                return SqlDataAccess.LoadData<GameModel>(sql);
            }
            else
            {
                string sql = @"select Id,Name,CreatedBy,Year,Console from dbo.Games " +
                    "where Name like '%"+search+ "%' OR " +
                    "CreatedBy like '%" + search + "%' OR "+
                    "Year like '%" + search + "%' OR " +
                    "Console like '%" + search + "%'; ";
                return SqlDataAccess.LoadData<GameModel>(sql);
            }
            
        }

        public static GameModel LoadGame(string id)
        {
            string sql = @"select * from dbo.Games where Id ='"+id+"';";
            return SqlDataAccess.LoadSingleData<GameModel>(sql);
        }

        public static int BuyGame(int id)
        {
            GameModel data = new GameModel
            {
                Id=id,                            
            };
            string sql = @"delete from dbo.Games where Id = @Id ;";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<GameModel> GetGamesOnSale(string id)
        {
            string sql = @"select Name,CreatedBy,Year,Console from dbo.Games where OwnerId ='" + id + "';";
            return SqlDataAccess.LoadData<GameModel>(sql);
        }

        //public static string GetOwnerId(int id)
        //{
        //    string sql = @"Select OwnerId from dbo.Games where Id ='" + id + "';";
        //    GameModel game = SqlDataAccess.LoadSingleData<GameModel>(sql);
        //    return game.OwnerId;
        //}
    }
}
