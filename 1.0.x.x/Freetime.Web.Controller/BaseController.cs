using System;
using Freetime.Authentication;
using Freetime.Base.Business;
using Freetime.GlobalHandling;
using Freetime.Base.Business.Implementable;
using Freetime.Web.Context;
using Freetime.Web.Controller.Implementable;

namespace Freetime.Web.Controller
{    
    public abstract class BaseController<TLogic> : System.Web.Mvc.Controller, IFreetimeController where TLogic : ILogic
    {
        protected abstract TLogic DefaultLogic { get; }

        protected virtual TLogic CurrentLogic
        {
            get { return BusinessLogicBuilder.GetBusinessLogic(this, DefaultLogic); }
        }

        public virtual FreetimeUser CurrentUser
        {
            get
            {
                return UserHandle.CurrentUser;
            }
        }

        public string Theme
        {
            get
            {
                return CurrentUser.DefaultTheme;
            }
            set
            {
                CurrentUser.DefaultTheme = value;
            }
        }

        protected bool HasEvent(string eventName)
        {
            return GlobalEventDispatcher.HasEvent(eventName);
        }

        protected void RaiseEvent(string eventName, EventArgs args)
        {
            GlobalEventDispatcher.RaiseEvent(eventName, this, args);
        }

        protected void RaiseEvent(string eventName, object sender, EventArgs args)
        {
            GlobalEventDispatcher.RaiseEvent(eventName, sender, args);
        }

    }

    public abstract class BaseController : BaseController<ISharedLogic>
    {
        protected override ISharedLogic DefaultLogic
        {
            get { return new SharedLogic(); }
        }
    }
}
