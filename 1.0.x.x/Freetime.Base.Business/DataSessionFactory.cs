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

        #region Commented - do not remove
        //TContract IDataSessionFactory.GetDataSession<TContract>() 
        //{
        //    var httpFactory =
        //        new ChannelFactory<TContract>(
        //          new BasicHttpBinding(),
        //          new EndpointAddress(
        //            string.Format("http://192.168.175.123:8000/FreetimeDataServices/{0}", typeof(TContract).Name)));
        //    var contract = httpFactory.CreateChannel();
        //    return contract;
        //}
        
        //TContract IDataSessionFactory.GetDataSession<TContract>(TContract defaultContract) 
        //{
        //    if (UseDefaultDataSession) return defaultContract;

        //    var contract = (this as IDataSessionFactory).GetDataSession<TContract>();
        //    return Equals(contract, null) ? defaultContract : contract;
        //}
        #endregion

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
    }
}
