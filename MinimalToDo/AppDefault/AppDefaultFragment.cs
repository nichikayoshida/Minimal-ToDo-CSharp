
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace MinimalToDo.AppDefault
{
    public abstract class AppDefaultFragment : Fragment
    {
        
        protected abstract int LayoutResourceId { get; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(LayoutResourceId, container, false);
        }
    }
}
