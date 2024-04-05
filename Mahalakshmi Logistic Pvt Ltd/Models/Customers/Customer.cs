using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Models.Customers
{
    public class Customer
    {

        public int Id { get; set; }
        public string Created_date { get; set; }
        public string Created_by { get; set; }
        public string Branch_id { get; set; }
            
        public string Contact_name { get; set; }
            public string Contact_designation { get; set; }
        public string Contact_no { get; set; }
        public string Contact_email { get; set; }
        public string C_Name { get; set; }
        public string Con_email { get; set; }
        

        public string C_email { get; set; }
            
        public string C_pan_no { get; set; }
        public string C_mobile { get; set; }
        public string Gstin { get; set;}
        public string Cors_State { get; set; }
        public string Cors_District { get; set; }
        public string Cors_City { get; set; }
        public string Cors_Pincode { get; set; }

        public string Cors_Address { get; set; }
        public string Ship_state { get; set; }
        public string Ship_district { get; set; }
        public string Ship_city { get; set; }
        public string Ship_pincode { get; set; }

        public string Ship_address { get; set; }
        public string Status { get; set; }
    }
}