using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDependencyProperty
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        // DependencyProperty(MyProperty)를 위한 래퍼속성 MyColor
        // 이 래퍼속서에서는 System.Windows.DependencyObject 클래스의
        // GetValue와 SetValue() 메서드를 이용해서 get,set 을 정의해야한다.
        public String MyColor 
        {
            get { return (String)GetValue(MyProperty); }
            set { SetValue(MyProperty, value);  }
        }

        public static readonly DependencyProperty MyProperty = DependencyProperty.Register(
            "MyColor",              // 의존속성으로 등록될 속성
            typeof(String),         // 등록할 의존속성 타입
            typeof(MainWindow),     // 의존속성을 소유하게될 owner
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)));       // 속성값 변경 시 호출될메소드
                                                                                                    // 프로퍼티 값의 변경에 따른 Callback 메서드 등 새로운 속성을 추가하기 위해 FrameworkPropertyMetadat를 인자 값으로 전달할 수 있다.

        public MainWindow()
        {
            InitializeComponent();
        }

        private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow win = d as MainWindow;
            SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewValue.ToString());
            win.Background = brush;
            win.Title = (e.OldValue == null) ? "이전배경색 없음" : "배경색 : " + e.OldValue.ToString();
            win.textBox1.Text = e.NewValue.ToString();
        }

        private void ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            string str = (e.Source as MenuItem).Header as string;
            MyColor = str;
        }
    }
}
