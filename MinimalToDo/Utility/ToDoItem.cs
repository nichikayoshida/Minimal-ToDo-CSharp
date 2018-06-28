using System;
using Android.Util;
using Java.IO;
using Java.Util;
using Org.Json;

namespace MinimalToDo.Utility
{
    public class ToDoItem : Java.Lang.Object, ISerializable
    {

        private static readonly string TODOTEXT = "todotext";
        private static readonly string TODOREMINDER = "todoreminder";
        private static readonly string TODOCOLOR = "todocolor";
        private static readonly string TODODATE = "tododate";
        private static readonly string TODOIDENTIFIER = "todoidentifier";

        private readonly string toDoBody;
        private readonly bool hasReminder;
        private readonly Date toDoDate;
        private readonly int toDoColor;
        private readonly UUID toDoIdentifire;


        public ToDoItem(string toDoBody, bool hasReminder, Date toDoDate)
        {
            this.toDoBody = toDoBody;
            this.hasReminder = hasReminder;
            this.toDoBody = toDoBody;
            toDoColor = 1677725;
            toDoIdentifire = UUID.RandomUUID();
        }

        public JSONObject ToJson()
        {
            try
            {
                var jsonObject = new JSONObject();
                jsonObject.Put(TODOTEXT, toDoBody);
                jsonObject.Put(TODOREMINDER, hasReminder);
                if (toDoDate != null)
                {
                    jsonObject.Put(TODODATE, toDoDate);
                }
                jsonObject.Put(TODOCOLOR, toDoColor);
                jsonObject.Put(TODOIDENTIFIER, toDoIdentifire.ToString());

                return jsonObject;
            }
            catch (JSONException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
