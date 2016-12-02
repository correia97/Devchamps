using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace DevChampsAPP
{
    public class AposentadoriaPageViewModel: INavigationAware
    {
        readonly IBaseApplicationService<Pessoa> _pessoaService;

        public int Idade { get; set; }
        Pessoa Pessoa { get; set; }

        public AposentadoriaPageViewModel(IBaseApplicationService<Pessoa> pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task GetPessoa()
        {
           Pessoa = await _pessoaService.GetById(100);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Pessoa.Aposentadoria = Idade;
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