using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PermissionRequestApp
{
    public class PerRequest
    {
        string _reqDate;
        string _reqReason;
        int _numberOfDays;

        public string ReqDate { get { return _reqDate; }  set { _reqDate = value; } }
        public string Reqreason { get { return _reqReason; } set { _reqReason = value; } }
        public int NumberOfDays { get { return _numberOfDays; } set { _numberOfDays = value; } }
    }
}