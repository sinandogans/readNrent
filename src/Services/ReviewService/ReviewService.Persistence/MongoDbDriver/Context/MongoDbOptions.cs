namespace ReviewService.Persistence.MongoDbDriver.Context
{
    public class MongoDbOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public string AuthorReviewsCollectionName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
        public string BookReviewsCollectionName { get; set; } = null!;

    }
}
