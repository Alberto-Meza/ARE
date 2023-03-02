using System;
using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/cities")]
    public class CitiesController : GenericRepository<City>
    {
		public CitiesController(DataContext context) : base(context)
        {
		}
	}
}

