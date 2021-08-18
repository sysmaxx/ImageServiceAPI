namespace ImageServiceApi.Models.Responses
{
    public class UploadResponse
    {
        public long Id { get; set; }

        public UploadResponse(long id)
        {
            Id = id;
        }
    }
}
