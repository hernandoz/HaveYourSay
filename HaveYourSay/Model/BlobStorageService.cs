using System;
using System.Collections.Generic;
using System.IO;
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


        public static async Task<CloudBlockBlob> SaveBlockBlob(string containerName, Byte[] blob, string blobTitle)
        {
            var blobContainer = _blobClient.GetContainerReference(containerName);

            try
            {
            
            var blockBlob = blobContainer.GetBlockBlobReference(blobTitle);

            blockBlob.Metadata.Add("Hello", "Moto");

            await blockBlob.UploadFromByteArrayAsync(blob, 0, blob.Length);
            
            Console.WriteLine($":::::::" + blockBlob.Metadata.Count);

            return blockBlob;

            }
            catch (Exception e)
            {
                Console.WriteLine($":::::::" + e);
                return null;
            }
        }

        //static void SetMetadata(CloudBlobContainer container)
        //{
        //    container.Metadata.Clear();
        //    container.Metadata.Add("author", "Najuma M");
        //    container.Metadata.Add("HEllo", "Test");
        //    container.Metadata["LastUpdated"] = DateTime.Now.ToString();
        //    container.SetMetadata();
        //}

    }
}
