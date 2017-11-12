using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace BuildMenu
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MenuAttribute : ActionFilterAttribute  //Attribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

       
        public MenuAttribute(string Controller, string Action, string Location, string Descricao)
        {
            MakeMenu.Add(Controller, Action, Location,Descricao);            
        }
    }
}
