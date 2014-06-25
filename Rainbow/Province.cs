using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Rainbow.Web.Utilities;

namespace Rainbow.Web
{
    public class Province :  BusinessBase<Province, Guid>
    {
        private string _name;
        private bool _visible;
        private Guid _stateId;

        public Province() 
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

        [DataMember]
        public Guid StateID
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _stateId; }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                if (this._stateId != value)
                {
                    this.OnPropertyChanging("StateID");
                    this.MarkChanged("StateID");
                }

                this._stateId = value;
            }
        }

        private StateEntity _stateEntity;

        /// <summary>
        /// Lazy loading state
        /// </summary>
        public StateEntity StateEntity
        {
            get
            {
                if (_stateEntity == null)
                {
                    lock (syncRoot)
                    {
                        _stateEntity = StateEntity.Load(this.StateID);
                    }
                }

                return _stateEntity;
            }
        }

        protected override void ValidationRules()
        {
            AddRule("EmptyName", ResourceStringLoader.GetResourceString("Province_EmptyName"), 
                string.IsNullOrEmpty(this.Name));
            AddRule("MaxNameLength", ResourceStringLoader.GetResourceString("Province_MaxNameLength"),
                !string.IsNullOrEmpty(this.Name) && this.Name.Length > 100);
            AddRule("EmptyCreatedBy", ResourceStringLoader.GetResourceString("Province_EmptyCreatedBy"), 
                string.IsNullOrEmpty(this.CreatedBy));
            AddRule("MaxCreatedByLength", ResourceStringLoader.GetResourceString("Province_MaxCreatedByLength"), 
                !string.IsNullOrEmpty(this.CreatedBy) && this.CreatedBy.Length > 256);
            AddRule("EmptyStateID", ResourceStringLoader.GetResourceString("Province_EmptyStateID"),
                this.StateID == Guid.Empty);
            AddRule("DuplicatedName", ResourceStringLoader.GetResourceString("Province_DuplicatedName", new { this.Name }),
                !string.IsNullOrEmpty(this.Name) && this.ChangedProperties.Contains("Name") 
                && Province.GetProvinces(this.StateID, this.Name).Where(m => m.ID != this.ID).Count() > 0);
            AddRule("EmptyLastUpdatedBy", ResourceStringLoader.GetResourceString("Province_EmptyLastUpdatedBy"),
                !this.IsNew && this.IsChanged && string.IsNullOrEmpty(this.LastUpdatedBy));
            AddRule("MaxLastUpdatedByLength", ResourceStringLoader.GetResourceString("Province_MaxLastUpdatedByLength"),
                !this.IsNew && this.IsChanged && !string.IsNullOrEmpty(this.LastUpdatedBy) && this.LastUpdatedBy.Length > 256);
        }

        protected override Province DataSelect(Guid id)
        {
            return Rainbow.Instance.GetProvinces(id, null, null).FirstOrDefault();
        }

        protected override void DataUpdate()
        {
            Rainbow.Instance.UpdateProvince(this);
        }

        protected override void DataInsert()
        {
            Rainbow.Instance.InsertProvince(this);
        }

        protected override void DataDelete()
        {
            Rainbow.Instance.DeleteProvince(this);
        }

        public static IEnumerable<Province> GetAll()
        {
            return Rainbow.Instance.GetProvinces(null, null, null);
        }

        public static IEnumerable<Province> GetProvinces(Guid stateId)
        {
            return Rainbow.Instance.GetProvinces(null, stateId, null);
        }

        public static IEnumerable<Province> GetProvinces(Guid stateId, string name)
        {
            return Rainbow.Instance.GetProvinces(null, stateId, name);
        }

    }
}
