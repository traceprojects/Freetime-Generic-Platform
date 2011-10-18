using System;
using System.Web.Mvc;
using Freetime.Web.Context;

namespace Freetime.Web.View.Helpers
{
    public static class ThemedImageExtensions
    {
        public static string ThemedImage(this HtmlHelper helper, string imageName, object htmlAttributes)
        {
            return ThemedImage(helper, UserHandle.CurrentUser.DefaultTheme, imageName, htmlAttributes);
        }
        public static string ThemedImage(this HtmlHelper helper, string theme, string imageName,
            object htmlAttributes)
        {
            if (Equals(helper, null))
                throw new ArgumentNullException("helper");

            if(Equals(helper.ViewContext, null) 
                || Equals(helper.ViewContext.HttpContext, null)
                || Equals(helper.ViewContext.HttpContext.Request, null)
                || Equals(helper.ViewContext.HttpContext.Request.Url, null)
                )
                throw new Exception("HttpContext can't be null"); 

            var builder = new TagBuilder("img");
            AttributeHelper.MergeAttribute(builder, htmlAttributes);
            var imageLocationFormat = helper.ViewContext.HttpContext.Request.Url + "/Themes/{0}/{1}/{2}";
            builder.MergeAttribute("src", string.Format(imageLocationFormat, theme, "images", imageName));
            return builder.ToString();
        }

        public static string ThemedImage(this HtmlHelper helper, string theme, string imageName)
        {
            if (Equals(helper, null))
                throw new ArgumentNullException("helper");

            if (Equals(helper.ViewContext, null)
                || Equals(helper.ViewContext.HttpContext, null)
                || Equals(helper.ViewContext.HttpContext.Request, null)
                || Equals(helper.ViewContext.HttpContext.Request.Url, null)
                )
                throw new Exception("HttpContext can't be null"); 

            var builder = new TagBuilder("img");
            var imageLocationFormat = helper.ViewContext.HttpContext.Request.Url + "/Themes/{0}/{1}/{2}";
            builder.MergeAttribute("src", string.Format(imageLocationFormat, theme, "images", imageName));
            return builder.ToString();
        }
    }
}
