using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using PrismDolbi.Models;

namespace PrismDolbi.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
		
		INavigationService _navigationService;
		public DelegateCommand NavigateCommand { get; set; }
		public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
			
			_navigationService = navigationService;
			NavigateCommand = new DelegateCommand(Navigate);
		}
		
		private async void Navigate()
		{
			await _navigationService.NavigateAsync("ConArcProd");
		}
	}
}
