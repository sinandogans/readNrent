namespace IdentityService.Application.Utilities.ResponseModel
{
    public interface IDataResponseModel<out T> : IResponseModel
    {
        T Data { get; }
    }
}
