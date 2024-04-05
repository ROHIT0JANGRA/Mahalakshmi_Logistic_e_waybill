using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Mahalakshmi_Logistic_Pvt_Ltd.Models.Branch;
using Mahalakshmi_Logistic_Pvt_Ltd.Models.Customers;
using Microsoft.Ajax.Utilities;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Controllers
{
    public class CustomerController : Controller
    {
        public SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            try
            {

                string sqlQuerry = " Select * from  consigners where id = '"+id+"' ";
                var customerList = SqlConn.Query<Customer>(sqlQuerry);
                List<Customer> list = customerList.ToList();  
                ViewBag.customerDetails = list;
                return View();

            } catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }



        public ActionResult CreateCustomer() {

            try
            {
                if(ModelState.IsValid)
                {
                    string sqlQuerry = "select * from [branches]";
                    var listSquerry = SqlConn.Query<AddBranch>(sqlQuerry);
                    List<AddBranch>list = listSquerry.ToList();
                    ViewBag.branchList = list;
                    return View();
                }
            }catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }finally { SqlConn.Close(); }

         return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer cu)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string sqlQuerry = "insert into consigners(created_date,created_by,branch_id,contact_name,contact_designation,contact_no,contact_email,c_name,c_email,[c_mobile],[c_pan_no],[gstin],[cors_state],[cors_district],[cors_city],[cors_pincode],[cors_address],ship_state,ship_district,ship_city,ship_pincode,ship_address,[status])values" +
                        " ('"+cu.Created_date+"','"+cu.Created_by+"','"+cu.Branch_id+"','"+cu.Contact_name+"','"+cu.Contact_designation+"','"+cu.Contact_no+"','"+cu.Contact_email+"','"+cu.C_Name+"','"+cu.C_email+"','"+cu.C_mobile+"','"+cu.C_pan_no+"','"+cu.Gstin+"','"+cu.Cors_State+"','"+cu.Cors_District + "','"+cu.Cors_City + "','"+cu.Cors_Pincode + "','"+cu.Cors_Address + "','"+cu.Ship_state+"','"+cu.Ship_district+"','"+cu.Ship_city+"','"+cu.Ship_pincode+"','"+cu.Ship_address+"','"+cu.Status+"')";


                    ViewData["success"]=  SqlConn.Execute(sqlQuerry);
                }



            }catch (Exception ex) {
             ViewBag.ErrorMessage = ex.Message;
            }

            return RedirectToAction("CustomerList");
        }


        public ActionResult CustomerList()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string sqlQuerry = "select * from [consigners]";
                    var listSquerry = SqlConn.Query<Customer>(sqlQuerry);
                    List<Customer> list = listSquerry.ToList();
                    ViewBag.customerList = list;
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            finally { SqlConn.Close(); }

            return View();
        }


        public ActionResult DeleteCustomer(int Id)
        {
            try
            {
                string sqlQuerry = " Select * from  consigners where id = '"+Id+"' ";
                var customerList = SqlConn.Query<Customer>(sqlQuerry);
                List<Customer> list = customerList.ToList();
                ViewBag.customerDetails = list;
              

            }
            catch(Exception ex)
            {
                ViewBag.errorMessage = ex.Message;  
            }

            return View();
        }
        [HttpPost]
        public ActionResult DeleteCustomer(Customer cu,int id)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(cu != null)
                    {
                        if(id != 0)
                        {
                            string sqlQuerry = " Delete consigners where id = '" + id + "' ";

                            ViewData["success"] = SqlConn.Execute(sqlQuerry);
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
            }

            return RedirectToAction("CustomerList");
        }

        //public ActionResult EditCustomer()
        //{
        //    try
        //    {
        //        string sqlQuerrys = "select * from [branches]";
        //        var listSquerry = SqlConn.Query<AddBranch>(sqlQuerrys);
        //         List<AddBranch> list = listSquerry.ToList();
        //        ViewBag.branchList = list;
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.error = ex.Message;
        //    }
        
        //    return View();
        //}

        public ActionResult EditCustomer(int Id)
        {
            try
            {
            
                string sqlQuerry = " Select * from  consigners where id = '" + Id + "' ";
                var customerList = SqlConn.Query<Customer>(sqlQuerry);
                List<Customer> lists = customerList.ToList();
                ViewBag.customerDetails = lists;

                string sqlQuerrys = "select * from [branches]";
                var listSquerry = SqlConn.Query<AddBranch>(sqlQuerrys);
                List<AddBranch> list = listSquerry.ToList();
                ViewBag.branchList = list;

              

            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
            }
            finally
            {
                SqlConn.Close();
            }

            return View();
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer cu, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (cu != null)
                    {
                        if (id != 0)
                        {
                            string sqlQuerry = " Update consigners set created_date ='"+cu.Created_date+"' ,created_by ='"+cu.Created_by+"' ,branch_id='"+cu.Branch_id+"',contact_name='"+cu.Contact_name+"',contact_designation ='"+cu.Contact_designation+"' ,contact_no ='"+cu.Contact_no+"' ,contact_email='"+cu.Contact_email+"' ,c_name='"+cu.C_Name+"',c_email='"+cu.C_email+"',[c_mobile]='"+cu.C_mobile+"',[c_pan_no]='"+cu.C_pan_no+"',[gstin]='"+cu.Gstin+"',[cors_state]='"+cu.Cors_State+"',[cors_district]='"+cu.Cors_District+"',[cors_city]='"+cu.Cors_City+"',[cors_pincode]='"+cu.Cors_Pincode+"',[cors_address]='"+cu.Cors_Address+"',ship_state='"+cu.Ship_state+"',ship_district='"+cu.Ship_district+"',ship_city='"+cu.Ship_city+"',ship_pincode='"+cu.Ship_pincode+"',ship_address='"+cu.Ship_address+"',[status]='"+cu.Status+"' where id = '" + id + "' ";

                            ViewData["Editsuccess"] = SqlConn.Execute(sqlQuerry);
                          
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
            }

            return RedirectToAction("CustomerList");
        }

    }
}