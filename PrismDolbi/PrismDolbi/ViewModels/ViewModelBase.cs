using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PrismDolbi.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible,INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
		private string _title=string.Empty;
		bool _propIsBusy;
		string _DateNow = string.Empty;
		protected INavigationService NavigationService { get; private set; }


  //      public ImageSource Image
		//{
		//	get { return ImageSource.FromResource(""); }
		//}
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value,"Title"); }
        }
		public string DateNow
		{
			get { return _DateNow; }
			set { SetProperty(ref _DateNow, value, "DateNow"); }
		}
		public bool IsBusy
		{
			get { return _propIsBusy; }
			set { SetProperty(ref _propIsBusy, value, "IsBusy"); }
		}
		protected void SetProperty<T>(ref T store, T value, string propName, Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(store, value))
				return;
			store = value;
			if (onChanged != null)
				onChanged();
			OnPropertyChanged(propName);
		}
		public void OnPropertyChanged(string propName)
		{
			if (PropertyChanged == null)
				return;
			PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}

		public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
