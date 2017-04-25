using System.Threading.Tasks;

namespace FaceDetectorApi.Application
{
    public interface IClientProxy
    {
        Task<string> PostAsync(string imageUrl, string cognitiveApi);
    }
}