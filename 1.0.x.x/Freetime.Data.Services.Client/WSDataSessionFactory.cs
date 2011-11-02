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
    public class WSDataSessionFactory : IDataSessionFactory
    {
        private DataSessionServiceList m_serviceList;

        private string BaseAddress { get; set; }

        private string UserName { get; set; }

        private string Password { get; set; }

        private DataSessionServiceList DataSessionServices
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

            EndpointAddress epa = new EndpointAddress(new Uri(string.Format("{0}/{1}", BaseAddress, serviceName)));

            var binding = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
                        
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            TestTools.PermissiveCertificatePolicy.Enact("cn=freeg");

            var httpFactory =
                new ChannelFactory<TContract>(
                  binding,
                  epa);

            httpFactory.Credentials.ClientCertificate.SetCertificate("cn=freeg",
                System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine,
                System.Security.Cryptography.X509Certificates.StoreName.My);
            httpFactory.Credentials.UserName.UserName = UserName;
            httpFactory.Credentials.UserName.Password = Password;

            var contract = httpFactory.CreateChannel();
            if (contract == null)
                return defaultContract;

            return contract;
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
                case "username":
                    UserName = value;
                    break;
                case "password":
                    Password = value;
                    break;
            }
        }
    }
}
