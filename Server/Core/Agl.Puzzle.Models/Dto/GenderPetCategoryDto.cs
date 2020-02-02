using System.Collections.Generic;

namespace Agl.Puzzle.Models.Dto
{
    public class GenderPetCategoryDto
    {
        public GenderType GenderType { get; set; }
        public List<PetDto> Pets { get; set; }
    }
}
