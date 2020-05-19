using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMVCProject.Data.Model
{
public	class ProductFeature
	{
		public int ProductFeatureId { get; set; }
		public string FeatureName { get; set; }
		public string FeatureValue { get; set; }


		[Required]
		public int ProductId { get; set; }

		public virtual Product Product { get; set; }
	}
}
