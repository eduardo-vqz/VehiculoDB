using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculoDB.Core.Clases;
using VehiculoDB.Core.Lib;

namespace VehiculoDB.Core.Dao
{
    internal class VehiculoDao : Cnn, IVehiculo
    {
        bool IVehiculo.Delete(int idVehiculo)
        {
            throw new NotImplementedException();
        }

        List<Vehiculos> IVehiculo.GetAll(string filtro)
        {
            throw new NotImplementedException();
        }

        Vehiculos IVehiculo.GetById(int idVehiculo)
        {
            throw new NotImplementedException();
        }

        int IVehiculo.Insert(Vehiculos paVehiculo)
        {
            throw new NotImplementedException();
        }

        bool IVehiculo.Update(Vehiculos paVehiculo)
        {
            throw new NotImplementedException();
        }
    }
}
