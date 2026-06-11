using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace VehiculoDB.Core.Lib
{
    /// <summary>
    /// Administra la conexion a SQL Server utilizada por los DAO del sistema.
    /// La clase no muestra mensajes en pantalla; solo lanza excepciones para que la capa de presentacion las gestione.
    /// </summary>
    internal class Cnn
    {
        private readonly SqlConnection _conexion;

        public Cnn()
        {
            ConnectionStringSettings? configuracion = ConfigurationManager.ConnectionStrings["SqlConn"];

            if (configuracion == null || string.IsNullOrWhiteSpace(configuracion.ConnectionString))
                throw new InvalidOperationException("No se encontro la cadena de conexion 'SqlConn' en App.config.");

            _conexion = new SqlConnection(configuracion.ConnectionString);
        }

        /// <summary>
        /// Abre la conexion si se encuentra cerrada y devuelve la instancia activa.
        /// </summary>
        /// <returns>Conexion abierta a SQL Server.</returns>
        public SqlConnection OpenDb()
        {
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                return _conexion;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible abrir la conexion a la base de datos.", ex);
            }
        }

        /// <summary>
        /// Cierra la conexion si se encuentra abierta.
        /// </summary>
        public void CloseDb()
        {
            try
            {
                if (_conexion.State != ConnectionState.Closed)
                    _conexion.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible cerrar la conexion a la base de datos.", ex);
            }
        }
    }
}
