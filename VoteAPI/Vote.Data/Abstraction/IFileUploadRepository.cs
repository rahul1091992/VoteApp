using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;

namespace Vote.Data.Abstraction
{
    public interface IFileUploadRepository
    {
        FileUpload AddAtachmentFile(string attachmentFile);
        string GetFile(int id);
        FileUpload AddAtachmentVideo(string attachmentFile);
    }
}
