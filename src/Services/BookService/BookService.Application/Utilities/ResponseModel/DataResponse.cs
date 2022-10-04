namespace BookService.Application.Utilities.ResponseModel
{
    public class DataResponse<TData> : Response
    {
        public TData Data { get; init; }
    }
}
