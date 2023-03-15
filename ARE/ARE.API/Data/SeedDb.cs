using ARE.API.Helpers;
using ARE.Shared.Entities;

namespace ARE.API.Data
{
	public class SeedDb
	{
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("Alberto", "Meza","Mata", "alberto_k1@hotmail.com", "322 311 4620", "Administrador");

        }

        private async Task<User> CheckUserAsync(string firstName, string lastName1, string lastName2, string email, string phone, string userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Name = firstName,
                    LastName1 = lastName1,
                    LastName2 = lastName2, 
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync("Administrador");
            await _userHelper.CheckRoleAsync("Usuario");
        }


        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Estados Unidos" });
            }

            await _context.SaveChangesAsync();
        }

    }
}

