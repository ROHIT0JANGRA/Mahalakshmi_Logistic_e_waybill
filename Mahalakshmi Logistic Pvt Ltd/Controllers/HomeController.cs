using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mahalakshmi_Logistic_Pvt_Ltd.Models.Login_Check;


namespace Mahalakshmi_Logistic_Pvt_Ltd.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult NewUser()
        {
            return View();
        }
        public ActionResult NewConsignee()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }



    }
}