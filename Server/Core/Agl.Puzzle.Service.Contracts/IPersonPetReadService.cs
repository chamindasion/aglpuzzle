using System;
using System.Collections.Generic;
using System.Text;
using Agl.Puzzle.Models.Dto;

namespace Agl.Puzzle.Service.Contracts
{
    public interface IPersonPetReadService
    {
        List<GenderPetSummaryDto> GetCategorisePets();
    }
}
