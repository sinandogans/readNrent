using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Application.Abstraction.Persistence.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
