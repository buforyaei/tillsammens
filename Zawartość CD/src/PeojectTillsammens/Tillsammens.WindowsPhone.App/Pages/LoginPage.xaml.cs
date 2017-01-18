using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
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

            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            LoginBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
            if (e.Parameter is bool && (bool)e.Parameter)
            {
                Application.Current.Exit();
            }
            else
            {
                ViewModel.LoadCmd.Execute(null);
            }
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
           
        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Application.Current.Exit();
            e.Handled = true;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.LoginCmd.Execute(new[] {LoginBox.Text, PasswordBox.Password});
            LoginBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
        }

        private void LoginBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Tab) PasswordBox.Focus(FocusState.Keyboard);
        }

        private void PasswordBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                ViewModel.LoginCmd.Execute(new[] { LoginBox.Text, PasswordBox.Password });
                LoginBox.Text = string.Empty;
                PasswordBox.Password = string.Empty;
            }

        }
    }
}
