using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculoDB.Core.Clases;

namespace VehiculoDB.Core.Dao
{
    internal interface IVehiculo
    {
        int Insert(Vehiculos paVehiculo);
        bool Update(Vehiculos paVehiculo);
        bool Delete(int idVehiculo);
        Vehiculos GetById(int idVehiculo);
        List<Vehiculos> GetAll(string filtro = "");
    }
}
