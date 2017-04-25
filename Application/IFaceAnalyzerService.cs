using System.Threading.Tasks;
using FaceDetectorApi.Models;
using Microsoft.AspNetCore.Http;

namespace FaceDetectorApi.Application
{
    public interface IFaceAnalyzerService
    {
        Task<string> DetectEmotion(IFormFile imageFile);
    }
}