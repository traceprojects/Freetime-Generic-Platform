using System;

namespace Freetime.Base.Component
{
    public interface IBusinessLogicFactory
    {
        TLogic GetBusinessLogic<TLogic>(Type logicOwnerType, TLogic defaultLogic);

        void AddAttribute(string key, string value);
    }
}
