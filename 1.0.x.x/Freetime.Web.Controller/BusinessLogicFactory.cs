using Freetime.Web.Controller.Implementable;

namespace Freetime.Web.Controller
{
    public class BusinessLogicFactory : IBusinessLogicFactory
    {
        public TLogic GetBusinessLogic<TLogic>(IFreetimeController controller, TLogic defaultLogic)
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
