using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevChampsAPP.ViewModels
{

    [ImplementPropertyChanged]
    public class ResultadoPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public ResultadoPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

       /// public Resultado Resultado { get; set; }

        public decimal Target { get; set; }
        public decimal Contribuicao { get; set; }
        public decimal DespesaAtual { get; set; }
        public decimal DespesaAposentadoria { get; set; }



        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           // throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            ///throw new NotImplementedException();
        }
    }
}
