using Assignment.BO;
using Assignment.Infrastructure;
using Dashboard;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;

namespace LoginModule
{
    public class LoginVM : ViewModelBase, ILoginVM
    {
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand LoginNavCommand { get; set; }
        public DelegateCommand NextButtonDelegateCommand { get; set; }
        public DelegateCommand LoginAuthenticateCommand { get; set; }
        private IRegionManager _regionManager;
        public LoginVM(IRegionManager regionManager)
        {
            LoginCommand = new DelegateCommand(Login, CanLogin);
            LoginNavCommand = new DelegateCommand(LoginNav);
            NextButtonDelegateCommand = new DelegateCommand(NextScreen);
            LoginAuthenticateCommand = new DelegateCommand(GoToDashboard);
            _regionManager = regionManager;
            _loginBO = new LoginBO();

            _loginBO.username = "ABC";
        }

        public void LoginNav()
        {
            var uriQuery = new UriQuery();

            var uri = new Uri(typeof(LoginView).FullName + uriQuery, UriKind.Relative);
            _regionManager.RequestNavigate("ContentRegion", uri);
        }

        public void GoToDashboard()
        {
            var uriQuery = new UriQuery();

            var uri = new Uri(typeof(DashboardView).FullName + uriQuery, UriKind.Relative);
            _regionManager.RequestNavigate("ContentRegion", uri);
        }

        public void NextScreen()
        {
            var uriQuery = new UriQuery();

            var uri = new Uri(typeof(RegisterView).FullName + uriQuery, UriKind.Relative);
            _regionManager.RequestNavigate("ContentRegion",uri);
           
        }

        private void Login()
        {
            bool result = AssignmentBLL.Authenticate.AuthenticateLogin(loginBO);
            if (result == true)
            {
                GoToDashboard();
            }
        }

        private bool CanLogin()
        {
            return true;
        }

        private LoginBO _loginBO;

        public LoginBO loginBO
        {
            get { return _loginBO; }
            set
            {
                _loginBO = value;
                OnPropertyChanged("loginBO");
            }
        }
       
    }
}
