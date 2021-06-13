using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;

namespace Vote.Service.Abstraction
{
    public interface IFileUploadService
    {
        FileUpload AddAtachmentFile(string attachmentFile);
        string GetFile(int id);
        FileUpload AddAtachmentVideo(string attachmentFile);
    }
}
