using CryptoMVVMprism.Interfaces;
using CryptoMVVMprism.Models;
using Prism.Navigation;
using PropertyChanged;
using Xamarin.Forms;

namespace CryptoMVVMprism.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class CoinsDetailsPageViewModel : INavigationAware
    {
        private string coinId;
        private ICoins _icoins;
        private CoinsDetailModel coinsDetail;

        private string _coinDescription;

        private string _coinsImage;

        public string CoinImage
        {
            get { return _coinsImage; }
            //set {SetProperty (ref _coinsImage, value); }
            set { _coinsImage = value; }
        }

        public string CoinDescription
        {
            get { return _coinDescription; }
            set { _coinDescription = value; }
            // set { SetProperty(ref _coinDescription, value); }
        }

        private string _coinSymbol;

        public string CoinSymbol
        {
            get { return _coinSymbol; }
            set { _coinSymbol = value; }
        }

        private string _coinName;

        public string CoinName
        {
            get { return _coinName; }
            set { _coinName = value; }
        }

        private string _coinPrice;

        public string CoinPrice
        {
            get { return _coinPrice; }
            set { _coinPrice = value; }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; }
        }
        public CoinsDetailsPageViewModel(ICoins icoins)
        {
            _icoins = icoins;
            NavigationPage page = App.Current.MainPage as NavigationPage;
            page.BarBackgroundColor = Color.FromHex("427ad4");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            coinId = (string)parameters["coinsid"];
            coinsDetail = await _icoins.GetCoinsDetails(coinId);
            AssignValues();

        }

        private void AssignValues()
        {
            CoinImage = coinsDetail.imageModel.Thumb;
            CoinDescription = coinsDetail.Description.En;
            CoinName = coinsDetail.Name;
            CoinPrice = coinsDetail.MarketData.CurrentPrice.Usd.ToString();
            CoinSymbol = coinsDetail.Symbol;
            IsBusy = false;
        }
    }
}
