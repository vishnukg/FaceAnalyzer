using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace FaceDetectorApi.Repositories
{
    public static class AzureStorageClientProvider
    {
        private static string AccountName => "teamhug2017";
        private static string AccountKey => "hgvOkm09ydmw4u0QA3xpuEEMYujbmAZR7WGmG1F1HMyDYjXP35gApWzIWsBaaglO+6BXMZNuctqP1JEsJh57NA==";
        public static CloudBlobClient GetBlobClient()
        {
           return new CloudStorageAccount(new StorageCredentials(AccountName, AccountKey), true).CreateCloudBlobClient(); 
        }

        public static CloudTableClient GetTableClient()
        {
            return new CloudStorageAccount(new StorageCredentials(AccountName, AccountKey), true).CreateCloudTableClient();
        }
    }
}