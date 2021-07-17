using CommunityToolkit.Mvvm.DependencyInjection;

using DevUtils.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevUtils.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            ViewModel = Ioc.Default.GetService<MainViewModel>();
            InitializeComponent();
        }
    }
}
