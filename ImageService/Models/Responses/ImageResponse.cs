using System.IO;

namespace ImageServiceApi.Models.Responses
{
    public class ImageResponse
    {
        public Stream ImageStream{ get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
    }
}
