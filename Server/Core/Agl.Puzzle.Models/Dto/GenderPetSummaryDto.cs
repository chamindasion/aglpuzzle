using System.Collections.Generic;

namespace Agl.Puzzle.Models.Dto
{
    public class GenderPetSummaryDto
    {
        public string GenderType { get; set; }
        public List<PetDto> Pets { get; set; }
    }
}
