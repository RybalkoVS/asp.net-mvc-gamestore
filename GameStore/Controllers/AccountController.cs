using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GameStore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.Login != null && model.Password != null && model.RepeatPassword != null)
                {
                    if (model.Password != model.RepeatPassword)
                    {
                        ModelState.AddModelError("", "Пароли не совпадают!");
                    }
                    else
                    {
                        User user = null;
                        using (UserContext db = new UserContext())
                        {
                            user = db.Users.FirstOrDefault(u => u.Login == model.Login);
                        }
                        if (user == null)
                        {
                            using (UserContext db = new UserContext())
                            {
                                db.Users.Add(new User { Login = model.Login, Password = model.Password, RoleId = 2 });
                                db.SaveChanges();
                                user = db.Users.Where(u => u.Login == model.Login && u.Password == model.Password).FirstOrDefault();
                            }
                            if (user != null)
                            {
                                FormsAuthentication.SetAuthCookie(model.Login, true);
                                return RedirectToAction("Storepage", "Home", new { search = " "});
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Данный логин уже занят!");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Заполните все поля!");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Login != null && model.Password != null)
                {
                    User user = null;
                    using (UserContext db = new UserContext())
                    {
                        user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Storepage", "Home", new { search = " "});
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неверный логин или пароль!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Заполните все поля!");
                }
            }
            return View(model);
        }
    }
}