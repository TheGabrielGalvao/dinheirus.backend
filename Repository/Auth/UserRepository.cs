using Database;
using Domain.Entities;
using Domain.Entities.Auth;
using Domain.Interface.Repository.Auth;
using Domain.Model.Auth;
using Microsoft.EntityFrameworkCore;

namespace Repository.Auth
{
    public class UserRepository : IUserRepository
    {
        public readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);

            return user;
        }

        public async Task Delete(Guid uuid)
        {
            var userDelete = await _context.Users.FirstOrDefaultAsync(c => c.Uuid == uuid);
            _context.Users.Remove(userDelete);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(Guid uuid)
        {
            var user = await _context.Users.Include(x => x.Profile).FirstOrDefaultAsync(c => c.Uuid == uuid);
            return user;
        }

        public async Task<User> Get(AuthRequest request)
        {
            return await _context.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => string.Equals(x.Name, request.Name)
            && x.Password == request.Password);
        }

        public async Task<User> Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return user;
        }
    }
}
