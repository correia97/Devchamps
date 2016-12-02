using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace DevChampsAPP
{
    public class ConjugePageViewModel: INavigationAware
    {
        readonly IBaseApplicationService<Pessoa> _pessoaService;

        public int Idade { get; set; }
        Pessoa Pessoa { get; set; }

        public ConjugePageViewModel(IBaseApplicationService<Pessoa> pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public async Task GetPessoa()
        {
           Pessoa = await _pessoaService.GetById(100);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Pessoa.IdadeConjuge = Idade;
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