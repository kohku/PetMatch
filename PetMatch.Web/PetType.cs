using Rainbow.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetMatch.Web
{
    public class PetType : BusinessBase<PetType, Guid>
    {
        private string _name;
        private bool _visible;

        public PetType()
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
            AddRule("EmptyName", ResourceStringLoader.GetResourceString("PetType_EmptyName"),
                string.IsNullOrEmpty(this.Name));
            AddRule("MaxNameLength", ResourceStringLoader.GetResourceString("PetType_MaxNameLength"),
                !string.IsNullOrEmpty(this.Name) && this.Name.Length > 100);
            AddRule("EmptyCreatedBy", ResourceStringLoader.GetResourceString("PetType_EmptyCreatedBy"),
                string.IsNullOrEmpty(this.CreatedBy));
            AddRule("MaxCreatedByLength", ResourceStringLoader.GetResourceString("PetType_MaxCreatedByLength"),
                !string.IsNullOrEmpty(this.CreatedBy) && this.CreatedBy.Length > 256);
            AddRule("DuplicatedName", ResourceStringLoader.GetResourceString("PetType_DuplicatedName", new { this.Name }),
                !string.IsNullOrEmpty(this.Name) && this.ChangedProperties.Contains("Name")
                && PetType.GetPetTypes(null, this.Name).Count(m => m.ID != this.ID) > 0);
            AddRule("EmptyLastUpdatedBy", ResourceStringLoader.GetResourceString("PetType_EmptyLastUpdatedBy"),
                !this.IsNew && this.IsChanged && string.IsNullOrEmpty(this.LastUpdatedBy));
            AddRule("MaxLastUpdatedByLength", ResourceStringLoader.GetResourceString("PetType_MaxLastUpdatedByLength"),
                !this.IsNew && this.IsChanged && !string.IsNullOrEmpty(this.LastUpdatedBy) && this.LastUpdatedBy.Length > 256);
        }

        protected override PetType DataSelect(Guid id)
        {
            return PetType.GetPetTypes(id, null).FirstOrDefault();
        }

        protected override void DataUpdate()
        {
            PetMatch.Instance.UpdatePetType(this);
        }

        protected override void DataInsert()
        {
            PetMatch.Instance.InsertPetType(this);
        }

        protected override void DataDelete()
        {
            PetMatch.Instance.DeletePetType(this);
        }

        public static IEnumerable<PetType> GetPetTypes(Guid? id, string name)
        {
            var results = new List<PetType>(PetMatch.Instance.GetPetTypes(id, name));

            foreach (var item in results)
                item.MarkOld();

            return results;
        }
    }
}
