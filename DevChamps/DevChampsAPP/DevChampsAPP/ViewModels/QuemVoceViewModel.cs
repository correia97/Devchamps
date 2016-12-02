using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace DevChampsAPP.ViewModels
{
    public class QuemVoceViewModel : BindableBase
    {
        private readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;
        public QuemVoceViewModel(INavigationService navigationService,
IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

        }
        public int? Idade { get; set; } 
        public string Nome { get; set; } = "";

        public Command Proximo
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(Nome))
                    {
                        await _dialogService.DisplayAlertAsync("Atenção", "Favor Preencher o Campo Nome!!","Ok");
                        return;
                    }


                    if (Idade>0)
                    {
                        await _dialogService.DisplayAlertAsync("Atenção", "Favor Preencher o Campo Idade!!", "Ok");
                        return;
                    }

                    var pessoa = new Pessoa();
                    pessoa.Nome = Nome;
                    pessoa.Idade =(int)Idade;

                    var param = new NavigationParameters { { "Pessoa", pessoa } };
                    await _navigationService.NavigateAsync("DashboardPage", param);

                });
            }
        }
    }
}
