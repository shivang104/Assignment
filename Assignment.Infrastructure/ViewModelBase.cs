using Microsoft.Practices.Prism.Regions;
using System.ComponentModel;

namespace Assignment.Infrastructure
{
    public class ViewModelBase : IViewModel, INotifyPropertyChanged, INavigationAware
    {
        private bool _isBusy;

        public bool isBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("isBusy");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
