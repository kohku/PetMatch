using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PetMatch.Web
{
    public class PetMatch :  IDisposable
    {
        private static volatile PetMatch instance;
        private static object syncRoot = new object();

        private IUnityContainer container;

        private PetMatch()
        {
            LoadConfiguration();
        }
        private void LoadConfiguration()
        {
            container = new UnityContainer().LoadConfiguration();
        }

        /// <summary>
        /// Gets a singleton instance of the <see cref="Rainbow"/> class.
        /// </summary>
        public static PetMatch Instance
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PetMatch();
                    }
                }
                return instance;
            }
        }

        public void Dispose()
        {
        }

        internal void UpdatePet(Pet pet)
        {
            container.Resolve<IPetMatchRepository>().UpdatePet(pet);
        }

        internal void InsertPet(Pet pet)
        {
            container.Resolve<IPetMatchRepository>().InsertPet(pet);
        }

        internal void DeletePet(Pet pet)
        {
            container.Resolve<IPetMatchRepository>().DeletePet(pet);
        }

        internal IEnumerable<Pet> GetPets(Guid? id, string name)
        {
            return container.Resolve<IPetMatchRepository>().GetPets(id, name);
        }

        internal void UpdatePetBreed(PetBreed breed)
        {
            container.Resolve<IPetMatchRepository>().UpdatePetBreed(breed);
        }

        internal void InsertPetBreed(PetBreed breed)
        {
            container.Resolve<IPetMatchRepository>().InsertPetBreed(breed);
        }

        internal void DeletePetBreed(PetBreed breed)
        {
            container.Resolve<IPetMatchRepository>().DeletePetBreed(breed);
        }

        internal IEnumerable<PetBreed> GetBreeds(Guid? id, string name)
        {
            return container.Resolve<IPetMatchRepository>().GetBreeds(id, name);
        }

        internal void UpdatePetType(PetType type)
        {
            container.Resolve<IPetMatchRepository>().PetType(type);
        }

        internal void InsertPetType(PetType type)
        {
            container.Resolve<IPetMatchRepository>().InsertPetType(type);
        }

        internal void DeletePetType(PetType type)
        {
            container.Resolve<IPetMatchRepository>().DeletePetType(type);
        }

        internal IEnumerable<PetType> GetPetTypes(Guid? id, string name)
        {
            return container.Resolve<IPetMatchRepository>().GetPetTypes(id, name);
        }
    }
}
