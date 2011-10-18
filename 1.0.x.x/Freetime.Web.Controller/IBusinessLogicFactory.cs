using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Freetime.Web.Controller.Implementable;

namespace Freetime.Web.Controller
{
    public interface IBusinessLogicFactory
    {
        TLogic GetBusinessLogic<TLogic>(IFreetimeController controller, TLogic defaultLogic);

        void AddAttribute(string key, string value);
    }
}
