using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatIsSignalR.Ui.Mvc.Actions
{
    public class ActionFactory
    {
        public static IEnumerable<IAction> GetActions()
        {
            return new List<IAction>
            {
                new ConsolidateAction(), new PermeateAction(), new RectifyAction()
            };
        }
    }
}