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

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            ViewModel.LoadCmd.Execute(null);

        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            ViewModel.LogoutCmd.Execute(null);
            e.Handled = true;
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.OpenMapCmd.Execute(e.ClickedItem);
        }

        private void SearchListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.InviteToFriendsCmd.Execute(e.ClickedItem);
        }

        private void UIElement_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter) ViewModel.SearchCmd.Execute(null);
        }

        private void DescriptionUIElement_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter) ViewModel.UpgdareUserDescOrPhotoCmd.Execute(null);
        }
    }
}
