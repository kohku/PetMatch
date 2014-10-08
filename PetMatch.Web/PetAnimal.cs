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
    public class PetAnimal : BusinessBase<PetAnimal, Guid>
    {
        private string _name;
        private bool _visible;

        public PetAnimal()
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
                if (this._name != value)
                {
                    this.OnPropertyChanging("Name");
                    this.MarkChanged("Name");
                }

                this._name = value;
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
                if (this._visible != value)
                {
                    this.OnPropertyChanging("Visible");
                    this.MarkChanged("Visible");
                }

                this._visible = value;
            }
        }

        protected override void ValidationRules()
        {
            AddRule("EmptyName", ResourceStringLoader.GetResourceString("PetAnimal_EmptyName"),
                string.IsNullOrEmpty(this.Name));
            AddRule("MaxNameLength", ResourceStringLoader.GetResourceString("PetAnimal_MaxNameLength"),
                !string.IsNullOrEmpty(this.Name) && this.Name.Length > 100);
            AddRule("EmptyCreatedBy", ResourceStringLoader.GetResourceString("PetAnimal_EmptyCreatedBy"),
                string.IsNullOrEmpty(this.CreatedBy));
            AddRule("MaxCreatedByLength", ResourceStringLoader.GetResourceString("PetAnimal_MaxCreatedByLength"),
                !string.IsNullOrEmpty(this.CreatedBy) && this.CreatedBy.Length > 256);
            AddRule("DuplicatedName", ResourceStringLoader.GetResourceString("PetAnimal_DuplicatedName", new { this.Name }),
                !string.IsNullOrEmpty(this.Name) && this.ChangedProperties.Contains("Name")
                && PetAnimal.GetPetAnimals(null, this.Name).Count(m => m.ID != this.ID) > 0);
            AddRule("EmptyLastUpdatedBy", ResourceStringLoader.GetResourceString("PetAnimal_EmptyLastUpdatedBy"),
                !this.IsNew && this.IsChanged && string.IsNullOrEmpty(this.LastUpdatedBy));
            AddRule("MaxLastUpdatedByLength", ResourceStringLoader.GetResourceString("PetAnimal_MaxLastUpdatedByLength"),
                !this.IsNew && this.IsChanged && !string.IsNullOrEmpty(this.LastUpdatedBy) && this.LastUpdatedBy.Length > 256);
        }

        protected override PetAnimal DataSelect(Guid id)
        {
            return PetAnimal.GetPetAnimals(id, null).FirstOrDefault();
        }

        protected override void DataUpdate()
        {
            PetMatch.Instance.UpdatePetAnimal(this);
        }

        protected override void DataInsert()
        {
            PetMatch.Instance.InsertPetAnimal(this);
        }

        protected override void DataDelete()
        {
            PetMatch.Instance.DeletePetAnimal(this);
        }

        public static IEnumerable<PetAnimal> GetPetAnimals(Guid? id, string name)
        {
            var results = new List<PetAnimal>(PetMatch.Instance.GetPetAnimals(id, name));

            foreach (var item in results)
                item.MarkOld();

            return results;
        }

        public static IEnumerable<PetAnimal> GetAll()
        {
            return PetAnimal.GetPetAnimals(null, null);
        }
    }
}
