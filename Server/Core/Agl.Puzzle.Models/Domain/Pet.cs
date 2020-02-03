using System;
using Newtonsoft.Json;

namespace Agl.Puzzle.Models.Domain
{
    public class Pet
    {
        [JsonProperty("name")]
        public string  Name { get; set; }
        [JsonProperty("type")]
        public string  Type { get; set; }

        public PetType GetPetType()
        {
            return Enum.TryParse(this.Type, out PetType currentPetType) ? currentPetType : PetType.NotSpecified;
        }
    }
}
