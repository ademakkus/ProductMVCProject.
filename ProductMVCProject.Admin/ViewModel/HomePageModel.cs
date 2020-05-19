using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMVCProject.Admin.ViewModel
{
	public class HomePageModel
	{
		public int CategoryCount { get; set; }

		public int ProductCount { get; set; }
		public int ProductImageCount { get; set; }
		public int ProductFeatureCount { get; set; }

	}
}