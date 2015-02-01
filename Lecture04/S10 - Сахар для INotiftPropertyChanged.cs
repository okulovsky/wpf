using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;

namespace S10
{
    public static class NotifyPropertyChangedExtension
    {
        public static string PropertyName<TClass, TField>(
            this TClass obj,
            Expression<Func<TClass, TField>> address)
        {
            var property = (address.Body as MemberExpression).Member as PropertyInfo;
            return property.Name;
        }

        public static string PropertyName(this INotifyPropertyChanged obj, int stackDepth=1)
        {
            var stackTrace = new StackTrace();           // get call stack
            var stackFrames = stackTrace.GetFrames();  // get method calls (frames)
            var top = stackFrames[stackDepth].GetMethod().Name;
            return top.Substring(4, top.Length - 4);
        }

        public static void RaiseEvent(this INotifyPropertyChanged obj, int stackDepth=1)
        {
            var name = obj.PropertyName(stackDepth+1);
            var args=new PropertyChangedEventArgs(name);
            var field = obj
                .GetType()
                .GetField("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.GetField);
            var del = (MulticastDelegate)field.GetValue(obj);
            if (del != null)
                del.Method.Invoke(del.Target, new object[] { obj, args });
        }

        public static void SetAndRaiseEvent<TClass, TField>(
            this TClass obj,
            Expression<Func<TClass, TField>> address,
            TField value)
            where TClass : INotifyPropertyChanged
        {
            var field = (address.Body as MemberExpression).Member as FieldInfo;
            field.SetValue(obj, value);
            obj.RaiseEvent(2);
        }

   }

    public class DataClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string someString;
        public string SomeString
        {
            get { return someString; }
            set
            {
                //someString = value;
                //if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("SomeString"));
                //if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(this.PropertyName(z => z.SomeString)));
                //if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(this.PropertyName()));
                //this.RaiseEvent();
                this.SetAndRaiseEvent(z => z.someString, value);
            }
        }


        public static void Main()
        {
            var etalon=2.3E-5;
            int count=1000;

            var data = new DataClass();
            string propertyName = "";
            data.PropertyChanged += (s, a) => propertyName = a.PropertyName;
            var watch = new Stopwatch();
            watch.Start();
            for (int i=0;i<count;i++)
                data.SomeString = "X";
            watch.Stop();
            Console.WriteLine("Property: " + propertyName);
            Console.WriteLine("Value: " + data.SomeString);
            var time = (double)(watch.ElapsedMilliseconds) / count;
            Console.WriteLine("Time: " + time);
            Console.WriteLine("Slowdown: " + time/etalon);
        }
    }
}



