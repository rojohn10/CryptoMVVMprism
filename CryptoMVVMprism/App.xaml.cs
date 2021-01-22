using CryptoMVVMprism.Interfaces;
using CryptoMVVMprism.Services;
using CryptoMVVMprism.ViewModels;
using CryptoMVVMprism.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace CryptoMVVMprism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            await NavigationService.NavigateAsync("NavigationPage/CoinsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            //containerRegistry.RegisterForNavigation<CoinsPage, CoinsPageViewModel>();
            containerRegistry.RegisterForNavigation<CoinsPage>();
            containerRegistry.RegisterSingleton<ICoins, ApiServices>();
            containerRegistry.RegisterForNavigation<CoinsDetailsPage, CoinsDetailsPageViewModel>();
        }
    }
}
