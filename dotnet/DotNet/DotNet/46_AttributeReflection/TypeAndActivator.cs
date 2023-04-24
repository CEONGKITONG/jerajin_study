using System;

namespace TypeAndActivator
{
    public class MyClass
    {
        public void Test() => Console.WriteLine("MyClass의 Test() 메서드가 실행됩니다.");
    }

    class TypeAndActivator
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("TypeAndActivator.MyClass");

            dynamic objType = Activator.CreateInstance(type);

            objType.Test();
        }
    }
}
