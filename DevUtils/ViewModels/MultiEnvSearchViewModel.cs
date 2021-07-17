using CommunityToolkit.Mvvm.ComponentModel;
using DevUtils.Contracts.Services;
using DevUtils.Contracts.ViewModels;
using DevUtils.Core.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DevUtils.ViewModels
{
    public class MultiEnvSearchViewModel : ObservableRecipient, INavigationAware
    {
        private readonly INavigationService navigationService;

        public MultiEnvSearchViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public ObservableCollection<DatabaseServer> Databases { get; private set; } = new ObservableCollection<DatabaseServer>();
        public async void OnNavigatedTo(object parameter)
        {
            await Task.Delay(100);
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
