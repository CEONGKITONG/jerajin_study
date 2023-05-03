using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFModernDesign.Core
{
    // 알림 속성 Class 정의
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
