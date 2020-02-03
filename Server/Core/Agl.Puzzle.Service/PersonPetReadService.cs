using Agl.Puzzle.Data.Contracts;
using Agl.Puzzle.Models.Dto;
using Agl.Puzzle.Service.Contracts;
using System;
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
                .GroupBy(item => item.GenderType)
            .Select(group => new GenderPetSummaryDto()
            {
                GenderType = Enum.GetName(typeof(GenderType), group.Key),
                Pets = group.SelectMany(p=> p.Pets).OrderBy(q=>q.Name).ToList()
            })
            .ToList();
            return filteredGroupPersonData;
        }

        public IEnumerable<GenderPetCategoryDto> GetFilteredDataByPetType(PetType petType)
        {
            var personSummaryData = new List<GenderPetCategoryDto>();            
            var genderPets = _petApiClient.GetPersonPets();
            foreach (var genderPet in genderPets)
            {
                var genderPetCategoryDto = genderPet.BasicConvertTo<GenderPetCategoryDto>();
                var tempPets = new List<PetDto>();
                if (genderPet.Pets != null)
                {
                    foreach (var pet in genderPet.Pets.Where(p=>p.GetPetType() == petType))
                    {
                        var tempPetDto = pet.BasicConvertTo<PetDto>();
                        tempPetDto.PetType = pet.GetPetType();
                        tempPets.Add(tempPetDto);
                    }
                }
                genderPetCategoryDto.Pets = tempPets;
                genderPetCategoryDto.GenderType = genderPet.GetGenderType();
                personSummaryData.Add(genderPetCategoryDto);
            }
            return personSummaryData.ToList();
        }
    }
}
