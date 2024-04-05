using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Mahalakshmi_Logistic_Pvt_Ltd.Models.PartMaster;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Controllers
{
    public class PartMasterController : Controller
    {
        public SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        // GET: PartMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateParts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateParts(AddParts parts)
        {
            try
            {
                 
                
                string SqlQuerry = "insert into [master_parts_stocks] ([created_date],[category],[part_number],[hsn_number],[alias],[description],[gst],[dimensions],[rental_price],[purchase_price],[pocket_qty],[gsm],[color],[thickness],[weight],[volume_weight],[fresh_stock],[intransit_stock],[delivered_stock],[maintenance_stock],[scrap_stock],[stock_alert],[status],[sale_price]) values" +
                    "('"+parts.Created_date+"','"+parts.Category+"','"+parts.Part_number+"','"+parts.Hsn_number+"','"+parts.Alias+"','"+parts.Description+"','"+parts.Gst+"','"+parts.Dimensions+"','"+parts.Rental_price+"','"+parts.Purchase_price+"','"+parts.Pocket_qty+"','"+parts.Gsm+"','"+parts.Color+"','"+parts.Thickness+"','"+parts.Weight+"','"+parts.Volume_Weight+"','"+parts.Fresh_Stock+"','"+parts.Intransit_Stock+"','"+parts.Delivered_Stock+"','"+parts.Maintenance_Stock+ "','"+parts.Scrap_Stock+"','"+parts.Stock_Alert+"','"+parts.Status+"','"+parts.Sale_Price+"')";
                int qty = (int)(ViewData["Success"] = SqlConn.Execute(SqlQuerry));

                if (qty == 1)
                {
                    ViewBag.Maz = "Parts Created Successfully";
                }
                else
                {
                    ViewBag.error = "Oops Something Missing ! Please Check Details !!  ";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;  
            }
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> PartsListAsync()
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string sqlQuerry = "Select * from [master_parts_stocks]";
                    var partsData = await SqlConn.QueryAsync<AddParts>(sqlQuerry);
                    List<AddParts> lists = partsData.ToList();
                    ViewBag.PartsList = lists;
                }
                else
                {
                    ViewBag.msz = "Parts List Empty!!";
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        public async Task<ActionResult>EditParts(int id)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    if(id != 0)
                    {
                        string sqlQuerry = "Select * from [master_parts_stocks] where id ='"+id+"' ";
                        var getById =await SqlConn.QueryAsync<AddParts>(sqlQuerry);
                        List<AddParts> lists = getById.ToList();
                        ViewBag.PartsList = lists;


                        ViewData["Success"]=await SqlConn.ExecuteAsync(sqlQuerry);
                       
                    }
                }

            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditParts(AddParts parts,  int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if(parts != null)
                    {
                        if(id == parts.Id)
                        {
                            string sqlQuerry = "Update [master_parts_stocks] set ('"+parts.Created_date+"','"+parts.Category+"','"+parts.Part_number+"','"+parts.Hsn_number+"','"+parts.Alias+"','"+parts.Description+"','"+parts.Gst+"','"+parts.Dimensions+"','"+parts.Rental_price+"','"+parts.Purchase_price+"','"+parts.Pocket_qty+"','"+parts.Gsm+"','"+parts.Color+"','"+parts.Thickness+"','"+parts.Weight+"','"+parts.Volume_Weight+"','"+parts.Fresh_Stock+"','"+parts.Intransit_Stock+"','"+parts.Delivered_Stock+"','"+parts.Maintenance_Stock+"','"+parts.Scrap_Stock+"','"+parts.Stock_Alert+"','"+parts.Status+"','"+parts.Sale_Price+"') where id = '"+id+"' ";
                                  ViewData["Success"] = await SqlConn.ExecuteAsync(sqlQuerry);
                        }
                    }
                }

            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }



            return View();
        }


    }
}