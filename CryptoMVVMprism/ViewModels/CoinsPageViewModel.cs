using CryptoMVVMprism.Helpers;
using CryptoMVVMprism.Interfaces;
using CryptoMVVMprism.Models;
using Prism.Commands;
using Prism.Navigation;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CryptoMVVMprism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CoinsPageViewModel
    {
        public ObservableCollection<Grouping<string, CoinsModel>> CoinsGrouped { get; set; }
        public ObservableCollection<CoinsModel> coinsModel { get; set; }
        public List<CoinsModel> coinsModelList { get; set; }
        public List<CoinsModel> SearchList { get; set; }
        private ICoins _icoins;
        public INavigationService NavigationService { get; set; }
        public DataTemplate groupHeader { get; set; }
        private DelegateCommand<string> _textChangedCommand { get; set; }
        public DelegateCommand<string> TextChangedCommand =>
            _textChangedCommand ?? (_textChangedCommand = new DelegateCommand<string>(TextChanged));

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; }
        }

        private void TextChanged(string obj)
        {
            var searchResult = coinsModelList.Where(c => c.Name.ToLower().Contains(obj.ToLower()));
            SearchList = new List<CoinsModel>((IEnumerable<CoinsModel>)searchResult);
            GroupCoins(SearchList);
        }

        public CoinsPageViewModel(ICoins coins, INavigationService navigationService)
        {
            coinsModel = new ObservableCollection<CoinsModel>();
            _icoins = coins;
            CoinsGrouped = new ObservableCollection<Grouping<string, CoinsModel>>();
            IsBusy = true;
            LoadCoins();
            NavigationService = navigationService;
        }

        public async void LoadCoins()
        {
            var coins = await _icoins.GetCoinsList();
            GroupCoins(coins);
            IsBusy = false;
            foreach (var coin in coins)
            {
                coinsModel.Add(coin);
            }
            coinsModelList = new List<CoinsModel>(coinsModel);

            if (Device.OS != TargetPlatform.WinPhone)
                groupHeader = new DataTemplate(typeof(HeaderCell));
        }

        private CoinsModel _selectedCoin;
        public CoinsModel SelectedCoin
        {
            get => null;
            set
            {
                _selectedCoin = value;
                if (_selectedCoin != null)
                {
                    var navigationParamaters = new NavigationParameters();
                    navigationParamaters.Add("coinsid", _selectedCoin.Id);
                    NavigationService.NavigateAsync("CoinsDetailsPage", navigationParamaters);
                }
            }
        }

        private void GroupCoins(List<CoinsModel> listOfCoins)
        {
            var sorted = from coin in listOfCoins
                         orderby coin.Name
                         group coin by coin.NameSort into coinGroup
                         select new Grouping<string, CoinsModel>(coinGroup.Key, coinGroup);
            CoinsGrouped = new ObservableCollection<Grouping<string, CoinsModel>>(sorted);
        }
    }
}
