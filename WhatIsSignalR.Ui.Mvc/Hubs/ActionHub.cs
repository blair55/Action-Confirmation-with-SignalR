using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using WhatIsSignalR.Ui.Mvc.Actions;
using WhatIsSignalR.Ui.Mvc.Delegates;

namespace WhatIsSignalR.Ui.Mvc.Hubs
{
    public class ActionHub : Hub
    {
        ActionExecutioner _executioner = new ActionExecutioner();

        public ActionHub()
        {
            _executioner.ActionExecuting += new ActionExecutedHandler(Executioner_ActionExecuting);
            _executioner.ActionExecuted += new ActionExecutedHandler(Executioner_ActionExecuted);
        }

        void Executioner_ActionExecuting(ActionExecutedEventArgs args)
        {
            Caller.alertExecutingAction(args.ActionTypeName);
        }

        void Executioner_ActionExecuted(ActionExecutedEventArgs args)
        {
            Caller.alertExecutedAction(args.ActionTypeName);
        }

        public void ExecuteActions()
        {
            try
            {
                _executioner.Execute(ActionFactory.GetActions());
            }
            catch (Exception ex)
            {
                Caller.alertActionException(ex.Data["Name"], ex.Message);
            }
        }
    }
}