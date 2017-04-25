using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FaceDetectorApi.Repositories
{
    public interface IBlobRepository
    {
        Task<string> UploadFile(IFormFile file);
    }
}
