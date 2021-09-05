using CommunityToolkit.Mvvm.DependencyInjection;
using DevUtils.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

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


        private void McCheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void McCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
