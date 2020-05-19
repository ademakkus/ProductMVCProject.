using Microsoft.Ajax.Utilities;
using ProductMVCProject.Core.Infrastructure;
using ProductMVCProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace ProductMVCProject.Admin.Controllers
{
    public class ProductController : Controller
    {
	private	readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IProductImageRespository _productImageRespository;

		public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductImageRespository productImageRespository)
		{
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
			_productImageRespository = productImageRespository;
		}

		// GET: Product
		public ActionResult Index()
        {
			var productList = _productRepository.GetAll().ToList();
			return View(productList);
        }


		public ActionResult Create()
		{
			SetCategoryList();
			return View();
		}

		private void SetCategoryList(object category = null)
		{
			var categoryList = _categoryRepository.GetAll().ToList();
			var selectList = new SelectList(categoryList, "CategoryId", "CategoryName", category); //view tarafındaki dropdownlist için ayarlama

			ViewData.Add("CategoryId", selectList); //view a gönder
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Product product, HttpPostedFileBase productImage)
		{
			if (!ModelState.IsValid)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			}
			if (productImage != null & productImage.ContentLength > 0)
			{
				var img = new ProductImage
				{
					ImageName = Path.GetFileName(productImage.FileName),
					ContentType = productImage.ContentType
				};
				using (var reader = new BinaryReader(productImage.InputStream))
				{
					img.Content = reader.ReadBytes(productImage.ContentLength);
				}
				product.ProductImages = new List<ProductImage> { img };
			}
			_productRepository.Insert(product);
			_productRepository.Save();
			return RedirectToAction("Index");

		}



		//public ActionResult Create(Product product, HttpPostedFileBase[] productImage)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

		//	}
		//	foreach (HttpPostedFileBase file in productImage)
		//	{
		//		if (file != null & file.ContentLength > 0)
		//		{
		//			var img = new ProductImage
		//			{
		//				ImageName = Path.GetFileName(file.FileName),
		//				ContentType = file.ContentType
		//			};
		//			using (var reader = new BinaryReader(file.InputStream))
		//			{
		//				img.Content = reader.ReadBytes(file.ContentLength);
		//			}
		//			product.ProductImages = new List<ProductImage> { img };
		//			_productRepository.Insert(product);


		//		}

		//	}
		//	_productRepository.Save();
		//	return RedirectToAction("Index");

		//}



		public ActionResult Edit(int? id)
		{

			if (id==null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var product = _productRepository.GetById(id.Value);  //	public ActionResult Edit(int? id) de ,int? id olduğundan id.value şeklinde değere erişilir.
			SetCategoryList(product.CategoryId);
			return View(product);

		}

[HttpPost,ValidateAntiForgeryToken]
		public ActionResult Edit(Product product,HttpPostedFileBase productImage)
		{
			if (!ModelState.IsValid)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			}
			_productRepository.Update(product);
			_productRepository.Save();
			if (productImage==null || productImage.ContentLength<=0)
			{
				return RedirectToAction("Index");

			}
			var img = new ProductImage()
			{
				ImageName = Path.GetFileName(productImage.FileName),
				ContentType = productImage.ContentType
			};

			using(var reader=new BinaryReader(productImage.InputStream))
			{
				img.Content = reader.ReadBytes(productImage.ContentLength);
				img.ProductId = product.ProductId;
			}
			var existingImage = _productRepository.GetById(product.ProductId).ProductImages;
			if (existingImage!=null && existingImage.Count>0)
			{
				existingImage.ForEach(x => _productImageRespository.Delete(x.ProductImageId));
			}
			_productImageRespository.Insert(img);
			_productImageRespository.Save();
			return RedirectToAction("Index");
		}

		public ActionResult Details(int? id)
		{
			if (id==null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var product = _productRepository.GetById(id.Value);
			if (product==null)
			{
				return HttpNotFound();
			}
			return View(product);

		}


		public ActionResult Delete(int? id)
		{
			if (id==null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var product =_productRepository.GetById(id.Value);
			if (product==null)
			{

				return HttpNotFound();
			}
			return View(product);

		}
		[HttpPost,ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			_productRepository.Delete(id);
			_productRepository.Save();
			return RedirectToAction("Index");
		}

	}

}