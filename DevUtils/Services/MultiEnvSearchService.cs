using DevUtils.Contracts.Services;
using DevUtils.Core.Models;
using DevUtils.DatabaseAccess;
using DevUtils.Helpers;
using DevUtils.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace DevUtils.Services
{
    public class MultiEnvSearchService : IMultiEnvSearchService
    {
        private readonly Local local;


        public MultiEnvSearchService(Local local)
        {
            this.local = local;
        }
        public IEnumerable<ProjectDetails> GetProjectDetails()
        {
            return local.Execute<ProjectDetails>("select * from ProjectDetails");
        }

        //public async Task<List<DatabaseServer>> AddServer(DatabaseServer databaseServer)
        //{
        //    var servers = await ApplicationData.Current.LocalSettings.ReadAsync<List<DatabaseServer>>(SettingsKey);
        //    servers.Add(databaseServer);
        //    await ApplicationData.Current.LocalSettings.ReadAsync<List<DatabaseServer>>(SettingsKey);
        //    return servers;
        //}
    }
}
