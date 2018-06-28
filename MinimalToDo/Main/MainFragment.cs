
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using MinimalToDo.AppDefault;
using MinimalToDo.Utility;

namespace MinimalToDo.Main
{
    public class MainFragment : AppDefaultFragment
    {
        public static readonly string SHARED_PREF_DATA_SET_CHANGED = "MinimalToDo.Main.datasetchanged";
        public static readonly string CHANGE_OCCURED = "MinimalToDo.Main.changeoccured";

        protected override int LayoutResourceId => Resource.Layout.fragment_main;

        private List<ToDoItem> toDoList = new List<ToDoItem>();

        public override void OnStart()
        {
            base.OnStart();

            var sharedPreference = this.Activity.GetSharedPreferences(SHARED_PREF_DATA_SET_CHANGED, FileCreationMode.Private);
            if (sharedPreference.GetBoolean(CHANGE_OCCURED, false)){
                
            }
        }
    }
}
