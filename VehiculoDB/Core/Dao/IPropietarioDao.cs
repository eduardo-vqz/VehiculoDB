using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculoDB.Core.Clases;

namespace VehiculoDB.Core.Dao
{
    internal interface IPropietarioDao
    {
        int Insert(Propietario paPropietario);
        bool Update(Propietario paPropietario);
        bool Delete(int idPropietario);
        Propietario GetById(int idPropietario);
        List<Propietario> GetAll(string filtro = "");


    }
}
