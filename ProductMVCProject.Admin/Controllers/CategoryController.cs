﻿using ProductMVCProject.Core.Infrastructure;
using ProductMVCProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductMVCProject.Admin.Controllers
{
	public class CategoryController : Controller
	{
		private ICategoryRepository _categoryRepository;
		// GET: Category
		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public ActionResult Index()
		{
			var categoryList = _categoryRepository.GetAll().ToList();
			return View(categoryList);
		}
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Category category)
		{
			if (!ModelState.IsValid)
			{
				return View(category);
			}
			_categoryRepository.Insert(category);
			_categoryRepository.Save();
			return RedirectToAction("Index");
		}



		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var category = _categoryRepository.GetById(id.Value); //int? id yani id nullable oldğu için GetById(id.Value) kllanılır.
			if (category == null)
			{
				HttpNotFound();
			}
			return View(category);
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Category category)
		{
			if (!ModelState.IsValid)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			_categoryRepository.Update(category);
			_categoryRepository.Save();
			return RedirectToAction("Index");
		}


		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var category = _categoryRepository.GetById(id.Value); //int? id yani id nullable oldğu için GetById(id.Value) kllanılır.

			if (category == null)
			{
				return HttpNotFound();
			}
			return View(category);
		}


		[HttpGet]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var category = _categoryRepository.GetById(id.Value);
			if (category == null)
			{
				return HttpNotFound();
			}
			return View(category);
		}
		[HttpPost]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{

			_categoryRepository.Delete(id);
			_categoryRepository.Save();
			return RedirectToAction("Index");
		}
	}
}