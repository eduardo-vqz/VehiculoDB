using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculoDB.Core.Clases
{
    internal class Mantenimientos
    {
        private int idMantenimiento;
        private Vehiculos vehiculo;
        private string fecha;
        private decimal costo;
        private string observaciones;
        private TiposMantenimiento tiposMantenimiento;

        public Mantenimientos() { 
            vehiculo = new Vehiculos();
            tiposMantenimiento = new TiposMantenimiento();
        }

        public int IdMantenimiento { get => idMantenimiento; set => idMantenimiento = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        internal Vehiculos Vehiculo { get => vehiculo; set => vehiculo = value; }
        internal TiposMantenimiento TiposMantenimiento { get => tiposMantenimiento; set => tiposMantenimiento = value; }
    }
}
