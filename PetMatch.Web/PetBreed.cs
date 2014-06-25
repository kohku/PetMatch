using Rainbow.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetMatch.Web
{
    public class PetBreed : BusinessBase<PetBreed, Guid>
    {
        private string _name;
        private bool _visible;

        public PetBreed()
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
            AddRule("EmptyName", ResourceStringLoader.GetResourceString("PetBreed_EmptyName"),
                string.IsNullOrEmpty(this.Name));
            AddRule("MaxNameLength", ResourceStringLoader.GetResourceString("PetBreed_MaxNameLength"),
                !string.IsNullOrEmpty(this.Name) && this.Name.Length > 100);
            AddRule("EmptyCreatedBy", ResourceStringLoader.GetResourceString("PetBreed_EmptyCreatedBy"),
                string.IsNullOrEmpty(this.CreatedBy));
            AddRule("MaxCreatedByLength", ResourceStringLoader.GetResourceString("PetBreed_MaxCreatedByLength"),
                !string.IsNullOrEmpty(this.CreatedBy) && this.CreatedBy.Length > 256);
            AddRule("DuplicatedName", ResourceStringLoader.GetResourceString("PetBreed_DuplicatedName", new { this.Name }),
                !string.IsNullOrEmpty(this.Name) && this.ChangedProperties.Contains("Name")
                && PetBreed.GetBreeds(null, this.Name).Count(m => m.ID != this.ID) > 0);
            AddRule("EmptyLastUpdatedBy", ResourceStringLoader.GetResourceString("PetBreed_EmptyLastUpdatedBy"),
                !this.IsNew && this.IsChanged && string.IsNullOrEmpty(this.LastUpdatedBy));
            AddRule("MaxLastUpdatedByLength", ResourceStringLoader.GetResourceString("PetBreed_MaxLastUpdatedByLength"),
                !this.IsNew && this.IsChanged && !string.IsNullOrEmpty(this.LastUpdatedBy) && this.LastUpdatedBy.Length > 256);
        }

        protected override PetBreed DataSelect(Guid id)
        {
            return PetBreed.GetBreeds(id, null).FirstOrDefault();
        }

        protected override void DataUpdate()
        {
            PetMatch.Instance.UpdatePetBreed(this);
        }

        protected override void DataInsert()
        {
            PetMatch.Instance.InsertPetBreed(this);
        }

        protected override void DataDelete()
        {
            PetMatch.Instance.DeletePetBreed(this);
        }

        public static IEnumerable<PetBreed> GetBreeds(Guid? id, string name)
        {
            var results = new List<PetBreed>(PetMatch.Instance.GetBreeds(id, name));

            foreach (var item in results)
                item.MarkOld();

            return results;
        }
    }
}
