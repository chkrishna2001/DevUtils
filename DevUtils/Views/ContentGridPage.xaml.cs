using CommunityToolkit.Mvvm.DependencyInjection;

using DevUtils.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DevUtils.Views
{
    public sealed partial class ContentGridPage : Page
    {
        public ContentGridViewModel ViewModel { get; }

        public ContentGridPage()
        {
            ViewModel = Ioc.Default.GetService<ContentGridViewModel>();
            InitializeComponent();
        }
    }
}
