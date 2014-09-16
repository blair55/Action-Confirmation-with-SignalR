using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatIsSignalR.Ui.Mvc.Actions;
using WhatIsSignalR.Ui.Mvc.Delegates;
using Microsoft.AspNet.SignalR;

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
            Clients.Caller.alertExecutingAction(args.ActionTypeName);
        }

        void Executioner_ActionExecuted(ActionExecutedEventArgs args)
        {
            Clients.Caller.alertExecutedAction(args.ActionTypeName);
        }

        public void ExecuteActions()
        {
            try
            {
                _executioner.Execute(ActionFactory.GetActions());
            }
            catch (Exception ex)
            {
                Clients.Caller.alertActionException(ex.Data["Name"], ex.Message);
            }
        }
    }
}