using Assignment.BO;
using Assignment.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;

namespace LoginModule
{
    public class RegisterVM : ViewModelBase, IRegisterVM
    {
        DelegateCommand RegisterCommand { get; set; }
        public RegisterVM()
        {
            RegisterCommand = new DelegateCommand(Register, CanRegister);

        }

        private bool CanRegister()
        {
            return true;
        }

        private void Register()
        {
            int result = AssignmentBLL.Authenticate.RegisterEmployee(registerBO);
        }

        private RegisterBO _registerBO;

        public RegisterBO registerBO
        {
            get { return _registerBO; }
            set
            {
                _registerBO = value;
                OnPropertyChanged("loginBO");
            }
        }

        private List<string> _genderlist;

        public List<string> genderlist
        {
            get
            {
                return new List<string>() { "Male", "Female" };
            }
        }


    }
}
