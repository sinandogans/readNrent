namespace Core.Utilities.Results
{
    public interface IResponseModel
    {
        bool Success { get; }
        string Message { get; }
    }
}
