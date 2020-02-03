using System.Collections.Generic;
using Agl.Puzzle.Models;
using Agl.Puzzle.Models.Dto;

namespace Agl.Puzzle.Service.Contracts
{
    public interface IPersonPetReadService
    {
        List<GenderPetSummaryDto> GetCategorizePets(PetType petType = PetType.Cat);
        IEnumerable<GenderPetCategoryDto> GetFilteredDataByPetType(PetType petType);
    }
}
