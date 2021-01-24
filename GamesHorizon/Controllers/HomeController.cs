using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesHorizon.Models;
using DataLibrary;
using DataLibrary.Logic;
using Microsoft.AspNet.Identity;
using System.Web.Services.Protocols;
using Microsoft.Ajax.Utilities;

namespace GamesHorizon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult BrowseGames()
        //{
        //    ViewBag.Message = "Games List";

        //    var data = GameProcessor.LoadGames();

        //    List<Game> games = new List<Game>();

        //    foreach (var row in data)
        //    {
        //        games.Add(new Game
        //        {
        //            Id = row.Id,
        //            Name = row.Name,
        //            CreatedBy = row.CreatedBy,
        //            Year = row.Year,
        //            GameConsole = row.Console
        //        }); ;
        //    }
        //    return View(games);
        //}

        public ActionResult BrowseGames(string search)
        {
            ViewBag.Message = "Games List";


            var data = GameProcessor.LoadGames(search);

            List<Game> games = new List<Game>();

            foreach (var row in data)
            {
                games.Add(new Game
                {
                    Id = row.Id,
                    Name = row.Name,
                    CreatedBy = row.CreatedBy,
                    Year = row.Year,
                    GameConsole = row.Console
                }); ;
            }
            return View(games);
        }

        [Authorize]
        public ActionResult Account()
        {
            var data = UserProcessor.LoadUser(User.Identity.GetUserId());
            GameUser user = new GameUser
            {
                FirstName = data.Fname,
                LastName = data.Lname,
                Age = data.Age,
                Balance = data.Balance
            };

            user.GamesBought = PurchaseProcessor.GetGamesBought(User.Identity.GetUserId());
            user.GamesSold = PurchaseProcessor.GetGamesSold(User.Identity.GetUserId());
            var list = GameProcessor.GetGamesOnSale(User.Identity.GetUserId());
            user.GamesOnSale = new List<Game>();
            foreach (var row in list)
            {
                user.GamesOnSale.Add(new Game
                {
                    Name = row.Name,
                    CreatedBy = row.CreatedBy,
                    Year = row.Year,
                    GameConsole = row.Console
                });
            }
            return View(user);
        }

        public ActionResult UpdateUserDetail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserDetail(GameUser user)
        {
            if (ModelState.IsValid)
            {
                int recs = UserProcessor.UpdateUser(user.FirstName, user.LastName, user.Age, User.Identity.GetUserId());
                return RedirectToAction("Account");
            }
            return View();
        }

        public ActionResult UpdateBalance()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBalance(GameUser user)
        {
            int recs = UserProcessor.UpdateUserBalance(user.Balance, User.Identity.GetUserId());
            return RedirectToAction("Account");
        }

        [Authorize]
        public ActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGame(Game game)
        {
            if (ModelState.IsValid)
            {
                int recs = GameProcessor.CreateGame(game.Name, game.CreatedBy, game.Year, game.GameConsole,
                    User.Identity.GetUserId());
                return RedirectToAction("BrowseGames");
            }
            return View();
        }

        [Authorize]
        public ActionResult BuyGame(int id)
        {
            var data = GameProcessor.LoadGame(id.ToString());
            Game game = new Game
            {
                Id = data.Id,
                Name = data.Name,
                CreatedBy = data.CreatedBy,
                Year = data.Year,
                GameConsole = data.Console               
            };
            return View(game);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuyGame(Game game)
        {
            if (UserProcessor.CheckBalance(User.Identity.GetUserId()))
            {
                var data = GameProcessor.LoadGame(game.Id.ToString());
                int rec = PurchaseProcessor.PurchaseGame(data.Name, data.OwnerId, User.Identity.GetUserId());
                int recs = GameProcessor.BuyGame(game.Id);
                return RedirectToAction("BrowseGames");
            }
            return RedirectToAction("UpdateBalance");
        }
    }

    
}
