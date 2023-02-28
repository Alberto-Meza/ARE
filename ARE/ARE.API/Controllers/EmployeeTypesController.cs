using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/employeeTypes")]
    public class EmployeeTypesControllers : GenericRepository<EmployeeType>
    {
        public EmployeeTypesControllers(DataContext context) : base(context)
        {

        }
    }
}

