using Microsoft.AspNetCore.Http;

namespace BookService.Application.Abstraction.Infrastructure.FileOperations
{
    public interface IFileHelper
    {
        public string AddImageToProject(IFormFile image);
    }
}
