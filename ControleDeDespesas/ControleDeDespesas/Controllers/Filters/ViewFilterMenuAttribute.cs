using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ControleDeDespesas.Controllers.Filters
{
    public class ViewFilterMenuAttribute : ActionFilterAttribute, IResultFilter
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            //http://www.c-sharpcorner.com/article/filters-in-Asp-Net-mvc-5-0-part-twelve/
        }

    }
}