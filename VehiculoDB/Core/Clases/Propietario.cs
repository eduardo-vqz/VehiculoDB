namespace VehiculoDB.Core.Clases
{
    internal class Propietario
    {
        private int idPropietario;
        private string nombre;
        private string apellido;
        private string dUI;
        private string telefono;
        private string direccion;

        

        public int IdPropietario { get => idPropietario; set => idPropietario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string DUI { get => dUI; set => dUI = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}

