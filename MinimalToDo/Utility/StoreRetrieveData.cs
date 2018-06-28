using System;
using System.Collections.Generic;
using System.IO;
using Android.Content;
using Android.Util;
using Java.IO;
using Newtonsoft.Json;
using Org.Json;

namespace MinimalToDo.Utility
{
    public class StoreRetrieveData : Java.Lang.Object
    {

        private readonly Context context;
        private readonly string fileName;

        public StoreRetrieveData(Context context, string fileName)
        {
            this.context = context;
            this.fileName = fileName;
        }

        /// <summary>
        /// Converts <paramref name="toDoItems"/> to JsonArray
        /// </summary>
        /// <returns>The JSONA rray.</returns>
        /// <param name="toDoItems">To do items.</param>
        public static JSONArray ToJSONArray(List<ToDoItem> toDoItems)
        {
            try
            {
                var jsonArray = new JSONArray();
                toDoItems.ForEach(item =>
                {
                    var jsonObject = item.ToJson();
                    jsonArray.Put(jsonObject);
                });
                return jsonArray;
            }
            catch (JSONException e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="toDoItems">To do items.</param>
        public void SaveToFile(List<ToDoItem> toDoItems)
        {
            try
            {
                using (var o = new StreamWriter(context.OpenFileOutput(fileName, FileCreationMode.Private)))
                {
                    o.Write(ToJSONArray(toDoItems).ToString());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Loads from file.
        /// </summary>
        /// <returns>The from file.</returns>
        public List<ToDoItem> LoadFromFile()
        {
            try
            {
                using (var i = new StreamReader(context.OpenFileInput(fileName)))
                {
                    var result = i.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<ToDoItem>>(result);
                }
            }
            catch (System.IO.IOException e)
            {
                throw new Exception(e.Message);
            }
            catch (JsonException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
