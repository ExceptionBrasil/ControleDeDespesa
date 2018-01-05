using BuildMenu;
using Factorys.Ninject;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace ControleDeDespesas.Controllers.Filters
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        private UsuariosDAO userDAO;

        public AutorizacaoFilterAttribute()
        {
            this.userDAO = Injections.UsuarioInject();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Home" &&
                filterContext.ActionDescriptor.ActionName == "Index")
                )
            {
                if (!WebSecurity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Home",
                                action = "Index"
                            }));
                }

            }
            
            
        }

    }
}