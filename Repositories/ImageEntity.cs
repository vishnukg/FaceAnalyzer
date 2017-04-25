using Microsoft.WindowsAzure.Storage.Table;

namespace FaceDetectorApi.Repositories
{
    public class ImageEntity :  TableEntity
    {
        
        public ImageEntity(string imageFilename)
        {
            this.PartitionKey = "TeamHug2017";
            this.RowKey = imageFilename;
        }

        public ImageEntity()
        {
            
        }
        public string ImageUrl { get; set; }
        public string Emotion { get; set; } 
    }
}