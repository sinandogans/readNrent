namespace Core.Utilities.Results
{
    public interface IDataResponseModel<out T> : IResponseModel
    {
        T Data { get; }
    }
}
