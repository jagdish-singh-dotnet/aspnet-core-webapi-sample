using SampleApp.Domain.Entities;

namespace SampleApp.Infrastructure.Data
{
    public static class InMemoryUserStore
    {
        public static List<User> Users = new()
        {
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Email = "admin@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456")
            }
        };
    }

}
