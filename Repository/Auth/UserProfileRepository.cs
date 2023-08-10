using Database;
using Domain.Entities.Auth;
using Domain.Interface.Repository.Auth;
using Domain.Model.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Auth
{
    public class UserProfileRepository : IUserProfileRepository
    {
        public readonly AppDbContext _context;
        public UserProfileRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserProfile> Create(UserProfile profile)
        {
            _context.Profiles.Add(profile);

            return profile;
        }

        public async Task Delete(Guid uuid)
        {
            var profileDelete = await _context.Profiles.FirstOrDefaultAsync(c => c.Uuid == uuid);
            _context.Profiles.Remove(profileDelete);
        }

        public async Task<IEnumerable<UserProfile>> Get()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<UserProfile> Get(Guid uuid)
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(c => c.Uuid == uuid);
            return profile;
        }

        public async Task<UserProfile> Update(UserProfile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
            return profile;
        }
    }
}
