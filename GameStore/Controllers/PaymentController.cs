using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Controllers
{
    public class PaymentController : Controller
    {
        GameContext gamesDb = new GameContext();
        UserContext usersDb = new UserContext();
        [HttpGet]
        public ActionResult Buy(int gameId, string userName)
        {
            ViewBag.User = usersDb.Users.FirstOrDefault(u => u.Login == userName);
            ViewBag.Game = gamesDb.Games.FirstOrDefault(g => g.Id == gameId);
            return View();
        }
        [HttpGet]
        public ActionResult YandexPay(int gameId, int userId)
        {
            ViewBag.User = usersDb.Users.FirstOrDefault(u => u.Id == userId);
            ViewBag.Game = gamesDb.Games.FirstOrDefault(g => g.Id == gameId);
            return View();
        }
        [HttpPost]
        public ActionResult YandexPay(Purchase model, int gameId, int userId)
        {
            gamesDb.Purchases.Add(new Purchase { Email = model.Email, Date = DateTime.Now, Total = gamesDb.Games.FirstOrDefault(g => g.Id == gameId).Price, UserId = userId, ProductName = gamesDb.Games.FirstOrDefault(g => g.Id == gameId).Name });
            gamesDb.SaveChanges();
            return RedirectToAction("CompletePayment", "Payment", new { userId });
        }
        [HttpGet]
        public ActionResult WebMoneyPay(int gameId, int userId)
        {
            ViewBag.User = usersDb.Users.FirstOrDefault(u => u.Id == userId);
            ViewBag.Game = gamesDb.Games.FirstOrDefault(g => g.Id == gameId);
            return View();
        }
        [HttpPost]
        public ActionResult WebMoneyPay(Purchase model, int gameId, int userId)
        {
            gamesDb.Purchases.Add(new Purchase { Email = model.Email, Date = DateTime.Now, Total = gamesDb.Games.FirstOrDefault(g => g.Id == gameId).Price, UserId = userId, ProductName = gamesDb.Games.FirstOrDefault(g => g.Id == gameId).Name });
            gamesDb.SaveChanges();
            return RedirectToAction("CompletePayment", "Payment", new { userId });
        }
        [HttpGet]
        public ActionResult BankPay(int gameId, int userId)
        {
            ViewBag.User = usersDb.Users.FirstOrDefault(u => u.Id == userId);
            ViewBag.Game = gamesDb.Games.FirstOrDefault(g => g.Id == gameId);
            return View();
        }
        [HttpPost]
        public ActionResult BankPay(Purchase model, int gameId, int userId)
        {
            gamesDb.Purchases.Add(new Purchase { Email = model.Email, Date = DateTime.Now, Total = gamesDb.Games.FirstOrDefault(g => g.Id == gameId).Price, UserId = userId, ProductName = gamesDb.Games.FirstOrDefault(g => g.Id == gameId).Name });
            gamesDb.SaveChanges();
            return RedirectToAction("CompletePayment", "Payment", new { userId });
        }
        public ActionResult CompletePayment(int userId)
        {
            ViewBag.User = usersDb.Users.FirstOrDefault(u => u.Id == userId);
            ViewBag.LicenseKey = LicenseKey();
            return View();
        }
        public string LicenseKey()
        {
            Random rnd = new Random();
            int n;
            string temp;
            string licenseKey = "";
            string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for (int i = 0; i < 16; i++)
            {
                n = rnd.Next(0, 61);
                temp = st.Substring(n, 1);
                licenseKey += temp;
            }
            return licenseKey;
        }
    }
}