using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Digital_Item_Manager
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            navView.SelectedItem = navView.MenuItems[0];
            navView.IsSettingsVisible = false;
            NavigateToPage("app");
        }

        private void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            string tag = args.InvokedItemContainer.Tag.ToString()!;
            NavigateToPage(tag);
        }

        private void NavigateToPage(string tag)
        {
            Type pageType = typeof(AppPage);
            switch (tag)
            {
                case "app":
                    pageType = typeof(AppPage);
                    break;
                case "file":
                    pageType = typeof(FilePage);
                    break;
                case "website":
                    pageType = typeof(WebsitePage);
                    break;
                case "settings":
                    pageType = typeof(SettingsPage);
                    break;
            }

            if (contentFrame.CurrentSourcePageType != pageType)
            {
                contentFrame.Navigate(pageType);
            }
        }
    }
}
