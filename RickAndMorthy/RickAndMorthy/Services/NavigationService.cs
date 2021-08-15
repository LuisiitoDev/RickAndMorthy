﻿using System.Threading.Tasks;
using Xamarin.Forms;

namespace RickAndMorthy.Services
{
    public class NavigationService
    {
        /// <summary>
        /// it allows to push to new page in the navigation page stack
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task PushAsync(Page page)
        {
            if (App.Current.MainPage is NavigationPage nav)
                await nav.PushAsync(page, animated: true);

            if (App.Current.MainPage is MasterDetailPage master)
                await master.Navigation.PushAsync(page, animated: true);
        }

        /// <summary>
        /// it allows to pop to the previous page
        /// </summary>
        /// <returns></returns>
        public async Task PopAsync()
        {
            if (App.Current.MainPage is NavigationPage nav)
                await nav.PopAsync();

            if (App.Current.MainPage is MasterDetailPage master)
                await master.Navigation.PopAsync();
        }
    }
}
