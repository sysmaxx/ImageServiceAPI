using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace ImageServiceApi.Utility
{
    public static class HashUtility
    {
        public static string GetHashFromStream(Stream stream)
        {
            using var sha = SHA256.Create();
            return string
                .Concat(sha
                    .ComputeHash(stream)
                    .Select(b => b.ToString("X2")));
        }
    }



}
