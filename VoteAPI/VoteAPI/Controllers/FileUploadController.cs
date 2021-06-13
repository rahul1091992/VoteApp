using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vote.Model;
using Vote.Model.Models;
using Vote.Service.Abstraction;

namespace VoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FileUploadController : ControllerBase
    {
        private IFileUploadService _fileUploadsService;
        private readonly IWebHostEnvironment _environment;
        public FileUploadController(IFileUploadService fileUploadsService, IWebHostEnvironment environment)
        {
            _fileUploadsService = fileUploadsService;
            _environment = environment;
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadFile()
        {
            try
            {

                var file = Request.Form.Files[0];
                var newPath = Path.Combine(_environment.ContentRootPath, $"Uploads");
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + ".jpg";

                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }



                    var attachmentId = _fileUploadsService.AddAtachmentFile(fileName);

                    return Ok(new ApiResponse<FileUpload>()
                    {
                        Status = true,
                        Message = "File saved successfully.",
                        Data = attachmentId
                    });


                }
                else
                {
                    return BadRequest(new { Status = false, message = "File could not be uploaded" });
                }

            }
            catch (System.Exception)
            {
                return BadRequest(new { Status = false, message = "File could not be uploaded" });
            }
        }



        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFile(int id)
        {

            try
            {
                string img = _fileUploadsService.GetFile(id);

                return Ok(new ApiResponse<string[]>()
                {
                    Status = true,
                    Message = img,
                });
            }
            catch (System.Exception)
            {
                return BadRequest(new { Status = false, message = "File could not found" });
            }
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadVideo")]
        public IActionResult UploadVideo()
        {
            try
            {

                var file = Request.Form.Files[0];
                var newPath = Path.Combine(_environment.ContentRootPath, $"Uploads");
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + ".mp4";

                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }



                    var attachmentId = _fileUploadsService.AddAtachmentFile(fileName);

                    return Ok(new ApiResponse<FileUpload>()
                    {
                        Status = true,
                        Message = "File saved successfully.",
                        Data = attachmentId
                    });


                }
                else
                {
                    return BadRequest(new { Status = false, message = "File could not be uploaded" });
                }

            }
            catch (System.Exception)
            {
                return BadRequest(new { Status = false, message = "File could not be uploaded" });
            }
        }
    }
}
