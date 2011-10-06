using System;
using System.Configuration;
using Freetime.Base.Framework;
using Freetime.Base.Framework.Diagnostics;
using Freetime.Base.Data.Contracts;
using Freetime.Base.Business.Implementable;
using Freetime.Base.Business.Configuration;

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

        static DataSessionBuilder()
        { 
            string configSection = Freetime.Configuration.ConfigurationManager.FreetimeConfiguration.DataSessionBuilderConfigurationSection;

            if (string.IsNullOrEmpty(configSection))
                return;

            try
            {
                var section = ConfigurationManager.GetSection(configSection);
                if (!typeof(DataSessionBuilderConfiguration).IsAssignableFrom(section.GetType()))
                {
                    TraceUtil.WriteLine(string.Format("ConfigurationSection {0} is not of Type Freetime.Base.Business.Configuration.DataSessionBuilderConfiguration", configSection)
                        , TraceUtil.Category.Critical);
                    throw new Exception(string.Format("ConfigurationSection {0} is not of Type Freetime.Base.Business.Configuration.DataSessionBuilderConfiguration", configSection));
                }

                var sessionBuilderConfig = section as DataSessionBuilderConfiguration;
                if (sessionBuilderConfig.CustomProvider)
                {
                    var sessionFactoryType = Type.GetType(sessionBuilderConfig.FactoryType);

                    if (Equals(sessionFactoryType, null))
                    {
                        TraceUtil.WriteLine(string.Format("Unknown DataSessionFactory Type: {0}", sessionBuilderConfig.FactoryType), TraceUtil.Category.Critical);
                        throw new Exception(string.Format("Unknow Type {0}", sessionBuilderConfig.FactoryType));
                    }

                    var sessionFactory = Framework.Activator.CreateInstance(sessionFactoryType);
                    
                    if(Equals(sessionFactory, null))
                    {
                        TraceUtil.WriteLine(string.Format("Unable to create DataSessionFactory instance of type {0}", sessionBuilderConfig.FactoryType), TraceUtil.Category.Critical);
                        throw new Exception(string.Format("Unable to create DataSessionFactory instance of type {0}", sessionBuilderConfig.FactoryType));
                    }

                    if (!typeof(IDataSessionFactory).IsAssignableFrom(sessionFactory.GetType()))
                    {
                        TraceUtil.WriteLine(string.Format("{0} is not of type DataSessionFactory", sessionBuilderConfig.FactoryType), TraceUtil.Category.Critical);
                        throw new Exception(string.Format("{0} is not of type DataSessionFactory", sessionBuilderConfig.FactoryType));
                    }

                    DataSessionFactory = sessionFactory as IDataSessionFactory;
                }
            }
            catch (Exception ex)
            {
                TraceUtil.WriteLine(ex.Message);
                throw ex;
            }
        
        }
        
    }
}
