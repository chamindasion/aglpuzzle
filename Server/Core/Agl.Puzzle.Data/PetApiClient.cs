using System.Collections.Generic;
using Agl.Puzzle.Data.Contracts;
using Agl.Puzzle.Models;
using Agl.Puzzle.Models.Domain;
using RestSharp;

namespace Agl.Puzzle.Data
{
    public class PetApiClient : ApiClientBase, IPetApiClient
    {
        public PetApiClient(AglConfiguration configuration): base(configuration)
        {
            
        }
        public List<Person> GetPersonPets()
        {
            var request = new RestRequest("/people.json", Method.GET);
            return Execute<List<Person>>(request);
        }
    }
}
