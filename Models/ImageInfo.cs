using System.Collections.Generic;

namespace FaceDetectorApi.Models
{
    public class ImageInfo
    {
        public string FaceId { get; set; }
        public List<ParsedEmotion> Emotions { get; set; }
    }
}