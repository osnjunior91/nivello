using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Nivello.Lib.Nivello.Extension.Methods
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
