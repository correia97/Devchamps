using Prism.Unity;
using DevChampsAPP.Views;

using Microsoft.Practices.Unity;
using Xamarin.Forms.Xaml;

namespace DevChampsAPP
{
    public class App : PrismApplication
    {
        public static SQLite.SQLiteConnection dbConn { get; set; }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("QuemVocePage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<DashboardPage>();
            Container.RegisterTypeForNavigation<QuemVocePage>();
            Container.RegisterTypeForNavigation<ConjugePage>();
            Container.RegisterTypeForNavigation<AposentadoriaPage>();
            Container.RegisterTypeForNavigation<DependentesPage>();
            Container.RegisterTypeForNavigation<DespesasPage>();
            Container.RegisterTypeForNavigation<PerfilInvestidorPage>();
            Container.RegisterTypeForNavigation<ReservasPage>();
            Container.RegisterTypeForNavigation<NavPage>();
            Container.RegisterTypeForNavigation<ResultadoPage>();

            Container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Container.RegisterType(typeof(IBaseApplicationService<>), typeof(BaseApplicationService<>));
            
            
        }
    }
}