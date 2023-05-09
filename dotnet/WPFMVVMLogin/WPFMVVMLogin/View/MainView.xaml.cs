using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFMVVMLogin.View
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();            
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void pntControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 창 최대 시 윈도우 드래그 했을 때 창 크키가 원복 안되는 현상을 위한 처리 (Window Message 전송)
            WindowInteropHelper helper = new WindowInteropHelper(this);
            // 161 : WM_NCLBUTTONDOWN 커서가 창의 비클라이언트 영역 내에 있는 동안 사용자가 마우스 왼쪽 단추를 누를 때 게시됩니다.
            //  2  : 16 비트
            //  0  : 전송 메세지
            SendMessage(helper.Handle, 161, 2, 0);
            //DragMove();
        }

        private void pntControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal )
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }
    }
}
