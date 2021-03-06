﻿using System.Web;
using System.Web.Mvc;
using FSP.HBSIS.Infra.CrossCutting.MvcFilters;

namespace FSP.HBSIS.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
