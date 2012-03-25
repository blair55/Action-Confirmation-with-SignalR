using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatIsSignalR.Ui.Mvc.Delegates;
using System.Threading;

namespace WhatIsSignalR.Ui.Mvc.Actions
{
    public class ActionExecutioner
    {
        public event ActionExecutedHandler ActionExecuted;
        public event ActionExecutedHandler ActionExecuting;

        Random _rnd = new Random();

        public void Execute(IEnumerable<IAction> actions)
        {
            foreach (var action in actions)
            {
                var args = new ActionExecutedEventArgs(action.GetType().Name);

                if (ActionExecuting != null)
                    ActionExecuting(args);

                Thread.Sleep(_rnd.Next(1000, 3000));

                action.Execute();

                if (ActionExecuted != null)
                    ActionExecuted(args);
            }
        }
    }
}