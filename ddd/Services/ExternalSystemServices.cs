using System.Threading.Tasks;

namespace ddd.Services
{

    public interface IExternalSystemServices
    {
        Task SendEventToExternalApi(string item);
    }


    public class ExternalSystemServices : IExternalSystemServices
    {
        public Task SendEventToExternalApi(string item)
        {
            return Task.CompletedTask;
        }
    }
}
