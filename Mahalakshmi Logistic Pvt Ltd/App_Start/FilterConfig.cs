﻿using System.Web;
using System.Web.Mvc;

namespace Mahalakshmi_Logistic_Pvt_Ltd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
