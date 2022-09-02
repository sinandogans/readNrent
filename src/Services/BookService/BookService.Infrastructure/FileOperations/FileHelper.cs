using BookService.Application.Abstraction.Infrastructure.FileOperations;
using Microsoft.AspNetCore.Http;

namespace BookService.Infrastructure.FileOperations
{
    public class FileHelper : IFileHelper
    {
        public string AddImageToProject(IFormFile image)
        {
            Guid fileName = Guid.NewGuid();
            string localPath = "C:\\dotnetprojects\\readNrent\\src\\Services\\BookService\\BookService.Application\\ServiceImages\\" + fileName.ToString() + ".png";

            FileStream fs = new(localPath, FileMode.CreateNew);
            image.CopyTo(fs);
            fs.Close();

            return localPath;
        }
    }
}
