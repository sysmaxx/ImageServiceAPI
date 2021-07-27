using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageServiceApi.Models.Responses
{
    public class UploadSuccessResponse
    {
        public long Id { get; set; }

        public UploadSuccessResponse(long id)
        {
            Id = id;
        }
    }
}
