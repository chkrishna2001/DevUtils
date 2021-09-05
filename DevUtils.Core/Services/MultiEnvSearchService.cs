using DevUtils.Core.Contracts;
using DevUtils.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevUtils.Core.Services
{
    public class MultiEnvSearchService : IMultiEnvSearchService
    {
        private readonly DevUtilContext devUtilContext;

        public MultiEnvSearchService(DevUtilContext devUtilContext)
        {
            this.devUtilContext = devUtilContext;
        }
        public async Task<List<DatabaseServer>> GetDatabaseServers()
        {
            return await devUtilContext.DatabaseServers.ToListAsync();
        }
    }
}
