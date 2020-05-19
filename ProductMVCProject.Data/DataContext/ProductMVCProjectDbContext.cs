using ProductMVCProject.Data.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProductMVCProject.Data.DataContext
{
	public	class ProductMVCProjectDbContext:DbContext
	{
		public DbSet<Category>	 Category { get; set; }

		public DbSet<Product> Product { get; set; }
		public DbSet<ProductFeature> ProductFeature { get; set; }
		public DbSet<ProductImage> ProductImage { get; set; }
		/// <summary>
		///tablo nesneleri oluşturulurken çalışan metod
		
		/// </summary>
		/// <param name="modelBuilder">model builder</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//tanblo isimlerinin sonuna çoğul eki -s,-es,-ies eklemesini engellemek için
			modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

		}
			
		

	}
}
