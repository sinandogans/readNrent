namespace LibraryService.Application.Utilities.ResponseModel
{
    public class ErrorDataResponseModel<T> : DataResponseModel<T>
    {
        public ErrorDataResponseModel(string message, T data) : base(true, message, data)
        {

        }
        public ErrorDataResponseModel(T data) : base(false, data)
        {

        }
        public ErrorDataResponseModel(string message) : base(false, message, default)
        {

        }

        public ErrorDataResponseModel() : base(false, default)
        {

        }
    }
}
