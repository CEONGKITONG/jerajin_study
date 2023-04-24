using System;

public class ButtonClass
{
    public delegate void EventHandler();

    public event EventHandler Click;

    public void OnClick()
    {
        if (Click != null)
        {
            Click();
        }
    }

}


class EventDemo
{
    static void Main(string[] args)
    {
        ButtonClass btn = new ButtonClass();

        btn.Click += Hi1;

        btn.Click += Hi2;

        btn.OnClick();
    }

    static void Hi1() => Console.WriteLine("C#");
    static void Hi2() => Console.WriteLine(".NET");


}