using System;

namespace Freetime.Base.Component
{
    public interface IBusinessLogicFactory
    {
        TLogic GetBusinessLogic<TLogic>(Type logicOwnerType, TLogic defaultLogic);

        TLogic CreateBusinessLogic<TLogic>();

        void AddAttribute(string key, string value);
    }
}
