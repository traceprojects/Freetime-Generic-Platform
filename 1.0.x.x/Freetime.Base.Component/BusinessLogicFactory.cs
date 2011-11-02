using System;

namespace Freetime.Base.Component
{
    public class BusinessLogicFactory : IBusinessLogicFactory
    {
        public TLogic GetBusinessLogic<TLogic>(Type logicOwnerType, TLogic defaultLogic)
        {
            return defaultLogic;
        }

        public void AddAttribute(string key, string value)
        {
            
        }

        internal BusinessLogicFactory()
        {
            
        }
    }
}
