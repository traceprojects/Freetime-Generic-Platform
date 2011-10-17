using System;
using System.Web.Mvc;
using System.Globalization;
using Freetime.Web.Context;
using Freetime.Configuration;
using Freetime.PluginManagement;

namespace Freetime.Web.Routing
{
    public class ExtendedRazorViewEngine : RazorViewEngine
    {
        public ExtendedRazorViewEngine()
        {
            //AreaViewLocationFormats = new[] {
            //    "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            //    "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            //    "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
            //};
	 
            //AreaMasterLocationFormats = new[] {
            //    "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            //    "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            //    "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
            //};
	 
            //AreaPartialViewLocationFormats = new[] {
            //    "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            //    "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            //    "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
            //};

            ViewLocationFormats = new[] {
                "~/{0}.aspx",
                "~/{0}.ascx",
                "~/{1}/{0}.aspx",
                "~/{1}/{0}.ascx"
            };

            PartialViewLocationFormats = new[]{
                "~/Controls/{0}.aspx",
                "~/Controls/{0}.ascx"
            };

            MasterLocationFormats = new[] {
                "~/{0}.master"
            };
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (string.IsNullOrEmpty(masterName))
                masterName = ConfigurationManager.FreetimeConfiguration.DefaultMasterPage;

            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");

            if (string.IsNullOrEmpty(viewName))
                throw new ArgumentException("Value is required.", "viewName");


            string[] searchedViewLocations;
            string[] searchedMasterLocations;

            var controllerName = controllerContext.RouteData.GetRequiredString("controller");


            var viewPath = GetViewPath(ViewLocationFormats, viewName, UserHandle.CurrentUser.DefaultTheme,
                              controllerName, out searchedViewLocations);


            var masterPath = GetMasterPath(MasterLocationFormats, masterName, viewName, controllerName,
                UserHandle.CurrentUser.DefaultTheme, out searchedMasterLocations);

            if (!(string.IsNullOrEmpty(viewPath)) &&
               ((masterPath != string.Empty) || string.IsNullOrEmpty(masterName)))
                return new ViewEngineResult(
                    (CreateView(controllerContext, viewPath, masterPath)), this);

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }


        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            string[] searchedLocations;
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");

            var partialViewPath = GetPartialPath(PartialViewLocationFormats, partialViewName, UserHandle.CurrentUser.DefaultTheme,
                controllerName, out searchedLocations);

            if (!string.IsNullOrEmpty(partialViewPath))
                return new ViewEngineResult(
                    CreatePartialView(controllerContext, partialViewPath), this);
            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }

        protected string GetViewPath(string[] locations, string viewName, string theme,
            string controllerName, out string[] searchedLocations)
        {
            var view = PluginManager.Current.GetWebView(viewName);
            searchedLocations = null;
            if (view == null || !view.IsActive)
            {
                searchedLocations = new string[locations.Length];

                for (var i = 0; i < locations.Length; i++)
                {
                    var path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                         new object[] { viewName, controllerName });
                    if (VirtualPathProvider.FileExists(path))
                    {
                        searchedLocations = new string[0];
                        return path;
                    }
                    searchedLocations[i] = path;
                }
                return null;
            }

            return (view.IsThemed)
                ? string.Format("~/Themes/{0}/{1}", theme, view.File)
                : view.File;
        }

        protected string GetMasterPath(string[] locations, string mastername, string viewName,
            string controllerName, string theme, out string[] searchedLocations)
        {
            var master = PluginManager.Current.GetWebMasterPage(mastername);
            searchedLocations = null;
            if (master == null || !master.IsActive)
            {
                searchedLocations = new string[locations.Length];

                for (var i = 0; i < locations.Length; i++)
                {
                    var path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                         new object[] { viewName, controllerName, theme });
                    if (VirtualPathProvider.FileExists(path))
                    {
                        searchedLocations = new string[0];
                        return path;
                    }
                    searchedLocations[i] = path;
                }
                return null;
            }

            return (master.IsThemed)
                ? string.Format("~/Themes/{0}/{1}", theme, master.File)
                : master.File;
        }

        protected string GetPartialPath(string[] locations, string partialViewName, string theme,
            string controllerName, out string[] searchedLocations)
        {
            var partialView = PluginManager.Current.GetPartialView(partialViewName);
            searchedLocations = null;
            if (partialView == null || !partialView.IsActive)
            {

                searchedLocations = new string[locations.Length];

                for (var i = 0; i < locations.Length; i++)
                {
                    var path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                         new object[] { partialViewName, controllerName });
                    if (VirtualPathProvider.FileExists(path))
                    {
                        searchedLocations = new string[0];
                        return path;
                    }
                    searchedLocations[i] = path;
                }
                return null;
            }
            return (partialView.IsThemed)
                ? string.Format("~/Themes/{0}/{1}", theme, partialView.File)
                : partialView.File;
        }
    }
}
