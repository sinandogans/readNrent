using UserService.Domain.Abstraction;
using UserService.Domain.Enums;

namespace UserService.Domain.Entities
{
    public class UserBook : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public double Rating { get; set; }
        public User User { get; set; }
    }
}
