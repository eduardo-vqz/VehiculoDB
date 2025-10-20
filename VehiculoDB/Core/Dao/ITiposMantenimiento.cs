using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculoDB.Core.Clases;

namespace VehiculoDB.Core.Dao
{
    internal interface ITiposMantenimiento
    {
        int Insert(TiposMantenimiento paTiposMantenimiento);
        bool Update(TiposMantenimiento paTiposMantenimiento);
        bool Delete(int idTiposMantenimiento);
        TiposMantenimiento GetById(int idTiposMantenimiento);
        List<TiposMantenimiento> GetAll(string filtro = "");
    }
}
