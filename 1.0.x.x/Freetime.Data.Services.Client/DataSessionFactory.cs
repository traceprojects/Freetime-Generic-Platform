using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Freetime.Base.Business;
using Freetime.Base.Business.Implementable;

namespace Freetime.Data.Services.Client
{
    public class DataSessionFactory : IDataSessionFactory
    {
        TContract IDataSessionFactory.GetDataSession<TContract>(ILogic logic, TContract defaultContract)
        {
            return defaultContract;
        }
    }
}
