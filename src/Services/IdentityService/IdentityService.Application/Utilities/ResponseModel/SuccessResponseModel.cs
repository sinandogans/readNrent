namespace IdentityService.Application.Utilities.ResponseModel
{
    public class SuccessResponseModel : ResponseModel
    {
        public SuccessResponseModel(string message) : base(true, message)
        {

        }
        public SuccessResponseModel() : base(true)
        {

        }
    }
}
