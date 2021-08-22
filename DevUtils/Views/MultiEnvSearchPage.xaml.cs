using CommunityToolkit.Mvvm.DependencyInjection;
using DevUtils.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace DevUtils.Views
{
    public sealed partial class MultiEnvSearchPage : Page
    {
        public MultiEnvSearchViewModel ViewModel { get; set; }
        public MultiEnvSearchPage()
        {
            ViewModel = Ioc.Default.GetService<MultiEnvSearchViewModel>();
            this.DataContext = ViewModel;
            
            this.InitializeComponent();
         //    webView.EnsureCoreWebView2Async().GetAwaiter();
         //    webView.NavigateToString(@"<html><head><title>Basic Web Page</title> </head> <body> Hello World! </body> </html>");
           //  ViewModel.WebViewService.Initialize(webView);
        }

        private void cmbProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;

            chkList.Children.Clear();

            var envs = ViewModel.UpdateEnvDetailsByProjectCode(text);
            foreach(var env in envs)
            {
                CheckBox cb = new CheckBox();
                cb.Name = env;
                cb.Padding = new Microsoft.UI.Xaml.Thickness(15, 0, 0, 0);
                cb.Content = env;
                cb.Checked += McCheckBox_Checked;
                cb.Unchecked += McCheckBox_Unchecked;
                chkList.Children.Add(cb);
            }
        }

        private void McCheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void McCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
