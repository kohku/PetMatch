using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Rainbow.Web
{
    public sealed class Rainbow :  IDisposable
    {
        private static volatile Rainbow instance;
        private static object syncRoot = new object();

        private IUnityContainer container;

        private Rainbow()
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
        public static Rainbow Instance
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Rainbow();
                    }
                }
                return instance;
            }
        }

        public void Dispose()
        {
        }

        #region State entity

        internal IEnumerable<StateEntity> GetStateEntities(Guid? id, string name)
        {
            return container.Resolve<IRainbowRepository>().GetStateEntities(id, name);
        }

        internal void UpdateStateEntity(StateEntity stateProvince)
        {
            container.Resolve<IRainbowRepository>().UpdateStateEntity(stateProvince);
        }

        internal void InsertStateEntity(StateEntity stateProvince)
        {
            container.Resolve<IRainbowRepository>().InsertStateEntity(stateProvince);
        }

        internal void DeleteStateEntity(StateEntity stateProvince)
        {
            container.Resolve<IRainbowRepository>().DeleteStateEntity(stateProvince);
        }

        #endregion

        #region Province

        internal IEnumerable<Province> GetProvinces(Guid? id, Guid? stateId, string name)
        {
            return container.Resolve<IRainbowRepository>().GetProvinces(id, stateId, name);
        }

        internal void UpdateProvince(Province province)
        {
            container.Resolve<IRainbowRepository>().UpdateProvince(province);
        }

        internal void InsertProvince(Province province)
        {
            container.Resolve<IRainbowRepository>().InsertProvince(province);
        }

        internal void DeleteProvince(Province province)
        {
            container.Resolve<IRainbowRepository>().DeleteProvince(province);
        }

        #endregion
    }
}
