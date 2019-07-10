using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLO.API.Models;
using OLO.Data;

namespace OLO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICartContext context;

        public TestController(ICartContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public async Task<Cart> Get(string id)
        {
            var test = context.Get(id);
            throw new NotImplementedException();
        }
    }
}