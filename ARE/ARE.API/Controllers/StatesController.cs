using System;
using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/states")]
    public class StatesController : GenericRepository<State>
    {
		public StatesController(DataContext context) : base(context)
        {
		}
	}
}

