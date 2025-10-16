using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculoDB.Core.Clases
{
    internal class TiposCarro
    {
        private int idTipoCarro;
        private string nombreCarro;

        public int IdTipoCarro { get => idTipoCarro; set => idTipoCarro = value; }
        public string NombreCarro { get => nombreCarro; set => nombreCarro = value; }
    }
}
