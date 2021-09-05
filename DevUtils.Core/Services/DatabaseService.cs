using DevUtils.Core.Contracts.Services;
using DevUtils.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevUtils.Core.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DevUtilContext context;

        public DatabaseService(DevUtilContext context)
        {
            this.context = context;
        }
        public async Task<List<DatabaseServer>> Get()
        {
            return await context.DatabaseServers.ToListAsync();
        }
        public async Task<List<DatabaseEnvironment>> GetEnvs(int databaseId)
        {
            return await context.DatabaseEnvironments
                .Where(m => m.DatabaseId == databaseId)
                .ToListAsync();
        }
        public async Task<DatabaseServer> AddOrUpdate(DatabaseServer databaseServer)
        {
            if (databaseServer.Id == 0)
            {
                context.DatabaseServers.Add(databaseServer);
            }
            else
            {
                context.DatabaseServers.Update(databaseServer);
            }
            await context.SaveChangesAsync();
            return databaseServer;
        }
        public async Task<DatabaseEnvironment> AddOrUpdateEnv(DatabaseEnvironment databaseEnvironment)
        {
            if (databaseEnvironment.Id == 0)
            {
                context.DatabaseEnvironments.Add(databaseEnvironment);
            }
            else
            {
                context.DatabaseEnvironments.Update(databaseEnvironment);
            }
            await context.SaveChangesAsync();
            return databaseEnvironment;
        }

        public async Task Delete(DatabaseServer databaseServer)
        {
            context.DatabaseServers.Remove(databaseServer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteEnv(DatabaseEnvironment databaseEnvironment)
        {
            context.DatabaseEnvironments.Remove(databaseEnvironment);
            await context.SaveChangesAsync();
        }
    }
}
