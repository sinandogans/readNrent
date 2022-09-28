namespace AuthorTranslatorService.Persistence.MongoDbDriver.Contexts
{
    public class MongoDbOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public string AuthorCollectionName { get; set; } = null!;
        public string AuthorReviewCollectionName { get; set; } = null!;
        public string TranslatorCollectionName { get; set; } = null!;
        public string TranslatorReviewCollectionName { get; set; } = null!;
        public string BookCollectionName { get; set; } = null!;
        public string UserCollectionName { get; set; } = null!;

    }
}
