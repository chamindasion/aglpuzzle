using System;

namespace Agl.Puzzle.Models.Domain
{
    public class Pet
    {
        public string  Name { get; set; }
        public string  Type { get; set; }

        public PetType GetPetType()
        {
            return Enum.TryParse(this.Type, out PetType currentPetType) ? currentPetType : PetType.NotSpecified;
        }
    }
}
