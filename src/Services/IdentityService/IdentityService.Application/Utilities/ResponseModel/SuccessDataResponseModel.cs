namespace IdentityService.Application.Utilities.ResponseModel
{
    public class SuccessDataResponseModel<T> : DataResponseModel<T>
    {
        public SuccessDataResponseModel(string message, T data) : base(true, message, data)
        {

        }
        public SuccessDataResponseModel(T data) : base(true, data)
        {

        }
        public SuccessDataResponseModel(string message) : base(true, message, default)
        {

        }

        public SuccessDataResponseModel() : base(true, default)
        {

        }
    }
}
