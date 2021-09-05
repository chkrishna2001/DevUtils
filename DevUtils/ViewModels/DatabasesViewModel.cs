using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevUtils.Contracts.Services;
using DevUtils.Contracts.ViewModels;
using DevUtils.Core.Contracts.Services;
using DevUtils.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevUtils.ViewModels
{
    public class DatabasesViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IDatabaseService databaseService;
        private readonly INavigationService navigationService;

        public DatabasesViewModel(IDatabaseService databaseService, INavigationService navigationService)
        {
            this.databaseService = databaseService;
            this.navigationService = navigationService;
            StorageTypes = new List<LookupItem>
            {
                new LookupItem { ItemName = "Table", ItemValue = "Table" },
                new LookupItem { ItemName = "Document", ItemValue = "Document" }
            };
        }
        private ObservableCollection<DatabaseServer> _DatabaseServers;
        public ObservableCollection<DatabaseServer> DatabaseServers
        {
            get { return _DatabaseServers; }
            set { SetProperty(ref _DatabaseServers, value); }
        }
        public List<LookupItem> StorageTypes { get; set; }

        private ObservableCollection<DatabaseEnvironment> _DatabaseEnvironments;
        public ObservableCollection<DatabaseEnvironment> DatabaseEnvironments
        {
            get { return _DatabaseEnvironments; }
            set { SetProperty(ref _DatabaseEnvironments, value); }
        }

        private DatabaseServer _SelectedDatabase;
        public DatabaseServer SelectedDatabase
        {
            get { return _SelectedDatabase; }
            set
            {
                SetProperty(ref _SelectedDatabase, value);
                DatabaseName = SelectedDatabase.DatabaseName;
                DbServerName = SelectedDatabase.DbServerName;
                StorageType = SelectedDatabase.StorageType;
                DatabaseId = SelectedDatabase.Id;
                LoadEnvironments();
                ((RelayCommand)DatabaseSaveClickCommand).NotifyCanExecuteChanged();
            }
        }
        private DatabaseEnvironment _SelectedDatabaseEnvironment;
        public DatabaseEnvironment SelectedDatabaseEnvironment
        {
            get { return _SelectedDatabaseEnvironment; }
            set
            {
                SetProperty(ref _SelectedDatabaseEnvironment, value);
                EnvName = SelectedDatabaseEnvironment.Name;
                ConnectionString = SelectedDatabaseEnvironment.ConnectionString;
            }
        }

        #region DatabaseServer individual properties
        private string _DatabaseName;
        public string DatabaseName
        {
            get { return _DatabaseName; }
            set
            {
                SetProperty(ref _DatabaseName, value);
                ((RelayCommand)DatabaseSaveClickCommand).NotifyCanExecuteChanged();
            }
        }

        private string _DbServerName;
        public string DbServerName
        {
            get { return _DbServerName; }
            set
            {
                SetProperty(ref _DbServerName, value);
                ((RelayCommand)DatabaseSaveClickCommand).NotifyCanExecuteChanged();
            }
        }

        private string _StorageType;
        public string StorageType
        {
            get { return _StorageType; }
            set
            {
                SetProperty(ref _StorageType, value);
                ((RelayCommand)DatabaseSaveClickCommand).NotifyCanExecuteChanged();
            }
        }
        #endregion


        #region Database Environment Individual properties

        private int _DatabaseId;
        public int DatabaseId
        {
            get { return _DatabaseId; }
            set { SetProperty(ref _DatabaseId, value); }
        }

        private string _EnvName;
        public string EnvName
        {
            get { return _EnvName; }
            set
            {
                SetProperty(ref _EnvName, value);
                ((RelayCommand)EnvironmentSaveClickCommand).NotifyCanExecuteChanged();
            }
        }

        private string _ConnectionString;
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                SetProperty(ref _ConnectionString, value);
                ((RelayCommand)EnvironmentSaveClickCommand).NotifyCanExecuteChanged();
            }
        }
        #endregion


        public void OnNavigatedFrom()
        {

        }

        public async void OnNavigatedTo(object parameter)
        {
            await LoadDatabaseServers();
        }
        public async Task LoadDatabaseServers()
        {
            var servers = await databaseService.Get();
            DatabaseServers = new ObservableCollection<DatabaseServer>(servers);
        }
        public async Task LoadEnvironments()
        {
            var environments = await databaseService.GetEnvs(SelectedDatabase.Id);
            DatabaseEnvironments = new ObservableCollection<DatabaseEnvironment>(environments);
        }

        private async void OnDatabaseSaveClick()
        {
            await databaseService.AddOrUpdate(new DatabaseServer()
            {
                Id = SelectedDatabase != null ? SelectedDatabase.Id : 0,
                DatabaseName = DatabaseName,
                DbServerName = DbServerName,
                StorageType = StorageType
            });
            await LoadDatabaseServers();
        }

        private ICommand _EnvironmentSaveClickCommand;
        public ICommand EnvironmentSaveClickCommand => _EnvironmentSaveClickCommand ?? (_EnvironmentSaveClickCommand = new RelayCommand(OnEnvironmentSaveClick, () =>
        {
            return DatabaseId != 0 && !string.IsNullOrWhiteSpace(EnvName) && !string.IsNullOrWhiteSpace(ConnectionString);
        }));
        private async void OnEnvironmentSaveClick()
        {
            await databaseService.AddOrUpdateEnv(new DatabaseEnvironment()
            {
                Id = SelectedDatabaseEnvironment != null ? SelectedDatabaseEnvironment.Id : 0,
                DatabaseId = DatabaseId,
                Name = EnvName,
                ConnectionString = ConnectionString
            });
            await LoadEnvironments();
        }

        private ICommand _DatabaseSaveClickCommand;
        public ICommand DatabaseSaveClickCommand => _DatabaseSaveClickCommand ?? (_DatabaseSaveClickCommand = new RelayCommand(OnDatabaseSaveClick, () =>
        {
            return !string.IsNullOrWhiteSpace(DatabaseName) &&
            !string.IsNullOrWhiteSpace(DbServerName) &&
            !string.IsNullOrWhiteSpace(StorageType);
        }));

        private ICommand _DatabaseAddClickCommand;
        public ICommand DatabaseAddClickCommand => _DatabaseAddClickCommand ?? (_DatabaseAddClickCommand = new RelayCommand(OnDatabaseAddClick));
        private void OnDatabaseAddClick()
        {
            DatabaseName = DbServerName = StorageType = string.Empty;
        }

        private ICommand _EnvironmentAddClickCommand;
        public ICommand EnvironmentAddClickCommand => _EnvironmentAddClickCommand ?? (_EnvironmentAddClickCommand = new RelayCommand(OnEnvironmentAddClick));
        private void OnEnvironmentAddClick()
        {
            DatabaseId = 0;
            EnvName = string.Empty;
            ConnectionString = string.Empty;
        }

        private ICommand _EnvironmentDeleteClickCommand;
        public ICommand EnvironmentDeleteClickCommand => _EnvironmentDeleteClickCommand ?? (_EnvironmentDeleteClickCommand = new RelayCommand<DatabaseEnvironment>(OnEnvironmentDeleteClick));
        private async void OnEnvironmentDeleteClick(DatabaseEnvironment databaseEnvironment)
        {
            await databaseService.DeleteEnv(databaseEnvironment);
        }

        private ICommand _DatabaseDeleteClickCommand;
        public ICommand DatabaseDeleteClickCommand => _DatabaseDeleteClickCommand ?? (_DatabaseDeleteClickCommand = new RelayCommand<DatabaseServer>(OnDatabaseDeleteClick));
        private async void OnDatabaseDeleteClick(DatabaseServer databaseServer)
        {
            await databaseService.Delete(databaseServer);
        }
    }
}
