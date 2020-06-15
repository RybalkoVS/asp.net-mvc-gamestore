using GameStore.Models;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using GameStore.Providers;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        GameContext gamesDb = new GameContext();
        UserContext usersDb = new UserContext();
        [Authorize]
        public ActionResult StorePage(string search)
        {
            if(search == " ")
            {
                search = "";
            }
            ViewBag.Search = search;
            ViewBag.Games = gamesDb.Games;
            ViewBag.Identity = User.Identity;
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Editor(string search)
        {
            if (search == " ")
            {
                search = "";
            }
            ViewBag.Search = search;
            ViewBag.Games = gamesDb.Games;
            ViewBag.Users = usersDb.Users;
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult AddGame()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGame(Game model)
        {
            Game game = null;
            game = gamesDb.Games.FirstOrDefault(g => g.Name == model.Name);
            if (game == null)
            {
                gamesDb.Games.Add(new Game { Name = model.Name, Price = model.Price, ReleaseYear = model.ReleaseYear, Image = model.Image });
                gamesDb.SaveChanges();
                return RedirectToAction("Editor", "Home", new { search = " "});
            }
            else if (game != null)
            {
                ModelState.AddModelError("", "Данная игра уже есть в магазине!");
            }
            return View(model);
        }
        public ActionResult RemoveGame(int gameId)
        {
            gamesDb.Games.Remove(gamesDb.Games.FirstOrDefault(g => g.Id == gameId));
            gamesDb.SaveChanges();
            return RedirectToAction("Editor", "Home", new { search = " "});
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult ChangeGame(int gameId)
        {
            ViewBag.Game = gamesDb.Games.FirstOrDefault(g => g.Id == gameId);
            return View();
        }
        [HttpPost]
        public ActionResult ChangeGame(Game model)
        {
            bool flag = true;
            foreach (var game in gamesDb.Games)
            {
                if (model.Name == game.Name && game.Id != model.Id)
                {
                    flag = false;
                }
            }
            if (flag == true)
            {
                gamesDb.Games.FirstOrDefault(g => g.Id == model.Id).Name = model.Name;
                gamesDb.Games.FirstOrDefault(g => g.Id == model.Id).Price = model.Price;
                gamesDb.Games.FirstOrDefault(g => g.Id == model.Id).ReleaseYear = model.ReleaseYear;
                gamesDb.Games.FirstOrDefault(g => g.Id == model.Id).Image = model.Image;
                gamesDb.SaveChanges();
                return RedirectToAction("Editor", "Home", new { search = " "});
            }
            else if (flag == false)
            {
                ModelState.AddModelError("", "Имя не может совпадать с уже существующим!");

            }
            ViewBag.Game = gamesDb.Games.FirstOrDefault(g => g.Id == model.Id);
            return View(model);
        }
    }
}