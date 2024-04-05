using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mahalakshmi_Logistic_Pvt_Ltd.Models.Login_Check
{
    public class Users
    {
   
        public int ID { get; set; }
        public string UserName { get; set; }
        public string  Password { get; set; }
        public int MobNo { get; set; }
        public string Role { get; set; }

    }
}