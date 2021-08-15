using Microsoft.Extensions.DependencyInjection;
using RickAndMorthy.Services;
using RickAndMorthy.Views.Character;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Menu = RickAndMorthy.Model.Menu;

namespace RickAndMorthy.ViewModel.Submenu
{
    public class SideBarViewModel : BaseViewModel
    {
        /// <summary>Navigation Service</summary>
        readonly NavigationService navigation;
        /// <summary>Loggin Service</summary>
        readonly LoggingService logging;

        ObservableCollection<Menu> menu;
        public ObservableCollection<Menu> Menu { get => menu; set => SetProperty(ref menu, value); }
        public ICommand NavigatePageCommand { get; set; }

        public SideBarViewModel(NavigationService navigation, LoggingService logging)
        {
            this.navigation = navigation;
            this.logging = logging;

            NavigatePageCommand = new Command<Menu>(async option => await this.NavigatePage(option));

            this.LoadOptionsOfMenu();
        }

        /// <summary>
        /// it allows to load all the availables options of the menu for the app
        /// </summary>
        void LoadOptionsOfMenu()
        {
            this.Menu = new ObservableCollection<Menu>();
            this.Menu.Add(new Menu() { Icon = "", Page = App.ServiceProvider.GetService<CharactersView>() });
        }

        /// <summary>
        /// it allows to nav to another page
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        async Task NavigatePage(Menu option)
        {
            try
            {
                await this.navigation.PushAsync(option.Page);
            }
            catch (Exception ex)
            {
                this.logging.Log(this, Microsoft.AppCenter.LogLevel.Error, ex);
            }
        }    
    }
}
