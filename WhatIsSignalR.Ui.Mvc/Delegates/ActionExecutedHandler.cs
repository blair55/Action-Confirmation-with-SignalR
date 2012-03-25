using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatIsSignalR.Ui.Mvc.Delegates
{
    public delegate void ActionExecutedHandler(ActionExecutedEventArgs args);

    public class ActionExecutedEventArgs : EventArgs
    {
        private string _actionTypeName;

        public string ActionTypeName
        {
            get { return _actionTypeName; }
        }

        public ActionExecutedEventArgs(string actionTypeName)
        {
            _actionTypeName = actionTypeName;
        }
    }
}