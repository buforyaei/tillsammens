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
    public sealed partial class CreateAccountPage : Page
    {
        public CreateAccountPage()
        {
            this.InitializeComponent();
        }
        private CreateAccountViewModel ViewModel
        {
            get { return DataContext as CreateAccountViewModel; }
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.CreateAccountCmd.Execute(new [] {Login.Text, PasswordBoxFirst.Password, PasswordBoxSecond.Password});
        }

        private void LoginUIElement_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Tab) PasswordBoxFirst.Focus(FocusState.Keyboard);
        }

        private void PasswordBoxFirst_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Tab) PasswordBoxSecond.Focus(FocusState.Keyboard);
        }

        private void PasswordBoxSecond_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Tab)
            {
                ViewModel.CreateAccountCmd.Execute(
                    new[] { Login.Text, PasswordBoxFirst.Password, PasswordBoxSecond.Password });
            }
        }
    }
}
