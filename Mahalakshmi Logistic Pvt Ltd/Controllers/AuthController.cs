using Dapper;
using Mahalakshmi_Logistic_Pvt_Ltd.Models.Login_Check;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        //private string conne= System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users u)
        {
            Users us = new Users();
            var username = us.UserName = "Admin@mlpl24x7.com";
            var passwo = us.Password = "Admin@123";
            bool isvalid = false;
            int valid_auth = 0;
            try
            {
                if (u == null)
                {
                    ViewBag.NotExist = "User Not Exist !!";
                    return View();
                }
                else
                {
                    if (!string.IsNullOrEmpty(u.UserName) || !string.IsNullOrEmpty(u.Password))
                    {
                        if (username == u.UserName && passwo == u.Password)
                        {
                           isvalid = true;
                            valid_auth = 1;
                            return RedirectToAction("Dashboard","Home");
                        }
                        else
                        {
                            ViewData["error"] = "Username && Password not Exist !!";
                            return RedirectToAction("Login");
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                return ViewBag.error = ex.Message;

            }

            return View();
        }


    }
}