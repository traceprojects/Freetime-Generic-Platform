using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Freetime.Base.Business;
using Freetime.Base.Business.Implementable;
using Freetime.Base.Data.Collection;
using Freetime.Base.Data.Entities;

namespace Freetime.Data.Services.Client
{
    public class DataSessionFactory : IDataSessionFactory
    {
        private DataSessionServiceList m_serviceList;

        protected virtual DataSessionServiceList DataSessionServices
        {
            get
            {
                m_serviceList = m_serviceList ?? PluginManagement.PluginManager.Current.GetDataSessionServices();
                return m_serviceList;
            }
        }

        private string GetServiceName(string logicType)
        {
            var service = DataSessionServices.FirstOrDefault(x => x.Type == logicType);
            if (service == null)
                return string.Empty;
            return service.Name;
        }

        TContract IDataSessionFactory.GetDataSession<TContract>(ILogic logic, TContract defaultContract)
        {
            var blogic = PluginManagement.PluginManager.Current.GetBusinessLogic(logic.GetType().FullName);

            string logicType = defaultContract.GetType().FullName;

            if (!Equals(blogic, null))
                logicType = blogic.DataSessionType;

            string serviceName = GetServiceName(logicType);

            if (string.IsNullOrEmpty(serviceName))
                return defaultContract;


            var httpFactory =
                new ChannelFactory<TContract>(
                  new BasicHttpBinding(),
                  new EndpointAddress(
                    string.Format("http://localhost:8000/FreetimeDataServices/{0}", serviceName)));
            var contract = httpFactory.CreateChannel();

            if (contract == null)
                return defaultContract;

            return contract;
        }

        void IDataSessionFactory.AddAttribute(string key, string value)
        { 
        
        }
    }
}
