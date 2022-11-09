namespace LibraryService.Application.Utilities.ResponseModel
{
    public class ErrorResponseModel : ResponseModel
    {
        public ErrorResponseModel(string message) : base(false, message)
        {

        }
        public ErrorResponseModel() : base(false)
        {

        }
    }
}
