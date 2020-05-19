using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductMVCProject.Data.Model
{
	public	class Product
	{
		[Key]
		public int ProductId { get; set; }

		[Required(ErrorMessage ="{0} boş geçilmez")]
		[DisplayName("Ürün Adı")]
		public string ProductName { get; set; }

		public virtual ICollection<ProductImage>	 ProductImages { get; set; }
		public virtual ICollection<ProductFeature> ProductFeatures { get; set; }


		[Required]
		public int CategoryId { get; set; }

		[DisplayName("Kategori Adı")]
		public virtual Category Category { get; set; } //navigation property . Product ile işlemlerinde Category nesnesi de kaydedilecek

	}
}
