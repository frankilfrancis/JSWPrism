using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Prism.Navigation;
using PrismDolbi.Models;
using PrismDolbi.Abstractions;
using Prism.Services;
using Microsoft.AppCenter.Crashes;

namespace PrismDolbi.ViewModels
{
	public class ConArcProdViewModel : ViewModelBase
	{
		ICloudService service;
		IPageDialogService pageDialogService;
		public ConArcProdViewModel(INavigationService navigationService , ICloudService _service, IPageDialogService _pageDialogService ) : base(navigationService)
		{
			service = _service;
			pageDialogService = _pageDialogService;
			Title = "Production Summary";
			DateNow = string.Format("Update Time: - {0}",DateTime.Today.ToString("d"));
			RefreshList();
		}
		ObservableCollection<ConArcProd> items = new ObservableCollection<ConArcProd>();
		public ObservableCollection<ConArcProd> Items
		{
			get { return items; }
			set { SetProperty(ref items, value, "Items"); }
		}

		string updateDateTim = string.Format("Update Time: - {0}", DateTime.Today.ToString("d"));
		public string RefreshTime
		{
			get { return updateDateTim; }
			set { SetProperty(ref updateDateTim, value, "RefreshTime"); }
		}

		ConArcProd selectedItem;
		public ConArcProd SelectedItem
		{
			get { return selectedItem; }
			set
			{
				SetProperty(ref selectedItem, value, "SelectedItem");
				if (selectedItem != null)
				{
					//Application.Current.MainPage.Navigation.PushAsync(new Pages.TaskDetail(selectedItem));
					SelectedItem = null;
				}
			}
		}
		Command refreshCmd;
		public Command RefreshCommand => refreshCmd ?? (refreshCmd = new Command(async () => await ExecuteRefreshCommand()));

		async Task ExecuteRefreshCommand()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			try
			{

				//var table = App.CloudService.GetTable<ConArcProd>();
				var table = service.GetTable<ConArcProd>();
				var list = await table.ReadAllItemsAsync();
				if (list.Count > 0)
				{
					Items.Clear();
					foreach (var item in list.OrderBy(x => x.SHOW_INDEX))
						Items.Add(item);
				}
				else
				{
					 await pageDialogService.DisplayAlertAsync("Error", "Something Went Wrong Refresh Again", "Try Again");
					
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[ConArcProd] Error loading items: {ex.Message}");
				Crashes.TrackError(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
		private async void RefreshList()
		{
			await ExecuteRefreshCommand();

			await GetRefreshTime();
		}

		private async Task GetRefreshTime()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			try
			{
				var table =service.GetTable<ConArcProd>();
				var list = await table.ReadAllItemsAsync();
				var UpdateTime = list.Select(x => x.DATE_TIME).FirstOrDefault().ToString();
				RefreshTime = string.Format("Update Time: - {0}", UpdateTime.Substring(0,16));
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[ConArcProd] Error loading in DateTime: {ex.Message}");
				Crashes.TrackError(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
