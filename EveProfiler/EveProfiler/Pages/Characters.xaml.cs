using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.UI.Core;

namespace EveProfiler.Pages
{
    public partial class Characters : PhoneApplicationPage
    {
        private BusinessLogic.Account ThisAccount = new BusinessLogic.Account();

        public Characters()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataAccess.cEveProfiler callApi = new DataAccess.cEveProfiler();
            Core.ReturnResult rrResult = new Core.ReturnResult();

            //await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
                rrResult = callApi.getCharacterList();
                if (rrResult.Status == HttpStatusCode.OK && rrResult.oReturn != null)
                    ThisAccount.Characters = (List<BusinessLogic.Character.Character>)rrResult.oReturn;
            //});

            CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                for (int i = 0; i < ThisAccount.Characters.Count; i++)
                {
                    CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        rrResult = callApi.getCharacterInfo(ThisAccount.Characters[i].CharacterID);
                        if (rrResult.Status == HttpStatusCode.OK)
                            ThisAccount.Characters[i].CharacterInfo = (BusinessLogic.Character.Info)rrResult.oReturn;
                    });
                }
            });

            string end = string.Empty;
            
            
        }
    }
}