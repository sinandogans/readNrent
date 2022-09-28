namespace AuthorTranslatorService.Application.Features.Translators.Queries.GetAllTranslatorsQuery
{
    public class GetAllTranslatorsQueryResponse
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double? Rating { get; set; }
        public int ReviewCount { get; set; }
        public List<Guid> ReviewIds { get; set; }
        public List<Guid> BookIds { get; set; }
    }
}
