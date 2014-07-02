using PetMatch.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMatch.Models
{
    public class PetAnimalIndexViewModel
    {
        public List<PetAnimal> PetAnimals
        {
            get
            {
                return new List<PetAnimal>(PetAnimal.GetAll());
            }
        }

        public PetAnimalCreateViewModel CreateViewModel { get; set; }
    }

    public class PetAnimalCreateViewModel
    {
        public string Name { get; set; }

        public bool Visible { get; set; }
    }
}