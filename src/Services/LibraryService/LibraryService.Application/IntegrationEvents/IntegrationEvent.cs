namespace LibraryService.Application.IntegrationEvents
{
    public class IntegrationEvent
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
    }
}
