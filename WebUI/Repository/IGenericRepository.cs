using System.Threading.Tasks;

namespace WebUI.Repository
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri, string authToken = "");
    }
}
