using Prism;
using Prism.Ioc;
using PrismDolbi.Abstractions;
using PrismDolbi.ViewModels;
using PrismDolbi.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismDolbi
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

		//public static ICloudService CloudService { get;  set; }

		protected override async void OnInitialized()
        {
            InitializeComponent();
			//CloudService = new AzureCloudService();
			AppCenter.Start("android=dd830de8-6bc6-47d2-a4a5-b54acf52de93;",
				  typeof(Analytics), typeof(Crashes));
			await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
			containerRegistry.RegisterForNavigation<ConArcProd>();


			// services 

			containerRegistry.RegisterSingleton<ICloudService, AzureCloudService>();
		}
    }
}
