using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace VehiculoDB.Core.Lib
{
    internal class Cnn
    {
        private readonly SqlConnection _conexion;

        public Cnn()
        {
            string cadena = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            _conexion = new SqlConnection(cadena);
        }

        public SqlConnection OpenDb()
        {
            try
            {
                if(_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                return _conexion;
            }
            catch (SqlException ex) {
                MessageBox.Show("Error al abrir la conexión a la DB: " + ex.Message, "DataBase", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void CloseDb()
        {
            try
            {
                if (_conexion.State != ConnectionState.Closed)
                    _conexion.Close();
            }
            catch (SqlException ex) {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message, "DataBase", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
