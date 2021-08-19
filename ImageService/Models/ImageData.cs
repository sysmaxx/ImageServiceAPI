using System;
using System.IO;

namespace ImageServiceApi.Models
{
    public class ImageData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public string PhysicalDirectory { get; set; }
        public string PhysicalFileName { get; set; }
        public bool Deleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string LocalFilePath => Path.Combine(PhysicalDirectory, PhysicalFileName);
    }
}
