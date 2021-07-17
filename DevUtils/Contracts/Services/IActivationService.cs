using System.Threading.Tasks;

namespace DevUtils.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
