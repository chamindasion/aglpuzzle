using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agl.Puzzle.Models;
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
        public PersonPetSummaryController(IPersonPetReadService personPetReadService)
        {
            _personPetReadService = personPetReadService;
        }

        /// <summary>
        /// Return Person Summary by Gender and then list of pets name with filter by type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GenderPetSummaryDto> Get(PetType petType)
        {
            return _personPetReadService.GetCategorizePets(petType);
        }       
    }
}
