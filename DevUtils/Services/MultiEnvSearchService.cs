using DevUtils.Contracts.Services;
using DevUtils.Core.Models;
using DevUtils.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace DevUtils.Services
{
    public class MultiEnvSearchService : IMultiEnvSearchService
    {
        private const string SettingsKey = "DatabaseServers";
        public MultiEnvSearchService()
        {

        }
        public async Task<List<DatabaseServer>> GetDatabaseServers()
        {
            return await ApplicationData.Current.LocalSettings.ReadAsync<List<DatabaseServer>>(SettingsKey);
        }

        public async Task<List<DatabaseServer>> AddServer(DatabaseServer databaseServer)
        {
            var servers = await ApplicationData.Current.LocalSettings.ReadAsync<List<DatabaseServer>>(SettingsKey);
            servers.Add(databaseServer);
            await ApplicationData.Current.LocalSettings.ReadAsync<List<DatabaseServer>>(SettingsKey);
            return servers;
        }
    }
}
