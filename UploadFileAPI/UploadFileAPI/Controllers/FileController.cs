using Microsoft.AspNetCore.Mvc;
using UploadFileAPI.Dtos;
using UploadFileAPI.Services.Implementations;
using UploadFileAPI.Services.Interfaces;

namespace UploadFileAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController:ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllFiles()
        {
            List<BlobDto> allFiles = await _fileService.GetAllFilesAsync();
            return Ok(allFiles);
        }

        [HttpPost]
        public async ValueTask<IActionResult> UploadFile(IFormFile file)
        {
            BlobResponseDto responseFile = await _fileService.UploadFileAsync(file);
            return Ok(responseFile);
        }        

        [HttpGet]
        [Route("fileName")]
        public async ValueTask<IActionResult> DownloadFile(string fileName)
        {
            BlobDto blob = await _fileService.DownloadFileAsync(fileName);
            return File(blob.Content, blob.ContentType, blob.Name);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteFile(string fileName)
        {
            BlobResponseDto responseFile = await _fileService.DeleteFileAsync(fileName);
            return Ok(responseFile);
        }

    }
}
