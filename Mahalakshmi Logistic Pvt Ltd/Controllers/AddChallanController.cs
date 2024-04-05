using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Mahalakshmi_Logistic_Pvt_Ltd.Models.ChallanRequest;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Controllers
{
    public class AddChallanController : Controller
    {
         public SqlConnection SQLConn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        // GET: AddChallan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Challan_Request()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Challan_Request(Challan ch)
        {
            try
            {
                if (ch == null)
                {
                    if(!ModelState.IsValid)
                    {
                        string sqlQuerry = "insert into [dbo].[sale_challan] (Branch_id) values" +
                            "('" + ch.Branch_id+ "','\" + ch.Branch_id+\"','\" + ch.Branch_id+\"','\" + ch.Branch_id+\"','\" + ch.Branch_id+\"'  )";

                        return View();
                    }
                }


            }catch (Exception ex)
            {
                ViewBag.ChallanError =ex.Message; 
            }

            return View();
        }
        

        public ActionResult ChallanList()
        {
            try
            {
                string sqlQuerry = "Select * from [dbo].[sale_challan] ";

                var chList = SQLConn.Query<Challan>(sqlQuerry);
                List<Challan> list = chList.ToList();
                ViewBag.ChallanList = list;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
       
                return View();

        }



    }
}