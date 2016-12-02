using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace DevChampsAPP
{
    public class PerfilInvestidorPageViewModel: INavigationAware
    {
        readonly IBaseApplicationService<Pessoa> _pessoaService;

        public int PerfilInv { get; set; }
        Pessoa Pessoa { get; set; }

        public PerfilInvestidorPageViewModel(IBaseApplicationService<Pessoa> pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task GetPessoa()
        {
           Pessoa = await _pessoaService.GetById(100);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Pessoa.PerfilInvestimento = PerfilInv;
            _pessoaService.Update(Pessoa);
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {   }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            await GetPessoa();
        }
    }
}