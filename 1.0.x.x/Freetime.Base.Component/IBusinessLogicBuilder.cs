using System;

namespace Freetime.Base.Component
{
    public interface IBusinessLogicBuilder
    {
        TLogic GetBusinessLogic<TLogic>(Type logicOwnerType, TLogic defaultLogic);

        TLogic CreateBusinessLogic<TLogic>();
    }
}
