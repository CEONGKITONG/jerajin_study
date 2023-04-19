using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFHelloWorld2
{
    class MainWindow : Application
    {
        public static void Main(string[] args)
        {
            var thread = new Thread(() =>
            {
                MainWindow app = new MainWindow();
                app.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            // C# 9 에서는 STAThread 특성 지원 안함 (참조 : https://www.sysnet.pe.kr/Default.aspx?mode=2&sub=0&pageno=8&detail=1&wid=12623_)
            //[STAThread]
            //MainWindow app = new MainWindow();
            //app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Window mainWindow = new Window();
            mainWindow.Title = "WPF Sample(Main)";
            mainWindow.MouseDown += WinMouseDown;
            mainWindow.Show();

            for (int i=0; i< 2; i++)
            {
                Window win = new Window();
                win.Title = "Extra Window No. " + (i + 1);
                win.Show();
            }
        }

        void WinMouseDown (Object sender, MouseEventArgs args)
        {
            Window win = new Window();
            win.Title = "Model Dialog Box";
            win.Width = 400; win.Height = 200;

            Button b = new Button();
            b.Content = "Click Me!";
            b.Click += Button_Click;

            win.Content = b;
            win.ShowDialog();
                
        }

        void Button_Click(Object sender, EventArgs args)
        {
            MessageBox.Show("Button Click !!", sender.ToString());
        }


    }
}
