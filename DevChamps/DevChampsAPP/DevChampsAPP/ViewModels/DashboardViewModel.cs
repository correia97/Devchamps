using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;

namespace DevChampsAPP.ViewModels
{
    [ImplementPropertyChanged]
    public class DashboardViewModel : INavigationAware
    {
        readonly IBaseApplicationService<Pessoa> _pessoaService;
        readonly IBaseApplicationService<Menu> _menuService;

        public IList<Menu> Menus { get; set; }

        public DashboardViewModel(IBaseApplicationService<Pessoa> pessoaService,
                                  IBaseApplicationService<Menu> menuService)
        {
            _pessoaService = pessoaService;
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