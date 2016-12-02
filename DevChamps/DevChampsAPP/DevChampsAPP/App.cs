using Prism.Unity;
using DevChampsAPP.Views;

using Microsoft.Practices.Unity;

namespace DevChampsAPP
{
    public class App : PrismApplication
    {
        public static SQLite.SQLiteConnection dbConn { get; set; }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("DependentesPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<DashboardPage>();
            Container.RegisterTypeForNavigation<QuemVocePage>();
            Container.RegisterTypeForNavigation<ConjugePage>();
            Container.RegisterTypeForNavigation<DependentesPage>();
            Container.RegisterTypeForNavigation<NavPage>();

            Container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Container.RegisterType(typeof(IBaseApplicationService<>), typeof(BaseApplicationService<>));
        }
    }
}