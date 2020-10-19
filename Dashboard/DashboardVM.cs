using Assignment.BO;
using Assignment.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Dashboard
{
    public class DashboardVM : ViewModelBase, IDashboardVM
    {
        private string filterText;
        private CollectionViewSource usersCollection;
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand LogoutCommand { get; set; }

        public DashboardVM()
        {
            ObservableCollection<RegisterBO> users = new ObservableCollection<RegisterBO>();
            //populate users
            List<RegisterBO> myList = new List<RegisterBO>();
            myList = GetEmployeeDetails();
            users = new ObservableCollection<RegisterBO>(myList);
            usersCollection = new CollectionViewSource();
            usersCollection.Source = users;
            usersCollection.Filter += usersCollection_Filter;
            LogoutCommand = new DelegateCommand(Logout);
        }

        public void Logout()
        {
            //var uriQuery = new UriQuery();

            //var uri = new Uri(typeof(LoginView).FullName + uriQuery, UriKind.Relative);
            //_regionManager.RequestNavigate("ContentRegion", uri);
        }

        public ICollectionView SourceCollection
        {
            get
            {
                return this.usersCollection.View;
            }
        }

        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                this.usersCollection.View.Refresh();
                RaisePropertyChanged("FilterText");
            }
        }

        void usersCollection_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            RegisterBO reg = e.Item as RegisterBO;
            if (reg.firstname.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }


        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<RegisterBO> GetEmployeeDetails()
        {
            List<RegisterBO> det = new List<RegisterBO>();
            //write the code here for get the employee list.
            using (var dataReader = AssignmentBLL.Authenticate.GetAllEmployeesList())
            {
                while (dataReader.Read())   // read() moves to next row of read data
                {
                    RegisterBO DetailsModel = new RegisterBO();
                    DetailsModel.firstname = Convert.ToString(dataReader["First Name"]);
                    DetailsModel.lastname = (string)dataReader["Last Name"];
                    DetailsModel.email = (string)dataReader["Email"];
                    DetailsModel.gender = (string)dataReader["Gender"];
                    //DetailsModel.dob = Convert.ToDateTime(dataReader["DOB"]).ToString("dd-mm-yyyy");
                    det.Add(DetailsModel);
                }
                dataReader.Close();
            }
            return det;
        }
    }
}

