using Agl.Puzzle.Data.Contracts;
using Agl.Puzzle.Models.Dto;
using Agl.Puzzle.Service.Contracts;
using System.Collections.Generic;
using System.Linq;
using Agl.Puzzle.Models;

namespace Agl.Puzzle.Service
{
    public class PersonPetReadService : IPersonPetReadService
    {

        private readonly IPetApiClient _petApiClient;

        public PersonPetReadService(IPetApiClient petApiClient)
        {
            _petApiClient = petApiClient;
        }

        public List<GenderPetSummaryDto> GetCategorizePets(PetType petType)
        {
            var filteredGroupPersonData = GetFilteredDataByPetType(petType)
            .Select(group => new GenderPetSummaryDto()
            {
                GenderType = group.GenderType.ToString(),
                Pets = group.Pets.OrderBy(q => q.Name).ToList()
            }).ToList();
            return filteredGroupPersonData;
        }

        public IEnumerable<GenderPetCategoryDto> GetFilteredDataByPetType(PetType petType)
        {
            return _petApiClient.GetAllPerson()
                .Where(p => p.Pets != null && p.Pets.Any(pp => pp.GetPetType() == petType))
                .GroupBy(p => p.GetGenderType())
                .Select(group => new GenderPetCategoryDto
                {
                    GenderType = group.Key,
                    Pets = group.ToList()
                        .SelectMany(p => p.Pets)
                        .Where(q => q.GetPetType() == petType)
                        .Select(q => q.BasicConvertTo<PetDto>()).ToList()
                });
        }
    }
}
