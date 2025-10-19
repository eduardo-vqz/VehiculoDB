using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculoDB.Core.Dao;

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


        public Vehiculos() { 
            marcas = new Marcas();
            propietario = new Propietario();
            tiposCarro = new TiposCarro();
        }

        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Anio { get => anio; set => anio = value; }
        public string Color { get => color; set => color = value; }
        public Marcas Marcas { get => marcas; set => marcas = value; }
        public Propietario Propietario { get => propietario; set => propietario = value; }
        public TiposCarro TiposCarro { get => tiposCarro; set => tiposCarro = value; }

        public int IdMarca { get => marcas.IdMarca; set => Marcas.IdMarca = value; }
        public string NombreMarca { get => marcas.NombreMarca; set => Marcas.NombreMarca = value; }
        public int IdPropietario { get => propietario.IdPropietario; set => propietario.IdPropietario = value; }
        public string DUI { get => propietario.DUI; set => propietario.DUI = value; }
        public int IdTipoCarro { get => tiposCarro.IdTipoCarro; set => tiposCarro.IdTipoCarro = value; }
        public string NombreTipo { get => tiposCarro.NombreTipo; set => tiposCarro.NombreTipo = value; }
    }
}
