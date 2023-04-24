using System;

public class SampleAttribute : Attribute
{
    public SampleAttribute() => Console.WriteLine("사용자 지정 특성 사용됨");
}

[Sample]
public class CustomAttributeTest { }

class AttributePractice
{
    static void Main(string[] args)
    {
        Attribute.GetCustomAttributes(typeof(CustomAttributeTest));
    }
}