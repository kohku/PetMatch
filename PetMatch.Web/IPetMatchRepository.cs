using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetMatch.Web
{
    public interface IPetMatchRepository
    {
        void UpdatePet(Pet pet);
        void InsertPet(Pet pet);
        void DeletePet(Pet pet);
        IEnumerable<Pet> GetPets(Guid? id, string name);

        void UpdatePetBreed(PetBreed breed);
        void InsertPetBreed(PetBreed breed);
        void DeletePetBreed(PetBreed breed);
        IEnumerable<PetBreed> GetBreeds(Guid? id, string name);

        void PetType(PetType type);
        void InsertPetType(PetType type);
        void DeletePetType(PetType type);
        IEnumerable<PetType> GetPetTypes(Guid? id, string name);
    }
}
