using System.ComponentModel;

namespace Assignment.BO
{
    public class LoginBO : INotifyPropertyChanged
    {
        private string _username;

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
