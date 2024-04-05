using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Models.ChallanRequest
{
    public class Challan
    {
        public int Id { get; set; }
        public string Invoice_id { get; set; }
        public string Invoice_series { get; set; }

        public DateTime Date_created { get; set; }
        public int Created_by { get; set; }
        public int Consignee_id { get; set; }
        public int Consigner_id { get; set; }
        public int Branch_id { get; set; }
        public int TotalQty { get; set; }
        public int Total_pending_qty { get; set; }
        public int Total_delivered_qty { get; set; }
        public int Total_pickup { get; set; }
        public int TotalItem { get; set; }
        public float Sub_total { get; set; }
        public float Dis_amt { get; set; }
        public float Gross_total { get; set; }
        public float Gst_amt { get; set; }
        public float Order_total { get; set; }
        public int Rental_price { get; set; }
        public string Order_status { get; set; }
        public string Ve_type { get; set; }
        public string Ve_no { get; set; }
        public string Ve_freight { get; set; }
        public string Ve_driver_name { get; set; }
        public string Ve_mobile_no { get; set; }
        public string Ve_transport { get; set; }
        public int Del { get; set; }
    

    }
}