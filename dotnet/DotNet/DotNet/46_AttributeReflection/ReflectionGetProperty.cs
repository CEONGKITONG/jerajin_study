using System;
using System.Reflection;

namespace ReflectionGetProperty
{
    class Person
    {
        [Obsolete] public string Name { get; set; }
    }

    class ReflectionGetProperty
    {
        static void Main(string[] args)
        {
            PropertyInfo pi = typeof(Person).GetProperty("Name");

            object[] attributes = pi.GetCustomAttributes(false);

            foreach(var attr in attributes)
            {
                Console.WriteLine("{0}", attr.GetType().Name);
            }
        }
    }
}
