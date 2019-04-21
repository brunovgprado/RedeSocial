using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Web;
using Microsoft.Azure;
using RedeSocialWeb.Exceptions;

namespace RedeSocialWeb.ServicoWeb
{
    public class BlobServico
    {
        public async Task<string> UploadImageAsync(HttpPostedFileBase fileToUpload, string containerName)
        {
            string filePath = null;
            if (fileToUpload == null || fileToUpload.ContentLength == 0)
            {
                throw new EmptyFileException("Arquivo vazio ou inválido");
            }
            try
            {
                CloudBlobContainer cloudBlobContainer = ObterBlobContainer(containerName);

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        });
                }
                string fileName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(fileToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                cloudBlockBlob.Properties.ContentType = fileToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(fileToUpload.InputStream);

                filePath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            return filePath;
        }

        private CloudBlobContainer ObterBlobContainer(string containerName)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);

            return cloudBlobContainer;
        }
    }
}
