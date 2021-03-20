using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TESTEntity;
using TESTManager;

namespace TESTProject.Controllers
{
    public class SignUpController : Controller
    {
        LoginManager loginManager = new LoginManager();
        SignUpModel loginModel = new SignUpModel();
        // GET: SignUp
        public ActionResult SignUpSave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUpSave(SignUpModel loginModel)
        {
            var result = loginManager.Save(loginModel);
            if (result > 0)
            {
                TempData["Msg"] = "Data saved";
                ViewBag.SuccessMsg = TempData["Msg"];
            }
            else
            {
                TempData["Msg"] = "Data not saved";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}