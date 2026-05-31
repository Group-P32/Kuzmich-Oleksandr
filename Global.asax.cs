using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using JewelryStore.Models;

namespace Kuzmich_JewelryStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new JewelryDbInitializer());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}