﻿using System.Web;
using System.Web.Mvc;

namespace Employee_Travel_Booking_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
