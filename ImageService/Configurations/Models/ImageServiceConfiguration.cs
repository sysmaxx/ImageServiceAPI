using System.Collections.Generic;

namespace ImageServiceApi.Configurations.Models
{
    public class ImageServiceConfiguration
    {
        public string DefaultPath { get; set; }
        public IEnumerable<string> SupportedMimeTypes { get; set; }
        public int BufferSize { get; set; }
        public double ResizeUploadImageLongEdge { get; set; }
    }
}
