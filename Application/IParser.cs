using FaceDetectorApi.Models;

namespace FaceDetectorApi.Application
{
    public interface IParser
    {
        ImageInfo ParseImageInfo(string jsonOutput);
    }
}