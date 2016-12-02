using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using PropertyChanged;
using Xamarin.Forms;

namespace DevChampsAPP.ViewModels
{
    [ImplementPropertyChanged]
    public class DashboardPageViewModel : INavigationAware
    {
        readonly IBaseApplicationService<Menu> _menuService;
        readonly INavigationService _navigationService;
        public DelegateCommand<Menu> ItemTappedCommand { get; set; }

        public IList<Menu> Menus { get; set; }

        public DashboardPageViewModel(IBaseApplicationService<Menu> menuService,
                                     INavigationService navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            ItemTappedCommand = new DelegateCommand<Menu>(ItemTapped);
        }

        public Action<Menu> ItemTapped
        {
            get
            {
                return new Action<Menu>(async (menu) =>
                {
                    await Navigate(menu.Descricao);
                });
            }
        }

        public async Task MontaMenu()
        {
            Menus = await _menuService.GetAll();
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            await MontaMenu();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public async Task Navigate(string page)
        {
            var navPag = string.Empty;

            switch (page)
            {
                case "Cônjuge":
                    navPag = "ConjugePage";
                    break;
                case "Depentendes":
                    navPag = "DependentesPage";
                    break;
                case "Aposentadoria":
                    navPag = "AposentadoriaPage";
                    break;
                case "Despesas":
                    navPag = "DespesasPage";
                    break;
                case "Perfil Investidor":
                    navPag = "PerfilInvestidorPage";
                    break;
                case "Reservas":
                    navPag = "ReservasPage";
                    break;
            }

            await _navigationService.NavigateAsync($"{navPag}");
        }
    }
}