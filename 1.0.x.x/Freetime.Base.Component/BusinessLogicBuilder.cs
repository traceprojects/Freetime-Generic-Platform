using System;

namespace Freetime.Base.Component
{
    public class BusinessLogicBuilder : IBusinessLogicBuilder
    {
        private static IBusinessLogicBuilder s_businessLogicBuilder;
        private static IBusinessLogicFactory s_businessLogicFactory;

        private static IBusinessLogicFactory BusinessLogicFactory
        {
            get
            {
                s_businessLogicFactory = s_businessLogicFactory ?? new BusinessLogicFactory();
                return s_businessLogicFactory;
            }
        }


        public static IBusinessLogicBuilder Current 
        { 
            get { s_businessLogicBuilder = s_businessLogicBuilder ?? new BusinessLogicBuilder();
                return s_businessLogicBuilder;
            }
        }

        public static void SetBusinessLogicFactory(IBusinessLogicFactory factory)
        {
            s_businessLogicFactory = factory;
        }

        internal BusinessLogicBuilder()
        {
            //add attribute
            
        }

        public TLogic GetBusinessLogic<TLogic>(Type logicOwnerType, TLogic defaultLogic)
        {
            return BusinessLogicFactory.GetBusinessLogic(logicOwnerType, defaultLogic);
        }

        public TLogic CreateBusinessLogic<TLogic>()
        {
            return BusinessLogicFactory.CreateBusinessLogic<TLogic>();
        }

    }
}
