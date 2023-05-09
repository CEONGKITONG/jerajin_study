using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMLogin.Models;
using WPFMVVMLogin.Repositories;

namespace WPFMVVMLogin.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {
                CurrentUserAccount.Username = user.Name;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                // 이렇게 해놓으면 디자인타임에 MainView.xaml을 보려고하면 팝업떠서 오류난다.
                //MessageBox.Show("Invalid user, not logged in");
                //Application.Current.Shutdown();
            }
        }
    }
}
