using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Data.Abstraction;
using Vote.Data.DB;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Data
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private VoteDBContext voteContext;
        public FileUploadRepository(VoteDBContext db)
        {
            voteContext = db;
        }
        public FileUpload AddAtachmentFile(string attachmentFile)
        {
            FileUpload fileUpload = new FileUpload();
            fileUpload.ImageUrl = attachmentFile;
            voteContext.fileUpload.Add(fileUpload);
            voteContext.SaveChanges();
            return fileUpload;
        }
        public string GetFile(int id)
        {
            var data = voteContext.fileUpload.Where(x => x.Id == id).FirstOrDefault();
            return data.ImageUrl;
        }

        public FileUpload AddAtachmentVideo(string attachmentFile)
        {
            FileUpload fileUpload = new FileUpload();
            fileUpload.ImageUrl = attachmentFile;
            voteContext.fileUpload.Add(fileUpload);
            voteContext.SaveChanges();
            return fileUpload;
        }
    }
}
