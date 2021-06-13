using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Data.Abstraction;
using Vote.Model;
using Vote.Service.Abstraction;

namespace Vote.Service
{
    public class FileUploadService : IFileUploadService
    {
        IFileUploadRepository _fileUploadsRepository;
        public FileUploadService(IFileUploadRepository fileUploadsRepository)
        {
            _fileUploadsRepository = fileUploadsRepository;
        }
        public FileUpload AddAtachmentFile(string attachmentFile)
        {
            return _fileUploadsRepository.AddAtachmentFile(attachmentFile);
        }
        public string GetFile(int id)
        {
            return _fileUploadsRepository.GetFile(id);
        }

        public FileUpload AddAtachmentVideo(string attachmentFile)
        {
            return _fileUploadsRepository.AddAtachmentVideo(attachmentFile);
        }
    }
}
