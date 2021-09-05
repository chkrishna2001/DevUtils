using CommunityToolkit.Mvvm.ComponentModel;
using DevUtils.Contracts.ViewModels;
using DevUtils.Core.Contracts.Services;
using DevUtils.Core.Models;
using System.Collections.ObjectModel;

namespace DevUtils.ViewModels
{
    public class ServerViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IDatabaseService databaseService;
        public ServerViewModel(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        private ObservableCollection<DatabaseServer> _DatabaseServers;
        public ObservableCollection<DatabaseServer> DatabaseServers
        {
            get { return _DatabaseServers; }
            set { SetProperty(ref _DatabaseServers, value); }
        }
        public void OnNavigatedFrom()
        {
            throw new System.NotImplementedException();
        }

        public async void OnNavigatedTo(object parameter)
        {
            var servers = await databaseService.Get();
            DatabaseServers = new ObservableCollection<DatabaseServer>(servers);
        }
    }
}
