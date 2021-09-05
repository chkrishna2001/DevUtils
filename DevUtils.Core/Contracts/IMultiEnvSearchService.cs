using DevUtils.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevUtils.Core.Contracts
{
    public interface IMultiEnvSearchService
    {
        Task<List<DatabaseServer>> GetDatabaseServers();
    }
}
