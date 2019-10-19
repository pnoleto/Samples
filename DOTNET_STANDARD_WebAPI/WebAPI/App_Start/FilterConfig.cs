//-----------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------
using System.Web;
using System.Web.Mvc;

namespace WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
