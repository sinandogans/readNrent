namespace AuthorTranslatorService.Application.Features.ResponseModel
{
    public class DataResponse<TData> : Response
    {
        public TData Data { get; init; }
    }
}
