using System;
using System.ComponentModel;

namespace Assignment.BO
{
    public class RegisterBO : INotifyPropertyChanged
    {
        private string _firstname;

        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        private string _lastname;

        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private string _gender;

        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateTime _dob;

        public DateTime dob
        {
            get { return _dob; }
            set { _dob = value; }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _confirmpassword;

        public string confirmpassword
        {
            get { return _confirmpassword; }
            set { _confirmpassword = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
