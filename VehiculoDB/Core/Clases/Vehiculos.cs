using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculoDB.Core.Clases
{
    internal class Vehiculos
    {
        private int idVehiculo;
        private string placa;
        private string modelo;
        private int anio;
        private string color;
        private Marcas marcas;
        private Propietario propietario;
        private TiposCarro tiposCarro;

        Vehiculos() { 
            marcas = new Marcas();
            propietario = new Propietario();
            tiposCarro = new TiposCarro();
        }

        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Anio { get => anio; set => anio = value; }
        public string Color { get => color; set => color = value; }
        internal Marcas Marcas { get => marcas; set => marcas = value; }
        internal Propietario Propietario { get => propietario; set => propietario = value; }
        internal TiposCarro TiposCarro { get => tiposCarro; set => tiposCarro = value; }
    }
}
