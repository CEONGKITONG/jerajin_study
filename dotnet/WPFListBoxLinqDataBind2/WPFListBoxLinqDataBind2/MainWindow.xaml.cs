using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace WPFListBoxLinqDataBind2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static Duties duties = new Duties();

        public MainWindow()
        {
            InitializeComponent();
        }

        // 상단 ListBox의 항목(직무타입)을 선택했을 때
        private void OnSelected(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                string dutyType = ((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString();

                //Linq로 query
                DataContext = from duty in duties
                              where duty.DutyType.ToString() == dutyType
                              select duty;
            }
        }

        private 
    }
}
