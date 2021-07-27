using System;

namespace ImageServiceApi.Models
{
    public class Image
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public string PhysicalDirectory { get; set; }
        public string PhysicalFileName { get; set; }
        public bool Deleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
