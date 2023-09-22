# UploadFileAPI With AzureBlobStorage

## Introduction
**`UploadFile with AzureBlobStorage`** refers to the process of uploading a file to Microsoft Azure Blob Storage. Here's what it means:

**`Azure Blob Storage`**: This is a cloud-based object storage service provided by Microsoft Azure. It allows you to store and manage unstructured data such as documents, images, videos, and other binary or text data.

**`UploadFile`**`: This is an action where you transfer a file from a local or remote location to a destination in Azure Blob Storage. It typically involves selecting a file on your local machine or a remote server and sending it to a specific container or directory within your Azure Blob Storage account.

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

## ⚡ Installation & Run
### Go to UploadFileAPI project in "UploadFileAPI"
>run 
```sh
dotnet run
```
## 🛠️ Troubleshooting
If you encounter errors, you can try delete the `obj` folder and `bin` folder in the project, and then run the `README.md` document again.
