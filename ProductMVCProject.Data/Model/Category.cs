using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductMVCProject.Data.Model
{
	public	class Category
	{
		[Key]
		public int CategoryId { get; set; }

		[Required(ErrorMessage ="{0} boş bırakılamaz")] //{0} yerine	[DisplayName("Kategori Adı")] içindeki "Kategori Adı" eş
		
		[DisplayName("Kategori Adı")]
		public string CategoryName { get; set; }
		public virtual ICollection<Product> Products { get; set; }

	}
}
