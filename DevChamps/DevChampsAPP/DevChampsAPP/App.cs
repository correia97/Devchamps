using Prism.Unity;
using DevChampsAPP.Views;

using Microsoft.Practices.Unity;

namespace DevChampsAPP
{
    public class App : PrismApplication
    {
        public static SQLite.SQLiteConnection dbConn { get; set; }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();

            Container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Container.RegisterType(typeof(IBaseApplicationService<>), typeof(BaseApplicationService<>));
        }
    }
}