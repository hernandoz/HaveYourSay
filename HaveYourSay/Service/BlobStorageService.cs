using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace HaveYourSay.Service
{
    public class BlobStorageService
    {
        readonly static CloudStorageAccount _cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=wvmdiag896;AccountKey=NozcKHCgu9eCmWalEgh/gx8RuymC7BjlDywoHCmW4BCbhy3vHJ+2A2eWVACswawhj3CP2extHcD8twkCI4NpNA==;EndpointSuffix=core.windows.net");
        readonly static CloudBlobClient _blobClient = _cloudStorageAccount.CreateCloudBlobClient();


        public static async Task<CloudBlockBlob> SaveBlockBlob(string containerName, Byte[] blob, string itemid)
        {
            var blobContainer = _blobClient.GetContainerReference(containerName);

            try
            {

                Guid g;
                g = Guid.NewGuid();

                var blockBlob = blobContainer.GetBlockBlobReference(g.ToString());

            blockBlob.Metadata.Add("entryid", itemid);

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

    }
}
