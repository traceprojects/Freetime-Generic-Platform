using System;
using Freetime.Base.Data.Contracts;
using Freetime.Base.Business.Implementable;

namespace Freetime.Base.Business
{
    public class DataSessionBuilder
    {
        private static IDataSessionFactory s_dataSessionFactory;

        private static IDataSessionFactory DataSessionFactory 
        {
            get
            {
                s_dataSessionFactory = s_dataSessionFactory ?? new DataSessionFactory();
                return s_dataSessionFactory;
            }
            set
            {
                s_dataSessionFactory = value;
            }
        }

        public static void SetDataSessionFactory(IDataSessionFactory dataSessionFactory)
        {
            DataSessionFactory = dataSessionFactory;
        }

        public static TDataSession GetDataSession<TDataSession>(ILogic logic, TDataSession defaultSession)
           where TDataSession : IDataSession
        {
            if (Equals(defaultSession, null))
                throw new ArgumentNullException("defaultSession");
            if(Equals(logic, null))
                throw new ArgumentNullException("logic");

            return DataSessionFactory.GetDataSession(logic, defaultSession);
        }
        
    }
}
