using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculoDB.Core.Clases;

namespace VehiculoDB.Core.Dao
{
    internal interface IMantenimientos
    {
        int Insert(Mantenimientos paMantenimiento);
        bool Update(Mantenimientos paMantenimiento);
        bool Delete(int idMantenimiento);
        Propietario GetById(int idMantenimiento);
        List<Propietario> GetAll(string filtro = "");
    }
}
