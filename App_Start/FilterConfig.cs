﻿using System.Web;
using System.Web.Mvc;

namespace R61M6C2_w01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
