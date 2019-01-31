using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace HaveYourSay.Model
{
    public class BlobStorageService
    {
        readonly static CloudStorageAccount _cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=wvmdiag896;AccountKey=NozcKHCgu9eCmWalEgh/gx8RuymC7BjlDywoHCmW4BCbhy3vHJ+2A2eWVACswawhj3CP2extHcD8twkCI4NpNA==;EndpointSuffix=core.windows.net");
        readonly static CloudBlobClient _blobClient = _cloudStorageAccount.CreateCloudBlobClient();


        public static async Task<CloudBlockBlob> SaveBlockBlob(string containerName, byte[] blob, string blobTitle)
        {
            var blobContainer = _blobClient.GetContainerReference(containerName);

            try
            {
                SetMetadata(blobContainer);

                var blockBlob = blobContainer.GetBlockBlobReference(blobTitle);

                await blockBlob.UploadFromByteArrayAsync(blob, 0, blob.Length);

                return blockBlob;
            }
            catch (Exception e)
            {
                Console.WriteLine($":::::::" + e);
                return null;
            }
        }

        static void SetMetadata(CloudBlobContainer container)
        {
            container.Metadata.Clear();
            container.Metadata.Add("author", "Najuma M");
            container.SetMetadata();
        }

    }
}
