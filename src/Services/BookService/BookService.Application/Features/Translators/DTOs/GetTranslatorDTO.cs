using BookService.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Application.Features.Translators.DTOs
{
    public class GetTranslatorDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double Rating { get; set; }
        public int ReadCount { get; set; }
        public int ReviewCount { get; set; }
        public List<Guid> ReviewIds { get; set; }
        public List<Guid> BookIds { get; set; }
    }
}
