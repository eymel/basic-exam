using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Entity;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        UserBusiness userBll = new UserBusiness();
        public ActionResult Index()
        {
            ViewBag.Error = "";
            return View(new LoginModel());

        }
        [HttpPost]
        public ActionResult Index(LoginModel user) {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
             User userresult=   userBll.Login(new User() { UserName=user.UserName , Password=user.Password});
                if (userresult!=null)
                {
                    Session["UserID"] = userresult.ID;
                    return RedirectToAction("Index", "Exam");
                }
                else
                {
                    ViewBag.Error = "Lütfen Kullanıcı Adı veya Şifrenizi doğru olduğuna emin olunuz"; 
                    return View("Index");

                }
            }
           




        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegisterModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            else
            {
                bool userresult = userBll.Create(new User() {FullName=user.FullName, UserName = user.UserName, Password = user.Password });
                if (userresult == true)
                {
                    ViewBag.Success = true;
                    ViewBag.Error = "Üye Kaydınız Yapıldı Lütfen Giriş Yapınız";
                    return View("Index");
                }
                else
                {
                    ViewBag.Error = "Kulllanıcı Kaydı Yapılamadı .Lütfen bilgileri doğru olduğuna emin olunuz";
                    return View("Create");

                }
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}