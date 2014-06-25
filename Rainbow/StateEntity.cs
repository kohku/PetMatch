using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Rainbow.Web.Utilities;

namespace Rainbow.Web
{
    public class StateEntity :  BusinessBase<StateEntity, Guid>
    {
        private string _name;
        private bool _visible;

        public StateEntity() 
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

        private IEnumerable<Province> _provinces;

        public IEnumerable<Province> Provinces
        {
            get
            {
                if (_provinces == null)
                {
                    lock(_provinces)
                    {
                        _provinces = Province.GetProvinces(this.ID);
                    }
                }
                return _provinces;
            }
        }

        protected override void ValidationRules()
        {
            AddRule("EmptyName", ResourceStringLoader.GetResourceString("StateEntity_EmptyName"), 
                string.IsNullOrEmpty(this.Name));
            AddRule("MaxNameLength", ResourceStringLoader.GetResourceString("StateEntity_MaxNameLength"),
                !string.IsNullOrEmpty(this.Name) && this.Name.Length > 100);
            AddRule("EmptyCreatedBy", ResourceStringLoader.GetResourceString("StateEntity_EmptyCreatedBy"), 
                string.IsNullOrEmpty(this.CreatedBy));
            AddRule("MaxCreatedByLength", ResourceStringLoader.GetResourceString("StateEntity_MaxCreatedByLength"), 
                !string.IsNullOrEmpty(this.CreatedBy) && this.CreatedBy.Length > 256);
            AddRule("DuplicatedName", ResourceStringLoader.GetResourceString("StateEntity_DuplicatedName", new { this.Name }),
                !string.IsNullOrEmpty(this.Name) && this.ChangedProperties.Contains("Name") 
                && StateEntity.GetStateEntities(this.Name).Where(m => m.ID != this.ID).Count() > 0);
            AddRule("EmptyLastUpdatedBy", ResourceStringLoader.GetResourceString("StateEntity_EmptyLastUpdatedBy"),
                !this.IsNew && this.IsChanged && string.IsNullOrEmpty(this.LastUpdatedBy));
            AddRule("MaxLastUpdatedByLength", ResourceStringLoader.GetResourceString("StateEntity_MaxLastUpdatedByLength"),
                !this.IsNew && this.IsChanged && !string.IsNullOrEmpty(this.LastUpdatedBy) && this.LastUpdatedBy.Length > 256);
        }

        protected override StateEntity DataSelect(Guid id)
        {
            return Rainbow.Instance.GetStateEntities(id, null).FirstOrDefault();
        }

        protected override void DataUpdate()
        {
            Rainbow.Instance.UpdateStateEntity(this);
        }

        protected override void DataInsert()
        {
            Rainbow.Instance.InsertStateEntity(this);
        }

        protected override void DataDelete()
        {
            Rainbow.Instance.DeleteStateEntity(this);
        }

        public static IEnumerable<StateEntity> GetAll()
        {
            return Rainbow.Instance.GetStateEntities(null, null);
        }

        public static IEnumerable<StateEntity> GetStateEntities(string name)
        {
            return Rainbow.Instance.GetStateEntities(null, name);
        }
    }
}
