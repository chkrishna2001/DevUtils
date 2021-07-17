using DevUtils.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevUtils.Contracts.Services
{
    public interface IMultiEnvSearchService
    {
        Task<List<DatabaseServer>> GetDatabaseServers();
    }
}
