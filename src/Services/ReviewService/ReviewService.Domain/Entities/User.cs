using ReviewService.Domain.Abstraction;

namespace ReviewService.Domain.Entities
{
    public class User:IEntity
    {
        public Guid Id { get; set; }
    }
}
