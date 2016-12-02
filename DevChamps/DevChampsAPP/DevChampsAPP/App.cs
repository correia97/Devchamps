﻿using Prism.Unity;
using DevChampsAPP.Views;

using Microsoft.Practices.Unity;

namespace DevChampsAPP
{
    public class App : PrismApplication
    {
        public static SQLite.SQLiteConnection dbConn { get; set; }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("DashboardPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<DashboardPage>();

            Container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Container.RegisterType(typeof(IBaseApplicationService<>), typeof(BaseApplicationService<>));
        }
    }
}