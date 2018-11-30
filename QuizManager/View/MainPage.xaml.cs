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
using QuizManager.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QuizManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            // Load Main.xaml in the main frame of MainPage.xaml
            MainFrame.Navigate(typeof(ViewBasementDate));

        }


        //Set SplitViewMenu to what it currently is not
        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.IsPaneOpen = !SplitViewMenu.IsPaneOpen;
        }



        // Check if you can go forward ?? Go forward ..
        private void GoForwardButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward)
            {
                MainFrame.GoForward();
            }
        }

        // Check if you can go backward ?? Go backward ..
        private void GoBackButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        // Menu control
            private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (BasementButton.IsSelected)
                {
                    MainFrame.Navigate(typeof(ViewBasementDate));
                    YouAreHere.Text = "Basement";

                }
                else if (AlpehyttenButton.IsSelected)
                {
                    MainFrame.Navigate(typeof(ViewAlpehyttenDate));
                    YouAreHere.Text = "Alpehytten";
                    if (SplitViewMenu.IsPaneOpen) SplitViewMenu.IsPaneOpen = false;
                }
                else if (ShowStatistics.IsSelected)
                {
                    MainFrame.Navigate(typeof(ViewStatistics));
                    YouAreHere.Text = "Statistik: ";
                    if (SplitViewMenu.IsPaneOpen) SplitViewMenu.IsPaneOpen = false;

                }
                else if (ShowSettings.IsSelected)
                {
                    MainFrame.Navigate(typeof(ViewSettings));
                    YouAreHere.Text = "Indstillinger";
                    if (SplitViewMenu.IsPaneOpen) SplitViewMenu.IsPaneOpen = false;

                }
            }
    }
}
