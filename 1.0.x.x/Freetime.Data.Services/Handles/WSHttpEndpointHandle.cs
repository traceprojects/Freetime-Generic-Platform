using System;
using System.ServiceModel;

namespace Freetime.Data.Services.Handles
{
    public class WSHttpEndpointHandle : EndpointHandle
    {
        public string Address { get; set; }

        public SecurityMode SecurityMode { get; set; }

        public WSHttpEndpointHandle()
        {
            SecurityMode = SecurityMode.TransportWithMessageCredential;
        }

        public override void AssignEndpointToHost(ServiceHost host, Type contractType, string uniquename)
        {            

            var binding = new WSHttpBinding(SecurityMode);
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            var fixedAddress = Address.EndsWith("/") ? Address : string.Format("{0}/",Address);
            host.AddServiceEndpoint(contractType, binding, string.Format("{0}{1}", fixedAddress, uniquename));

            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
            host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new ClientValidator();
            
            host.Credentials.ServiceCertificate.SetCertificate("cn=freeg",
                System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine,
                System.Security.Cryptography.X509Certificates.StoreName.My);

        }
    }
}
