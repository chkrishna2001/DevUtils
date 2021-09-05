using DevUtils.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevUtils.Core.Contracts.Services
{
    public interface IDatabaseService
    {
        Task<List<DatabaseServer>> Get();
        Task<List<DatabaseEnvironment>> GetEnvs(int envId);
        Task<DatabaseServer> AddOrUpdate(DatabaseServer databaseServer);
        Task<DatabaseEnvironment> AddOrUpdateEnv(DatabaseEnvironment databaseEnvironment);
        Task Delete(DatabaseServer databaseServer);
        Task DeleteEnv(DatabaseEnvironment databaseEnvironment);
    }
}
