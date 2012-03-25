using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatIsSignalR.Ui.Mvc.Actions
{
    public class PermeateAction : IAction
    {
        Random _rnd = new Random();

        public void Execute()
        {
            var i = _rnd.Next(0, 2);
            
            if (i > 0)
            {
                var ex = new Exception("Could not permeate!");
                ex.Data.Add("Name", this.GetType().Name);

                throw ex;
            }
        }
    }
}