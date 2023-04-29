using ARE.API.Helpers;
using ARE.Shared.Entities;
using ARE.Shared.Enums;

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
            await BloodTypesAsync();
            await CheckCountriesAsync();
            await CivilStatusAsync();
            await SchoolGradesAsync();
            await StudentTypeAsync();
            await CheckRolesAsync();
            await CheckUserAsync("Alberto", "Meza","Mata", "alberto_k1@hotmail.com", "322 311 4620", UserType.Interno);

        }

        private async Task<User> CheckUserAsync(string firstName, string lastName1, string lastName2, string email, string phone, UserType userType)
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
                    PhoneNumber = phone,
                    UserType = UserType.Interno
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync("Interno");
            await _userHelper.CheckRoleAsync("Externo");
        }

        private async Task BloodTypesAsync()
        {
            if (!_context.BloodTypes.Any())
            {
                _context.BloodTypes.Add(new BloodType { Name = "A-" });
                _context.BloodTypes.Add(new BloodType { Name = "A+" });
                _context.BloodTypes.Add(new BloodType { Name = "AB+" });
                _context.BloodTypes.Add(new BloodType { Name = "AB-" });
                _context.BloodTypes.Add(new BloodType { Name = "B+" });
                _context.BloodTypes.Add(new BloodType { Name = "B-" });
                _context.BloodTypes.Add(new BloodType { Name = "O+" });
                _context.BloodTypes.Add(new BloodType { Name = "O-" });
                
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                Country country = new Country() { Name = "Mexico", States = new List<State>() };
                State state = new State() { Name = "Sinaloa", Cities = new List<City>() };
                City city = new City() { Name = "Los Mochis" };

                state.Cities.Add(city);
                country.States.Add(state);

                _context.Countries.Add(country);
            }

            await _context.SaveChangesAsync();
        }

        private async Task CivilStatusAsync()
        {
            if (!_context.CivilStatuses.Any())
            {
                _context.CivilStatuses.Add(new CivilStatus { Name = "Casados" });
                _context.CivilStatuses.Add(new CivilStatus { Name = "Divorciados" });
                _context.CivilStatuses.Add(new CivilStatus { Name = "Separados" });
            }

            await _context.SaveChangesAsync();
        }

        private async Task SchoolGradesAsync()
        {
            if (!_context.SchoolGrades.Any())
            {
                _context.SchoolGrades.Add(new SchoolGrade { Name = "1ro" });
                _context.SchoolGrades.Add(new SchoolGrade { Name = "2do" });
                _context.SchoolGrades.Add(new SchoolGrade { Name = "2do Pre Escolar" });
                _context.SchoolGrades.Add(new SchoolGrade { Name = "3ro" });
                _context.SchoolGrades.Add(new SchoolGrade { Name = "3ro Pre Escolar" });
                _context.SchoolGrades.Add(new SchoolGrade { Name = "4to" });
                _context.SchoolGrades.Add(new SchoolGrade { Name = "5to" });
                _context.SchoolGrades.Add(new SchoolGrade { Name = "6to" });
            }

            await _context.SaveChangesAsync();
        }

        private async Task StudentTypeAsync()
        {
            if (!_context.StudentTypes.Any())
            {
                _context.StudentTypes.Add(new StudentType { Name = "Alumno", Descriptions = "Asiste a clases Normales" });
                _context.StudentTypes.Add(new StudentType { Name = "Psicologia", Descriptions = "Psicologia" });
                _context.StudentTypes.Add(new StudentType { Name = "Terapia", Descriptions = "Terapia de Lenguaje" });
            }

            await _context.SaveChangesAsync();
        }

    }
}

