namespace FaceDetectorApi.Models
{
    public class RootObject
    {
        public string FaceId { get; set; }
        public FaceRectangle FaceRectangle { get; set; }
        public FaceAttributes FaceAttributes { get; set; }
    }

}