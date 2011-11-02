using Freetime.Base.Data.Entities;
using System.ServiceModel;

namespace Freetime.Base.Data.Contracts
{
    [ServiceContract]
    public interface IAuthenticationSession : IDataSession
    {
        [OperationContract(Name = "GetUserAccount")]
        UserAccount GetUserAccount(string username);
    }
}
