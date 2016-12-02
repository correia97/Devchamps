using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Navigation;
using PropertyChanged;

namespace DevChampsAPP.ViewModels
{
    [ImplementPropertyChanged]
    public class DashboardPageViewModel : INavigationAware
    {
        readonly IBaseApplicationService<Menu> _menuService;

        public IList<Menu> Menus { get; set; }

        public DashboardPageViewModel(IBaseApplicationService<Menu> menuService)
        {
            _menuService = menuService;
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
    }
}