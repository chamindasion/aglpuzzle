using System.Collections.Generic;
using Agl.Puzzle.Models.Domain;

namespace Agl.Puzzle.Data.Contracts
{
    public interface IPetApiClient
    {
        List<Person> GetAllPerson();
    }
}
