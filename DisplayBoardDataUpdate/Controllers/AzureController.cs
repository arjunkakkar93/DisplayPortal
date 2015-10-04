using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Configuration;

namespace DisplayBoardDataUpdate.Controllers
{
    public class AzureController : Controller
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                       ConfigurationManager.AppSettings["StorageConnectionString"]);
        CloudBlobClient blobClient;
        CloudBlobContainer container;

        public AzureController(string containerName)
        {
            blobClient = storageAccount.CreateCloudBlobClient();

             container = blobClient.GetContainerReference(containerName);//("ltupdates-images");
            container.CreateIfNotExists();

            container.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
        }
        // GET: Azure
        public string AddToBlobStorage(string pathImage,string blobID)
        {

            CloudBlockBlob blockblob = container.GetBlockBlobReference(blobID);
            using (var fileStream = System.IO.File.OpenRead(pathImage))
            {
                blockblob.UploadFromStream(fileStream);
            }
            return blockblob.Uri.ToString();
        }
    }
}