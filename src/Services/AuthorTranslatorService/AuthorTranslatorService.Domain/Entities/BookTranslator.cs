namespace AuthorTranslatorService.Domain.Entities
{
    public class BookTranslator
    {
        public Guid TranslatorId { get; set; }
        public Guid BookId { get; set; }
    }
}
