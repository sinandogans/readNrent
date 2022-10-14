namespace Core.Utilities.Results
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
