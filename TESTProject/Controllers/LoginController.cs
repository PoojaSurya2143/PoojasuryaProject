using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TESTEntity;
using TESTManager;

namespace TESTProject.Controllers
{
    public class LoginController : Controller
    {
        LoginModel LoginModel = new LoginModel();
        LoginManager loginManager = new LoginManager(); 
         // GET: Login
        public ActionResult LoginSave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginSave(LoginModel loginModel)
        {
            List<LoginModel> listOfUserDetails = new List<LoginModel>();
            //listOfUserDetails = Loginmanager.GetUserLogin(loginModel);
            listOfUserDetails = loginManager.GetUserLogin(loginModel);
            if (listOfUserDetails.Count > 0)
            {
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["successmsg"] = "UserId or Password is Incorrect.";
                return RedirectToAction("LoginSave", "Login");
            }
        }
    }
}