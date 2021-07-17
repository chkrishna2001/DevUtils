using CommunityToolkit.Mvvm.DependencyInjection;
using DevUtils.ViewModels;
using Microsoft.UI.Xaml.Controls;


namespace DevUtils.Views
{
    public sealed partial class MultiEnvSearchPage : Page
    {
        public MultiEnvSearchViewModel ViewModel { get; set; }
        public MultiEnvSearchPage()
        {
            ViewModel = Ioc.Default.GetService<MultiEnvSearchViewModel>();
            this.InitializeComponent();
        }
    }
}
