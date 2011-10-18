using System;
using Freetime.Web.Controller.Implementable;

namespace Freetime.Web.Controller
{
    public class BusinessLogicBuilder
    {
        private static IBusinessLogicFactory s_businessLogicFactory;

        private static IBusinessLogicFactory BusinessLogicFactory
        {
            get
            {
                s_businessLogicFactory = s_businessLogicFactory ?? new BusinessLogicFactory();
                return s_businessLogicFactory;
            }
            set { s_businessLogicFactory = value; }
        }

        public static void SetBusinessLogicFactory(IBusinessLogicFactory factory)
        {
            if (Equals(factory, null))
                throw new ArgumentNullException("factory");

            BusinessLogicFactory = factory;
        }

        public static TLogic GetBusinessLogic<TLogic>(IFreetimeController controller, TLogic defaultLogic)
        {
            return BusinessLogicFactory.GetBusinessLogic(controller, defaultLogic);
        }

        static BusinessLogicBuilder()
        {
            
        }
    }
}
