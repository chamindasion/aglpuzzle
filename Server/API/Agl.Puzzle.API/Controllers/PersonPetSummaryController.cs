using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agl.Puzzle.Models.Dto;
using Agl.Puzzle.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Agl.Puzzle.API.Controllers
{
    [Produces("application/json")]
    [Route("api/summaryresponse")]
    public class PersonPetSummaryController : Controller
    {
        private readonly IPersonPetReadService _personPetReadService;
        public PersonPetSummaryController(IServiceProvider serviceProvider)
        {
            _personPetReadService = serviceProvider.GetService<IPersonPetReadService>();
        }

        // GET: api/summaryresponse
        [HttpGet]
        public IEnumerable<GenderPetSummaryDto> Get()
        {
            return _personPetReadService.GetCategorisePets();
        }       
    }
}
