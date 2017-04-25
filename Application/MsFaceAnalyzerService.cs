using System.Linq;
using System.Threading.Tasks;
using FaceDetectorApi.Models;
using FaceDetectorApi.Repositories;
using Microsoft.AspNetCore.Http;

namespace FaceDetectorApi.Application
{
    public class MsFaceAnalyzerService : IFaceAnalyzerService
    {
        private readonly IClientProxy clientProxy;
        private readonly IParser parser;
        private readonly IBlobRepository blobRepository;
        private readonly ITableRepository tableRepository;
        private string CognitiveFaceApi =>"https://southeastasia.api.cognitive.microsoft.com/face/v1.0/detect?returnfaceAttributes=emotion";
        private string ImageBaseUrl => "https://teamhug2017.blob.core.windows.net/pictures/";

        public MsFaceAnalyzerService(IClientProxy clientProxy, IParser parser, IBlobRepository blobRepository, ITableRepository tableRepository)
        {
            this.clientProxy = clientProxy;
            this.parser = parser;
            this.blobRepository = blobRepository;
            this.tableRepository = tableRepository;
        }
        public async Task<string> DetectEmotion(IFormFile imageFile)
        {
            var imageFileName = await this.blobRepository.UploadFile(imageFile);

            var imageUrl = this.ImageBaseUrl + imageFileName;
            var response = await this.clientProxy.PostAsync(imageUrl, this.CognitiveFaceApi);
            var imageInfo = this.parser.ParseImageInfo(response);

            var emotion = imageInfo.Emotions.OrderByDescending(e => e.Weightage).First();
            await this.tableRepository.InsertFace(new FaceInfo()
            {
                ImageFileName = imageFileName,
                ImageUrl = imageUrl,
                Emotion = emotion.TypeofEmotion
            });

            return emotion.TypeofEmotion;

        }
    }
}
