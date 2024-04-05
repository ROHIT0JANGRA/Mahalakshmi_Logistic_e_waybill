using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Mahalakshmi_Logistic_Pvt_Ltd.Models.Branch;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Controllers
{
    public class BranchController : Controller
    {
        //**************************************8This is connection string name for privious database ************************
        //	  <add name="dbconnection" connectionString="Data Source=LENOVO\MSSQLSERVER06;Integrated Security=true;Initial Catalog=MLPL_PKG" providerName="System.Data.SqlClient" />

        public SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        // GET: Branch
        public ActionResult Index()
        {
    
            return View();
        }

        public ActionResult BranchList()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string sqlQuerry = "Select * from branches";
                    var branchlist = SqlConn.Query<AddBranch>(sqlQuerry);
                    List<AddBranch> result = branchlist.ToList();
                    ViewBag.BranchList = result;
                }
                            
            }catch(Exception ex)
            {
                ViewBag.Exception = ex;
            }
             return View();
        }

        public ActionResult Branch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Branch(AddBranch b)
        {
            try
            {
                if(b == null)
                {
                    return View();
                }
                else
                {
                    if(ModelState.IsValid)
                    {
                        string SqlQuerry = "insert into branches(created_date,created_by,contact_name,contact_designation,contact_no,contact_email,branch_name,branch_code,branch_email,branch_landline_no,[branch_mobile],[branch_pan_no],[branch_gstin],[country_id],[state],[district],[city],[pincode],[address]) Values" +
                            " ('"+b.Created_date+"','"+b.Created_by+"','"+b.Contact_name+"','"+b.Contact_designation+"','"+b.Contact_no+"','"+b.Contact_email+"','"+b.Branch_name+"','"+b.Branch_code+"','"+b.Branch_email+"','"+b.Branch_landline_no+"','"+b.Branch_mobile+"','"+b.Branch_pan_no+"','"+b.Branch_gstin+"','"+b.Country_id + "','"+b.State+"','"+b.District+"','"+b.City+"','"+b.Pincode+"','"+b.Address+"') ";

                        ViewData["Success"]=SqlConn.Execute(SqlQuerry);
                    }
                    else
                    {
                        ViewData["Error"] = "Querry Not Executed !!";
                    };
                }
            }catch (Exception ex)
            {
                ViewBag.Branch = ex.Message;
            }
            return View();
        }


        public ActionResult EditBranch(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string sqlQuerry = "Select * from [branches] where id = '" + id + "' ";
                    var list =SqlConn.Query<AddBranch>(sqlQuerry);
                    List<AddBranch> result =list.ToList();
                    ViewBag.BranchById = result;
                }             

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
          
              
            return View();
        }
        [HttpPost]
        public ActionResult EditBranch(AddBranch  addBranch,int id)
        {


            try
            {
                if (addBranch == null)
                {
                    return View();
                }
                else
                {
                    string sqlQuerry = "update [branches] set branch_code='" + addBranch.Branch_code+"',branch_name='"+addBranch.Branch_name+"',branch_email='"+addBranch.Branch_email+"',branch_mobile='"+addBranch.Branch_mobile+"',branch_pan_no='"+addBranch.Branch_pan_no+"',branch_gstin='"+addBranch.Branch_gstin+"',contact_name='"+addBranch.Contact_name+"',contact_no='"+addBranch.Contact_no+"',contact_email='"+addBranch.Contact_email+"',state='"+addBranch.State+"',district='"+addBranch.District+"',city='"+addBranch.City+"',pincode='"+addBranch.Pincode+"',address='"+addBranch.Address+"' where id = '"+id+"' ";

                    ViewData["success"] = SqlConn.Execute(sqlQuerry);
                }
            }catch (Exception ex)
            {
                return ViewBag.Branch = ex.Message;
            }

            return RedirectToAction("BranchList","Branch");
        }



        public ActionResult DeleteBranch(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string sqlQuerry = "Select * from [branches] where id = '" + id + "' ";
                    var list = SqlConn.Query<AddBranch>(sqlQuerry);
                    List<AddBranch> result = list.ToList();
                    ViewBag.BranchById = result;
                }

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }


            return View();
        }
        [HttpPost]
        public ActionResult DeleteBranch(AddBranch addBranch, int id)
        {


            try
            {
                if (addBranch == null)
                {
                    return View();
                }
                else
                {
                    //string sqlQuerry = "update [branches] set branch_code='" + addBranch.Branch_code + "',branch_name='" + addBranch.Branch_name + "',branch_email='" + addBranch.Branch_email + "',branch_mobile='" + addBranch.Branch_mobile + "',branch_pan_no='" + addBranch.Branch_pan_no + "',branch_gstin='" + addBranch.Branch_gstin + "',contact_name='" + addBranch.Contact_name + "',contact_no='" + addBranch.Contact_no + "',contact_email='" + addBranch.Contact_email + "',state='" + addBranch.State + "',district='" + addBranch.District + "',city='" + addBranch.City + "',pincode='" + addBranch.Pincode + "',address='" + addBranch.Address + "' where id = '" + id + "' ";

                    string sqlQuerry = "Delete from [branches] where id = '" + id + "' ";

                    ViewData["success"] = SqlConn.Execute(sqlQuerry);
                }
            }
            catch (Exception ex)
            {
                return ViewBag.Branch = ex.Message;
            }

            return RedirectToAction("BranchList", "Branch");
        }

    }
}