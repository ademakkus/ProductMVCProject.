using ProductMVCProject.Admin.ViewModel;
using ProductMVCProject.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVCProject.Admin.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IProductRepository _productRepository;
		private readonly IProductImageRespository _productImageRespository;
		private readonly IProductFeatureRepository _productFeatureRepository;

		public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository, IProductImageRespository productImageRespository, IProductFeatureRepository productFeatureRepository)
		{
			_categoryRepository = categoryRepository;
			_productRepository = productRepository;
			_productImageRespository = productImageRespository;
			_productFeatureRepository = productFeatureRepository;
		}

		public ActionResult Index()
		{
			var pageModel = new HomePageModel {
				CategoryCount = _categoryRepository.Count(),
				ProductCount = _productRepository.Count(),
				ProductImageCount = _productImageRespository.Count(),
				ProductFeatureCount = _productFeatureRepository.Count()
			};
			return View(pageModel);
		}


	}
}