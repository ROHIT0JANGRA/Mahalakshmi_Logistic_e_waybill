using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Models.Branch
{
    public class AddBranch
    {
       
        public int Id { get; set; }     
        public string Branch_name { get; set; }
        public string Branch_code { get; set; }
        public string Branch_pan_no { get; set; }
        public string Branch_landline_no { get; set; }
        
        public string Branch_email { get; set; }
        public string Branch_mobile { get; set; }
        public string Branch_gstin { get; set; }
        public string Branch_gstout { get; set; }
        public string Country_id { get; set; }
        public string Contact_name { get; set; }
        public string Contact_designation { get; set; }
        public string Contact_no { get; set; }
        public string Contact_email { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Address { get; set; }
        public string Created_date { get; set; }
        public string Created_by { get; set; }
    }
}