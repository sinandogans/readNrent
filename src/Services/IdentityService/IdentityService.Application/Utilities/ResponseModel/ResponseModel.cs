namespace IdentityService.Application.Utilities.ResponseModel
{
    public class ResponseModel : IResponseModel
    {
        public ResponseModel(bool success, string message) : this(success)
        {
            Message = message;
        }
        public ResponseModel(bool success)
        {
            Success = success;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
