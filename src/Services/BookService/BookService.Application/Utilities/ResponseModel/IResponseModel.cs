namespace BookService.Application.Utilities.ResponseModel
{
    public interface IResponseModel
    {
        bool Success { get; }
        string Message { get; }
    }
}
