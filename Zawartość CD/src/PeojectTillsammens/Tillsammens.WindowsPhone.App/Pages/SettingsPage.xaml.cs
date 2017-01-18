using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.System;
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
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private SettingsViewModel ViewModel
        {
            get { return DataContext as SettingsViewModel; }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            ViewModel.GoBack();
            e.Handled = true;
        }

        private void NewPasswordSecond_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Tab)
            {
                ViewModel.ChangePasswordCmd.Execute(new [] 
                    {OldPassword.Password, NewPassword.Password, NewPasswordSecond.Password});
                NewPassword.Password = string.Empty;
                NewPasswordSecond.Password = string.Empty;
                OldPassword.Password = string.Empty;
            }
        }

        private void NewPassword_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Tab) NewPasswordSecond.Focus(FocusState.Keyboard);
        }

        private void OldPassword_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Tab) NewPassword.Focus(FocusState.Keyboard);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.ChangePasswordCmd.Execute(new[]
                 {OldPassword.Password, NewPassword.Password, NewPasswordSecond.Password});
            NewPassword.Password = string.Empty;
            NewPasswordSecond.Password = string.Empty;
            OldPassword.Password = string.Empty;
        }

        private void ChangePasswordButton_OnClick(object sender, RoutedEventArgs e)
        {
           ViewModel.ChangePasswordsVisCmd.Execute(null);
        }
    }
}
