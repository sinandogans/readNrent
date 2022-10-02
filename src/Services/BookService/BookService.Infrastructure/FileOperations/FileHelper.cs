using BookService.Application.Abstraction.Infrastructure.FileOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BookService.Infrastructure.FileOperations
{
    public class FileHelper : IFileHelper
    {
        private readonly IConfiguration _configuration;

        public FileHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string AddImageToProject(IFormFile image)
        {
            Guid fileName = Guid.NewGuid();
            string localPath = _configuration["FileOptions:Path"] + fileName.ToString() + ".png";

            FileStream fs = new(localPath, FileMode.CreateNew);
            image.CopyTo(fs);
            fs.Close();

            return localPath;
        }
    }
}
