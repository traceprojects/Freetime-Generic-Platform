using System;
using System.ServiceModel;

namespace Freetime.Data.Services
{   

    public class Session
    {
        public enum SessionStatus
        { 
            Open,
            Closed
        }

        private ServiceHost Host { get; set; }

        public Type Contract { get; private set; }

        public string ContractName { get; private set; }

        public Type Service { get; private set; }

        public SessionStatus Status { get; private set; }

        public Session(ServiceHost host, Type contract, Type service)
        {
            Host = host;
            //serviceHost.Description.Behaviors
            //Host.Description.Behaviors.Add(

            //System.ServiceModel.Description.ServiceCredentials credential = new System.ServiceModel.Description.ServiceCredentials();
            //credential.UserNameAuthentication.CustomUserNamePasswordValidator = new ClientValidator();
           // credential.ClientCertificate.Certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"C:\Documents and Settings\Administrator\Desktop\test.pfx");
            
            //credential.ClientCertificate.Certificate.FriendlyName = "cn=localhost";
            //credential.ClientCertificate.Authentication.TrustedStoreLocation = System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine;
            
            //credential.ClientCertificate.Certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(
            //credential.ClientCertificate.Authentication.TrustedStoreLocation = System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine;
            
            //credential.ClientCertificate.SetCertificate("cn=freeg",
            //    System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine,
            //    System.Security.Cryptography.X509Certificates.StoreName.Root);

    //        c.ClientCredentials.ClientCertificate.SetCertificate(
    //StoreLocation.CurrentUser,
    //StoreName.My,
    //X509FindType.FindBySubjectName,
    //"contoso.com");


//            Host.Description.Behaviors.Add(credential);
            
            Contract = contract;
            ContractName = Contract.Name;
            Service = service;
            Status = SessionStatus.Closed;
        }

        public virtual void Open()
        {
            Host.Open();
            Status = SessionStatus.Open;
        }

        public virtual void Close()
        {
            Host.Close();
            Status = SessionStatus.Closed;
        }

        public override int GetHashCode()
        {
            return (Service != null && Service.FullName != null) ? Service.FullName.GetHashCode()
                : 0;
        }
    }
}
