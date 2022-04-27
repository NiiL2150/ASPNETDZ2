using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ASPNETDZ2
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
        public static string ToImage(this byte[] byteArray)
        {
            return $"data:image/jpg;base64,{Convert.ToBase64String(byteArray, 0, byteArray.Length)}";
        }
    }
}
