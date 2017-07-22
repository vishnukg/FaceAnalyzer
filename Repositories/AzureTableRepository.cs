using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceDetectorApi.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace FaceDetectorApi.Repositories
{
    public class AzureTableRepository : ITableRepository
    {
        private static string TableName => "Images";

        public async Task InsertFace(FaceInfo face)
        {
            var tableClient = AzureStorageClientProvider.GetTableClient();

            var table = tableClient.GetTableReference(TableName);     
            await table.CreateIfNotExistsAsync();

            var image = new ImageEntity(face.ImageFileName) {ImageUrl = face.ImageUrl,Emotion = face.Emotion};       
            
            var insertOperation = TableOperation.Insert(image);  
            await table.ExecuteAsync(insertOperation);
        }

        public async Task<IEnumerable<FaceDto>> GetAllFaces()
        {
            var tableClient = AzureStorageClientProvider.GetTableClient();
            var table = tableClient.GetTableReference(TableName);
            var query = new TableQuery<ImageEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "TeamHug2017"));

            TableContinuationToken token = null;
            var faces = new List<FaceDto>();
            do
            {
                var resultSegment = await table.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;       
                foreach (var entity in resultSegment.Results)
                {
                    faces.Add(new FaceDto() {Emotion = entity.Emotion, ImageUrl = entity.ImageUrl});
                }
            } while (token != null);
   
            return faces;
        }
    }
}