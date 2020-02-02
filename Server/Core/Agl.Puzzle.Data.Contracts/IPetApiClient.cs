using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agl.Puzzle.Models.Domain;

namespace Agl.Puzzle.Data.Contracts
{
    public interface IPetApiClient
    {
        List<Person> GetPersonPets();
    }
}
