using CommunityToolkit.Mvvm.DependencyInjection;
using DevUtils.ViewModels;
using Microsoft.UI.Xaml.Controls;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevUtils.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DatabasesPage : Page
    {
        public DatabasesViewModel ViewModel { get; }
        public DatabasesPage()
        {
            ViewModel = Ioc.Default.GetService<DatabasesViewModel>();
            this.DataContext = ViewModel;
            this.InitializeComponent();
        }
    }
}
