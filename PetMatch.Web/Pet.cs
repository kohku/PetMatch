using Rainbow.Web;
using Rainbow.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetMatch.Web
{
    public class Pet : BusinessBase<Pet, Guid>
    {
        private string _name;
        private bool _visible;
        private DateTime? _birthDate;
        private string _gender;
        private Guid _petAnimalId;
        private PetAnimal _petAnimal;
        private Guid _breedId;
        private PetBreed _breed;

        public Pet()
            : base(Guid.NewGuid())
        {
        }

        [DataMember]
        public string Name
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _name; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                var changed = !object.Equals(this._name, value);
                if (changed)
                    this.OnPropertyChanging("Name");
                this._name = value;
                if (changed)
                    MarkChanged("Name");
            }
        }

        [DataMember]
        public bool Visible
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _visible; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                var changed = !object.Equals(this._visible, value);
                if (changed)
                    this.OnPropertyChanging("Visible");
                this._visible = value;
                if (changed)
                    MarkChanged("Visible");
            }
        }

        public DateTime? BirthDate
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _birthDate; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (this._birthDate != value)
                {
                    this.OnPropertyChanging("Visible");
                    this.MarkChanged("Visible");
                }

                this._birthDate = value;
            }
        }

        public string Gender
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _gender; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (this._gender != value)
                {
                    this.OnPropertyChanging("Gender");
                    this.MarkChanged("Gender");
                }

                this._gender = value;
            }
        }

        public Guid TypeID
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _petAnimalId; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (this._petAnimalId != value)
                {
                    this.OnPropertyChanging("TypeID");
                    this.MarkChanged("TypeID");
                }

                this._petAnimalId = value;
            }
        }

        public PetAnimal PetAnimal
        {
            [System.Diagnostics.DebuggerStepThrough]
            get 
            {
                if (_petAnimal == null)
                {
                    lock (syncRoot)
                    {
                        if (_petAnimal == null)
                            _petAnimal = PetAnimal.Load(this.TypeID);
                    }
                }
                
                return _petAnimal; 
            }
        }

        public Guid BreedID
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _breedId; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (this._breedId != value)
                {
                    this.OnPropertyChanging("BreedID");
                    this.MarkChanged("BreedID");
                }

                this._breedId = value;
            }
        }

        public PetBreed Breed
        {
            [System.Diagnostics.DebuggerStepThrough]
            get 
            {
                if (_breed == null)
                {
                    lock (syncRoot)
                    {
                        if (_breed == null)
                            _breed = PetBreed.Load(this.BreedID);
                    }
                } 

                return _breed;
            }
        }

        protected override void ValidationRules()
        {
            AddRule("EmptyName", ResourceStringLoader.GetResourceString("Pet_EmptyName"),
                string.IsNullOrEmpty(this.Name));
            AddRule("MaxNameLength", ResourceStringLoader.GetResourceString("Pet_MaxNameLength"),
                !string.IsNullOrEmpty(this.Name) && this.Name.Length > 100);
            AddRule("EmptyCreatedBy", ResourceStringLoader.GetResourceString("Pet_EmptyCreatedBy"),
                string.IsNullOrEmpty(this.CreatedBy));
            AddRule("MaxCreatedByLength", ResourceStringLoader.GetResourceString("Pet_MaxCreatedByLength"),
                !string.IsNullOrEmpty(this.CreatedBy) && this.CreatedBy.Length > 256);
            AddRule("DuplicatedName", ResourceStringLoader.GetResourceString("Pet_DuplicatedName", new { this.Name }),
                !string.IsNullOrEmpty(this.Name) && this.ChangedProperties.Contains("Name")
                && Pet.GetPets(null, this.Name).Count(m => m.ID != this.ID) > 0);
            AddRule("EmptyLastUpdatedBy", ResourceStringLoader.GetResourceString("Pet_EmptyLastUpdatedBy"),
                !this.IsNew && this.IsChanged && string.IsNullOrEmpty(this.LastUpdatedBy));
            AddRule("MaxLastUpdatedByLength", ResourceStringLoader.GetResourceString("Pet_MaxLastUpdatedByLength"),
                !this.IsNew && this.IsChanged && !string.IsNullOrEmpty(this.LastUpdatedBy) && this.LastUpdatedBy.Length > 256);
        }

        protected override Pet DataSelect(Guid id)
        {
            return Pet.GetPets(id, null).FirstOrDefault();
        }

        protected override void DataUpdate()
        {
            PetMatch.Instance.UpdatePet(this);
        }

        protected override void DataInsert()
        {
            PetMatch.Instance.InsertPet(this);
        }

        protected override void DataDelete()
        {
            PetMatch.Instance.DeletePet(this);
        }

        public static IEnumerable<Pet> GetPets(Guid? id, string name)
        {
            var results = new List<Pet>(PetMatch.Instance.GetPets(id, name));

            foreach (var item in results)
                item.MarkOld();

            return results;
        }
    }
}
