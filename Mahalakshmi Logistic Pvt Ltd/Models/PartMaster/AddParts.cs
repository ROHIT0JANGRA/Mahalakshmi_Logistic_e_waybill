using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Models.PartMaster
{
    public class AddParts
    {
        public int Id { get; set; }
        public string Created_date { get; set; }    
        public string Category { get; set; }
        public string Part_number { get; set; }
        public string Hsn_number { get; set; }     
        public string Alias { get; set; }         
        public string Description { get; set; }
        public string Gst { get; set; }    
        public string Dimensions { get; set; }
        public string Rental_price { get; set; }
        public string Purchase_price { get; set;}
        public string Pocket_qty { get; set; }
        public string Gsm { get; set; }
        public string Color { get; set; }
        public string Thickness { get; set; }
        public string Weight { get; set; }  
        public string Volume_Weight { get; set; }
        public string Fresh_Stock { get; set; }
        public string Intransit_Stock { get; set; }
        public string Delivered_Stock { get; set; }
        public string Maintenance_Stock { get; set; }
        public string Scrap_Stock { get; set; }
        public string Stock_Alert { get; set; }
        public string Status { get; set; }
        public string Sale_Price { get; set; }

    }
}