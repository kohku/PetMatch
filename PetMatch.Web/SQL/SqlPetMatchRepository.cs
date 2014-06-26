using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMatch.Web.Sql
{
    public class SqlPetMatchRepository : IPetMatchRepository
    {
        private string _connectionStringName;

        public SqlPetMatchRepository(string connectionStringName)
        {
            this._connectionStringName = connectionStringName;
        }

        public string ConnectionStringName
        {
            get { return this._connectionStringName; }
        }

        public void UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void InsertPet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void DeletePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetPets(Guid? id, string name)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetBreed(PetBreed breed)
        {
            throw new NotImplementedException();
        }

        public void InsertPetBreed(PetBreed breed)
        {
            throw new NotImplementedException();
        }

        public void DeletePetBreed(PetBreed breed)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetBreed> GetBreeds(Guid? id, string name)
        {
            throw new NotImplementedException();
        }

        public void PetType(PetType type)
        {
            throw new NotImplementedException();
        }

        public void InsertPetType(PetType type)
        {
            throw new NotImplementedException();
        }

        public void DeletePetType(PetType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetType> GetPetTypes(Guid? id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
