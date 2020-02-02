using Agl.Puzzle.Data.Contracts;
using Agl.Puzzle.Models.Dto;
using Agl.Puzzle.Service.Contracts;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Agl.Puzzle.Models;

namespace Agl.Puzzle.Service
{
    public class PersonPetReadService : IPersonPetReadService
    {

        private readonly IPetApiClient _petApiClient;
        
        public PersonPetReadService(IServiceProvider serviceProvider)
        {
            _petApiClient = serviceProvider.GetService<IPetApiClient>();
        }

        public List<GenderPetSummaryDto> GetCategorisePets()
        {            
            var resultDtos = GetFilteredDataByPetType(PetType.Cat)
                .GroupBy(item => item.GenderType)
            .Select(group => new GenderPetSummaryDto()
            {
                GenderType = Enum.GetName(typeof(GenderType), group.Key),
                Pets = group.SelectMany(p=> p.Pets).OrderBy(q=>q.Name).ToList()
            })
            .ToList();
            return resultDtos;
        }

        private IEnumerable<GenderPetCategoryDto> GetFilteredDataByPetType(PetType petType)
        {
            var resultDtos = new List<GenderPetCategoryDto>();            
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
                resultDtos.Add(genderPetCategoryDto);
            }
            return resultDtos.ToList();
        }
    }
}
