using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using Xamarin.Forms;

namespace DevChampsAPP.ViewModels
{
    public class QuemVocePageViewModel : BindableBase
    {
        private readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private readonly IBaseApplicationService<Pessoa> _service;
        public QuemVocePageViewModel(INavigationService navigationService,
                                        IPageDialogService dialogService,
                                        IBaseApplicationService<Pessoa> service)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _service = service;

        }
        public string Idade { get; set; }
        public string Nome { get; set; } = "";

        public Command Proximo
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(Nome))
                    {
                        await _dialogService.DisplayAlertAsync("Atenção", "Favor Preencher o Campo Nome!!", "Ok");
                        return;
                    }


                    if (string.IsNullOrEmpty(Idade) && Convert.ToInt32(Idade) <= 0)
                    {
                        await _dialogService.DisplayAlertAsync("Atenção", "Favor Preencher o Campo Idade!!", "Ok");
                        return;
                    }

                    var pessoa = new Pessoa();
                    pessoa.Nome = Nome;
                    pessoa.Idade = Convert.ToInt32(Idade);
                    pessoa.Id = 100;
                    _service.Insert(pessoa);
                    

                    var param = new NavigationParameters { { "Pessoa", pessoa } };
                    await _navigationService.NavigateAsync("DashboardPage", param);

                });
            }
        }
    }
}
