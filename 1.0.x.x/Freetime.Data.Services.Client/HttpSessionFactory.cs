using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Freetime.Base.Business;
using Freetime.Base.Business.Implementable;
using Freetime.Base.Data.Collection;
using Freetime.Base.Data.Entities;

namespace Freetime.Data.Services.Client
{
    public class HttpSessionFactory : IDataSessionFactory
    {
        private DataSessionServiceList m_serviceList;

        private string BaseAddress { get; set; }

        private IEnumerable<DataSessionService> DataSessionServices
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

            var logicType = defaultContract.GetType().FullName;

            if (!Equals(blogic, null))
                logicType = blogic.DataSessionType;

            var serviceName = GetServiceName(logicType);

            if (string.IsNullOrEmpty(serviceName))
                return defaultContract;

            var epa = new EndpointAddress(new Uri(string.Format("{0}/{1}", BaseAddress, serviceName)));

            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            
            var httpFactory =
                new ChannelFactory<TContract>(
                  binding,
                  epa);

            var contract = httpFactory.CreateChannel();

            return Equals(contract, null)
                       ? defaultContract
                       : contract;
        }

        void IDataSessionFactory.AddAttribute(string key, string value)
        {
            if (key == null)
                return;

            switch (key.ToLower())
            {
                case "hostaddress":
                    BaseAddress = value;
                    break;
            }
        }
    }
}
