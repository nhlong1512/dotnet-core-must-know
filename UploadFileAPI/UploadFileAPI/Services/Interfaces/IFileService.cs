using UploadFileAPI.Dtos;

namespace UploadFileAPI.Services.Interfaces
{
    public interface IFileService
    {
        ValueTask<List<BlobDto>> GetAllFilesAsync();
        ValueTask<BlobResponseDto> UploadFileAsync(IFormFile blob);
        ValueTask<BlobDto?> DownloadFileAsync(string blobFileName);
        ValueTask<BlobResponseDto> DeleteFileAsync(string blobFileName);
    }
}
