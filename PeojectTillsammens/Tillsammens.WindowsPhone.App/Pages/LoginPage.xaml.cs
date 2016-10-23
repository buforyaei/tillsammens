using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tillsammens.WindowsPhone.App.ViewModel;


namespace Tillsammens.WindowsPhone.App.Pages
{
    public sealed partial class LoginPage : Page
    {
        private LoginViewModel ViewModel
        {
            get { return DataContext as LoginViewModel; }
        }
        public LoginPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           ViewModel.LoadCmd.Execute(null);
        }
    }
}
