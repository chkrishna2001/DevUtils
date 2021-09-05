using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevUtils.Contracts.Services;
using DevUtils.Contracts.ViewModels;
using DevUtils.Core.Contracts;
using DevUtils.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DevUtils.ViewModels
{
    public class MultiEnvSearchViewModel : ObservableRecipient, INavigationAware
    {
        private readonly INavigationService navigationService;
        private readonly IMultiEnvSearchService multiEnvSearchService;

        public MultiEnvSearchViewModel(INavigationService navigationService, IMultiEnvSearchService multiEnvSearchService)
        {
            this.navigationService = navigationService;
            this.multiEnvSearchService = multiEnvSearchService;
        }

        private ObservableCollection<DatabaseServer> _DatabaseServers;
        public ObservableCollection<DatabaseServer> DatabaseServers
        {
            get { return _DatabaseServers; }
            set { SetProperty(ref _DatabaseServers, value); }
        }


        private ObservableCollection<string> _Databases;
        public ObservableCollection<string> Databases
        {
            get { return _Databases; }
            set { SetProperty(ref _Databases, value); }
        }


        private string _SelectedDatabase;
        public string SelectedDatabase
        {
            get { return _SelectedDatabase; }
            set { SetProperty(ref _SelectedDatabase, value); }
        }


        public ObservableCollection<string> Env { get; private set; } = new ObservableCollection<string>();
        public void OnNavigatedFrom()
        {
            // WebViewService.NavigationCompleted -= OnNavigationCompleted;
        }

        public async void OnNavigatedTo(object parameter)
        {
            var servers = await multiEnvSearchService.GetDatabaseServers();
            DatabaseServers = new ObservableCollection<DatabaseServer>(servers);
            Databases = new ObservableCollection<string>(servers.Select(m => m.DatabaseName).Distinct());
            html = new Uri("https://www.google.com/");
        }

        public Uri html { get; set; }

        private ICommand _DatabasesClickCommand;
        public ICommand DatabasesClickCommand => _DatabasesClickCommand ?? (_DatabasesClickCommand = new RelayCommand(OnDatabasesClick));
        private void OnDatabasesClick()
        {
            navigationService.NavigateTo<DatabasesViewModel>();
        }

    }
}
