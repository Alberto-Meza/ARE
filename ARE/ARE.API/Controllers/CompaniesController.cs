using System;
using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/companies")]
    public class CompaniesController : GenericController<Company>
    {
        public CompaniesController(DataContext context) : base(context)
        {
        }
    }
}

