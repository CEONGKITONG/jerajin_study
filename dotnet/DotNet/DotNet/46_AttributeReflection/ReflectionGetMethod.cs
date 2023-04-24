using System;
using System.Reflection;

namespace ReflectionGetMethod
{
    public class MemberClass
    {
        public string Name { get; set; } = "길벗출판사";
        public string GetName()
        {
            return Name + ", " + DateTime.Now.ToShortDateString();
        }
    }

    class ReflectionGetMethod
    {
        static void Main(string[] args)
        {
            MemberClass m = new MemberClass();
            Type t = m.GetType();
            
            PropertyInfo pi = t.GetProperty("Name");

            Console.WriteLine("속성 호출 : {0} ", pi.GetValue(m));

            MethodInfo mi = t.GetMethod("GetName");

            Console.WriteLine("메서드 호출 : {0}", mi.Invoke(m, null));

            dynamic d = new MemberClass();

            Console.WriteLine("속성 호출 : {0}", d.Name);

            Console.WriteLine("메서드 호출 : {0}", d.GetName());
        }
        
    }
}
