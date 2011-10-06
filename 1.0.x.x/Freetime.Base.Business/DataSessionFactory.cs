using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Reflection.Emit;
using Freetime.Base.Business.Implementable;

namespace Freetime.Base.Business
{
    internal class DataSessionFactory : IDataSessionFactory
    {
        private bool UseDefaultDataSession { get; set; }

        internal DataSessionFactory()
        {
            UseDefaultDataSession = true;
        }

        TContract IDataSessionFactory.GetDataSession<TContract>(ILogic logic, TContract defaultContract)
        {
            var blogic = PluginManagement.PluginManager.Current.GetBusinessLogic(logic.GetType().FullName);

            if (blogic == null)
                return defaultContract;

            var sessionType = Type.GetType(string.Format("{0}, {1}", blogic.DataSessionType, blogic.DataSessionAssembly));

            if(sessionType == null)
                throw new Exception(string.Format("Unknown type: {0}, {1}", blogic.DataSessionType, blogic.DataSessionAssembly));

            var typeInstance = Freetime.Base.Framework.Activator.CreateInstance(sessionType);

            if(!typeof(TContract).IsAssignableFrom(typeInstance.GetType()))
                return defaultContract;

            var sessionInstance = (TContract) typeInstance;

            return (Equals(sessionInstance, null)) 
                ? defaultContract 
                : sessionInstance;
        }

        void IDataSessionFactory.AddAttribute(string key, string value)
        {

        }
    }
}
