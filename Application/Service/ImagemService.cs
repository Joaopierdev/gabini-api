using Core.Models;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ImagemService : IImagemService
    {
        public async Task<string> UploadImagem(FileData file, string folderName, string fileName)
        {
            string usersUploadFolderPath = Path.Combine("wwwroot", folderName);
            Directory.CreateDirectory(usersUploadFolderPath);
            string fullFileName = $"{fileName}{file.Extension}";
            string filePath = Path.Combine(usersUploadFolderPath, fullFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.WriteAsync(file.Content, 0, file.Content.Length);
            }
            string fileUrl = $"/{folderName}/{fullFileName}";
            return fileUrl;
        }
    }
}
