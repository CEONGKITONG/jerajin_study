using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class NickNameAttribute : Attribute
{
    public string   Name { get; set; }
    public NickNameAttribute(string name) { Name = name; }
}

[NickName("길벗")]
[NickName("RedPlus")]
class NickNameAttributeTest
{
    static void Main() => ShowMetaData();

    static void ShowMetaData()
    {
        Attribute[] attrs = Attribute.GetCustomAttributes(typeof(NickNameAttributeTest));
        foreach( var attr in attrs)
        {
            if (attr is NickNameAttribute)
            {
                NickNameAttribute ais = (NickNameAttribute)attr;

                Console.WriteLine("{0}", ais.Name);
            }

            NickNameAttribute aas = attr as NickNameAttribute;

            if (aas != null)
            {
                Console.WriteLine("{0}", aas.Name);
            }
        }
    }
    
}