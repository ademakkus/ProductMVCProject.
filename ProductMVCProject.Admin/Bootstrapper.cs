using Autofac.Integration.Mvc;
using System.Web;
using Autofac.Core.Registration;
using Autofac;
using ProductMVCProject.Core;
using ProductMVCProject.Data;
using Autofac.Extensions;
using ProductMVCProject.Core.Repository;
using ProductMVCProject.Core.Infrastructure;
using System.Web.Mvc;

namespace ProductMVCProject.Admin
{

	public static class Bootstrapper
	{
		//bu sınıf ve mettlarını Gloabl.asax dosyasında register etmeliyiz.
		public static void RunConfig()
		{
			BuildAutofac();
		}

		private static void BuildAutofac()
		{
			var builder = new ContainerBuilder();

			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

			builder.RegisterType<ProductRepository>().As<IProductRepository>();
			builder.RegisterType<ProductFeatureRepository>().As<IProductFeatureRepository>();
			builder.RegisterType<ProductImageRepository>().As<IProductImageRespository>();
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



		}
	}

}