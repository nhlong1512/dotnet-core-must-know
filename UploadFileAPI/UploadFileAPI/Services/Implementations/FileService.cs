using Azure.Storage;
using Azure.Storage.Blobs;
using UploadFileAPI.Dtos;
using UploadFileAPI.Services.Interfaces;

namespace UploadFileAPI.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly string _storageAccount = "YourStorageAccount";
        private readonly string _accessKey = "YourKey";
        private readonly BlobContainerClient _filesContainer;
        public FileService()
        {
            var credential = new StorageSharedKeyCredential(_storageAccount, _accessKey);
            var blobUri = $"https://{_storageAccount}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _filesContainer = blobServiceClient.GetBlobContainerClient("YourNameContainer");
        }

        public async ValueTask<List<BlobDto>> GetAllFilesAsync()
        {
            List<BlobDto> files = new List<BlobDto>();
            await foreach (var file in _filesContainer.GetBlobsAsync())
            {
                string uri = _filesContainer.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";
                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = file.Properties.ContentType
                });
            }
            return files;
        }

        public async ValueTask<BlobResponseDto> UploadFileAsync(IFormFile blob)
        {
            BlobResponseDto blobResponse = new BlobResponseDto();
            BlobClient client = _filesContainer.GetBlobClient(blob.FileName);
            await using (Stream? data = blob.OpenReadStream())
            {
                await client.UploadAsync(data);
            }
            blobResponse.Status = $"File {blob.FileName} Uploaded Successfully";
            blobResponse.Error = false;
            blobResponse.Blob.Uri = client.Uri.AbsoluteUri;
            blobResponse.Blob.Name = client.Name;

            return blobResponse;
        }

        public async ValueTask<BlobDto?> DownloadFileAsync(string blobFileName)
        {
            BlobClient file = _filesContainer.GetBlobClient(blobFileName);
            if (await file.ExistsAsync())
            {
                Stream blobContent = await file.OpenReadAsync();
                var content = await file.DownloadContentAsync();
                string name = blobFileName;
                string contentType = content.Value.Details.ContentType;
                return new BlobDto
                {
                    Content = blobContent,
                    Name = name,
                    ContentType = contentType

                };
            }
            return null;
        }

        public async ValueTask<BlobResponseDto> DeleteFileAsync(string blobFileName)
        {
            BlobClient file = _filesContainer.GetBlobClient(blobFileName);
            await file.DeleteAsync();
            return new BlobResponseDto { Error = false, Status = $"File: {blobFileName} has been successfully deleted." };
        }
    }
}
