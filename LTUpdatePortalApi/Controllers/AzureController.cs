using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Configuration;
using System.Web.Http.Cors;

namespace LTUpdatePortalApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AzureController : ApiController
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                      ConfigurationManager.AppSettings["StorageConnectionString"]);
        CloudBlobClient blobClient;
        CloudBlobContainer container;
        public AzureController()
        {
            blobClient = storageAccount.CreateCloudBlobClient();

             container = blobClient.GetContainerReference("ltupdates-images");
            container.CreateIfNotExists();

            container.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
        }
        public string GetBlob(int id=1)
        {
            FetchUpdatesController fetchImageFromBlob = new FetchUpdatesController();
            var imageUrl = "https://portalvhds073ynyj7sf862.blob.core.windows.net/ltupdates-images/"+fetchImageFromBlob.GetLTUpdateById(id).Content_URL;
            return imageUrl;
        }
    }
}
