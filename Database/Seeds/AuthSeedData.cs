using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Util.Enumerator;

namespace Database.Seeds
{
    public static class AuthSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedProfiles(modelBuilder);
            SeedUsers(modelBuilder);
        }

        private static void SeedProfiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile
                {
                    Id = 1,
                    Name = "Admnistrador",
                    Description = "Perfil de Administrador",
                    Status = ERegisterStatus.ACTIVE
                }
            );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@teste.com",
                    Password = "1234",
                    Status = ERegisterStatus.ACTIVE,
                    ProfileId = 1,
                    UserGroupId = null,
                }
            );
        }
    }

}
