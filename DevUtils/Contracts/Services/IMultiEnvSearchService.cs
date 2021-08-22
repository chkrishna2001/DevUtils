using DevUtils.Core.Models;
using DevUtils.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevUtils.Contracts.Services
{
    public interface IMultiEnvSearchService
    {
        IEnumerable<ProjectDetails> GetProjectDetails();
    }
}
