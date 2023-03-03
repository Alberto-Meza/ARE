using System;
using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/departments")]
    public class DepartmentsController : GenericController<Department>
    {
        public DepartmentsController(DataContext context) : base(context)
        {
        }
    }
}

