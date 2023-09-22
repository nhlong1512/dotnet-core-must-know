# UploadFileAPI With AzureBlobStorage

## Introduction
**`UploadFile with AzureBlobStorage`** refers to the process of uploading a file to Microsoft Azure Blob Storage. Here's what it means:

**`Azure Blob Storage`**: This is a cloud-based object storage service provided by Microsoft Azure. It allows you to store and manage unstructured data such as documents, images, videos, and other binary or text data.

**`UploadFile`**: This is an action where you transfer a file from a local or remote location to a destination in Azure Blob Storage. It typically involves selecting a file on your local machine or a remote server and sending it to a specific container or directory within your Azure Blob Storage account.

## The APIs in the project
* Get all Files in BlobContainer (**`GET`**)
* Upload File (**`POST`**)
* Delete File (**`DELETE`**)
* Download File from BlobContainer (**`PUT`**)
## The used packages
```cs
Azure.Storage.Blobs
Microsoft.AspNetCore.OpenApi
Swashbuckle.AspNetCore
```
## Prerequisites
This project assumes you already have a project set up to work with the Azure Blob Storage client library for .NET. To learn about setting up your project, including package installation, adding using directives, and creating an authorized client object, see [Get started with Azure Blob Storage and .NET.](https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-dotnet-get-started?tabs=azure-ad)

## ⚡ Installation & Run
### Configure Azure Key Information
To run the project, you need to provide the following information in the **`FileService.cs`** file.

>**FileService.cs**
```cs
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
```
### Go to UploadFileAPI project in "UploadFileAPI"
>run 
```sh
dotnet run
```
## 🛠️ Troubleshooting
If you encounter errors, you can try delete the `obj` folder and `bin` folder in the project, and then run the `README.md` document again.
