using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FaceDetectorApi.Application;
using FaceDetectorApi.Repositories;
using Microsoft.AspNetCore.Http;

namespace FaceDetectorApi.Controllers
{
    [Route("api/Face")]
    public class FaceController : Controller
    {
        private readonly IFaceAnalyzerService faceAnalyzerService;

        private readonly ITableRepository tableRepository;

        public FaceController(IFaceAnalyzerService faceAnalyzerService, ITableRepository tableRepository)
        {
            this.faceAnalyzerService = faceAnalyzerService;
            this.tableRepository = tableRepository;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> UploadFace(IFormFile file)
        {
            {
                if (!MultipartRequestHelper.IsMultipartContentType(this.Request.ContentType))
                {
                    return this.BadRequest($"Expected a multipart request, but got {this.Request.ContentType}");
                }

                try
                {
                    var emotion = await this.faceAnalyzerService.DetectEmotion(file);
                    return this.Ok($"You really look {emotion}");
                }
                catch (Exception exception)
                {
                    return this.BadRequest($"An error has occured. Details: {exception.Message}");
                }
            }
            
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetFaces()
        {
            try
            {
                return this.Ok(await this.tableRepository.GetAllFaces());
            }
            catch (Exception exception)
            {
                return this.BadRequest($"An error has occured. Details: {exception.Message}");
            }
        }
     

    }
}
