using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Agl.Puzzle.Models.Domain
{
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }
        public GenderType GetGenderType()
        {            
            return Enum.TryParse(this.Gender, out GenderType currentGender) ? currentGender : GenderType.NotSpecified;
        }
    }
}
