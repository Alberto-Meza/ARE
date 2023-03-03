using System;
using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/jobs")]
    public class JobsController : GenericController<Job>
    {
        public JobsController(DataContext context) : base(context)
        {
        }
    }
}

