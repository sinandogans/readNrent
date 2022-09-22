namespace AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorCommand
{
    public class AddTranslatorCommandResponse
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
    }
}
