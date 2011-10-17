using System.Web.Mvc;
using System.Web.Routing;
using Freetime.Base.Framework.Diagnostics;
using Freetime.Base.Component.Diagnostics;
using Freetime.Web.Controller;
using Freetime.Web.Routing;

namespace Freetime.Web
{

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Root",
                "{action}",
                new { controller = "Root", action = "Index" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Root", action = "Index", id = "" }
            );
        }

        protected virtual void Application_Start()
        {
            ViewEngines.Engines.Clear();
            var engine = new ExtendedWebFormViewEngine();

            ViewEngines.Engines.Add(engine);

            RegisterRoutes(RouteTable.Routes);          
            
            
            //Load from a config section
            //GlobalEventConfiguration eventConfig = ConfigurationManager.GetSection("globalEventConfig") as GlobalEventConfiguration;
            //PluginLogic.PluginManager.LoadEventHandlers(eventConfig);

            //Load event handlers from an xml file
            //PluginLogic.PluginManager.LoadEventHandlers(@"C:\Documents and Settings\Administrator\Desktop\freetime\1.0.1.x\Freetime.Web\Config\Events.config");

            //Set Controller Factory
            var factory = new ControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(factory);

            //Set DataSessionFactory
            //Freetime.Data.Services.Client.DataSessionFactory dataSessionFactory = new Freetime.Data.Services.Client.DataSessionFactory();

            //Add Trace Listener
            var listener = new LogWriterTraceListener();
            TraceUtil.AddListener(listener);            
        }
    }
}