using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using ProductMVCProject.Web;

namespace ProductMVCProject.Admin
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{

			
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);//App_Start altındaki BundleConfig.cs
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			Bootstrapper.RunConfig();//ana dizinde tanımlanmış RunConfig metodu
		}
	}
}
