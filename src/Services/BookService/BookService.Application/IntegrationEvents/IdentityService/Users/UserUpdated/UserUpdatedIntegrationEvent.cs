namespace BookService.Application.IntegrationEvents.IdentityService.Users.UserUpdated
{
    public class UserUpdatedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
