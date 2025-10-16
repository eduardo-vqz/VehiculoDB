using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculoDB.Core.Clases
{
    internal class Marcas
    {
        private int idMarca;
        private string nombreMarca;

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string NombreMarca { get => nombreMarca; set => nombreMarca = value; }
    }
}
