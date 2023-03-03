using System;
using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/branchOffices")]
    public class BranchOfficesController : GenericController<BranchOffice>
    {
        public BranchOfficesController(DataContext context) : base(context)
        {
        }
    }
}

