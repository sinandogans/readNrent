namespace BookService.Persistence.MongoDbDriver.Context
{
    public class MongoDbOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public string AuthorsCollectionName { get; set; } = null!;
        public string AuthorReviewsCollectionName { get; set; } = null!;
        public string BooksCollectionName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
        public string BookImagesCollectionName { get; set; } = null!;
        public string BookReviewsCollectionName { get; set; } = null!;
        public string GenresCollectionName { get; set; } = null!;
        public string LanguagesCollectionName { get; set; } = null!;
        public string PublishesCollectionName { get; set; } = null!;
        public string PublishersCollectionName { get; set; } = null!;

    }
}
