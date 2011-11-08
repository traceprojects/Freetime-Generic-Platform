using System;

namespace Freetime.Base.Component
{
    internal class BusinessLogicFactory : IBusinessLogicFactory
    {
        public TLogic GetBusinessLogic<TLogic>(Type logicOwnerType, TLogic defaultLogic)
        {
            return defaultLogic;
        }

        public TLogic CreateBusinessLogic<TLogic>()
        {
            return default(TLogic);
        }

        public void AddAttribute(string key, string value)
        {
            
        }
    }
}
