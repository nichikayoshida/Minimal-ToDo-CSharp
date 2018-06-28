using System;
using Java.IO;
using Java.Util;

namespace MinimalToDo.Utility
{
    public class ToDoItem : Java.Lang.Object ,ISerializable
    {
        
        private readonly string toDoBody;
        private readonly bool hasReminder;
        private readonly DateTime toDoDate;
        private readonly int toDoColor;
        private readonly UUID toDoIdentifire;


        public ToDoItem(string toDoBody, bool hasReminder, DateTime toDoDate)
        {
            this.toDoBody = toDoBody;
            this.hasReminder = hasReminder;
            this.toDoBody = toDoBody;
            toDoColor = 1677725;
            toDoIdentifire = UUID.RandomUUID();
        }
    }
}
