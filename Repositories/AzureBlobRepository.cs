using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FaceDetectorApi.Repositories
{
    public class AzureBlobRepository : IBlobRepository
    {
        private static string Container => "pictures";
        private readonly List<string> supportedMimeTypes = new List<string>(){ "image/png", "image/jpeg"};

        public async Task<string> UploadFile(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));

            var blobClient = AzureStorageClientProvider.GetBlobClient();
            var imagesContainer = blobClient.GetContainerReference(Container);
            
            // Generate a new filename for every new blob
            var fileName = Guid.NewGuid().ToString();
            var cloudBlob = imagesContainer.GetBlockBlobReference(fileName);
            if (!this.supportedMimeTypes.Contains(file.ContentType.ToLower()))
            {
                throw new NotSupportedException("Only jpeg and png are supported");
            }
            cloudBlob.Properties.ContentType = file.ContentType;

            await cloudBlob.UploadFromStreamAsync(file.OpenReadStream());
            return fileName;
        }
    }
}