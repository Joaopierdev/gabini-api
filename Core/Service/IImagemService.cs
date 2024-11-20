using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IImagemService
    {
        public Task<string> UploadImagem(FileData file, string folderName, string fileName);
    }
}
