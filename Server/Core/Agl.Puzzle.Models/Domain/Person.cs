using System;
using System.Collections.Generic;

namespace Agl.Puzzle.Models.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
        public GenderType GetGenderType()
        {            
            return Enum.TryParse(this.Gender, out GenderType currentGender) ? currentGender : GenderType.NotSpecified;
        }
    }
}
