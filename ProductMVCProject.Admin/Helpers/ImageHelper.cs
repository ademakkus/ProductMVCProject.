using ProductMVCProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVCProject.Admin.Helpers
{
	public static class ImageHelper
	{
		public static IHtmlString Base64Image(this HtmlHelper helper,ProductImage productImage,int width=125,int height=125)
		{

			var imgString = string.Format(@"<img src='data:{0};base64,{1}' width='{2}' height='{3}'/>", productImage.ContentType,
				Convert.ToBase64String(productImage.Content),
				width,
				height
				);
			return new HtmlString(imgString);
		}
	}
}