using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductMVCProject.Core.Infrastructure
{
	/// <summary>
	/// data ile ilgili işlem yapılacak metodların isim tanımlaması
	/// </summary>
	/// <typeparam name="T">T type</typeparam>
	public	interface IRepository<T>where T:class
	{
		IEnumerable<T> GetAll();


		/// <summary>
		/// tek bir nesne döndürür
		/// </summary>
		/// <param name="id">int id</param>
		/// <returns>IEnumerable<T></returns>
		T GetById(int id); 



		T Get(Expression<Func<T, bool>> expression);

		/// <summary>
		/// birden fazla nesne döndürür
		/// </summary>
		/// <returns></returns>
		IQueryable<T> GetMany(Expression<Func<T, bool>> expression);


		void Insert(T entity); //void Insert(T obj);

		void Update(T entity);

		void Delete(int id);

		int Count();

		void Save();


	}
}
