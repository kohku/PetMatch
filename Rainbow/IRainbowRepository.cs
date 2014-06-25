using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow.Web
{
    public interface IRainbowRepository
    {
        IEnumerable<StateEntity> GetStateEntities(Guid? id, string name);
        void UpdateStateEntity(StateEntity province);

        void InsertStateEntity(StateEntity province);

        void DeleteStateEntity(StateEntity province);

        IEnumerable<Province> GetProvinces(Guid? id, Guid? stateId, string name);

        void UpdateProvince(Province province);

        void InsertProvince(Province province);

        void DeleteProvince(Province province);
    }
}
