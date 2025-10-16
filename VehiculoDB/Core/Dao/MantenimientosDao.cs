using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculoDB.Core.Clases;
using VehiculoDB.Core.Lib;

namespace VehiculoDB.Core.Dao
{
    internal class MantenimientosDao : Cnn, IMantenimientos
    {

        SqlConnection Con = null;
        SqlCommand command = null;

        public bool Delete(int idMantenimiento)
        {
            throw new NotImplementedException();
        }

        public List<Mantenimientos> GetAll(string filtro = "")
        {
            var lista = new List<Mantenimientos>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                string sql = @"
                            SELECT Mantenimientos.IdMantenimiento, Vehiculos.IdVehiculo, Vehiculos.Placa, Mantenimientos.Fecha, 
		                            Mantenimientos.Costo, Mantenimientos.Observaciones, TiposMantenimiento.IdTipoMantenimiento,
		                            TiposMantenimiento.NombreTipo
                            FROM Mantenimientos 
                            inner join Vehiculos on Vehiculos.IdVehiculo = Mantenimientos.IdMantenimiento
                            inner join TiposMantenimiento on TiposMantenimiento.IdTipoMantenimiento = Mantenimientos.IdTipoMantenimiento
                            /**where**/
                            ORDER BY IdMantenimiento DESC;";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql = sql.Replace("/**where**/", "WHERE IdMantenimiento LIKE @f ");
                }
                else
                {
                    sql = sql.Replace("/**where**/", string.Empty);
                }

                command = new SqlCommand(sql, Con);
                if (!string.IsNullOrWhiteSpace(filtro))
                    command.Parameters.Add("@f", System.Data.SqlDbType.Int).Value = $"%{filtro}%";

                rd = command.ExecuteReader();

                while (rd.Read())
                {
                    Mantenimientos mantenimientos = new Mantenimientos();

                    mantenimientos.IdMantenimiento = rd.GetInt32(0);
                    mantenimientos.Vehiculo.IdVehiculo = rd.GetInt32(1);
                    mantenimientos.Vehiculo.Placa = rd.GetString(2);
                    mantenimientos.Fecha = rd.GetDateTime(2);
                    mantenimientos.Costo = rd.GetDecimal(4); 
                    mantenimientos.Observaciones = rd.GetString(5);
                    mantenimientos.TiposMantenimiento.IdTipoMantenimiento = rd.GetInt32(6);
                    mantenimientos.TiposMantenimiento.NombreTipo = rd.GetString(7);

                    lista.Add(mantenimientos);
                }

            }
            catch(SqlException ex)
            {
                throw new ApplicationException("Ha sucedido un herror inesperado. " , ex);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }

            return lista;
        }
           
        public int Insert(Mantenimientos paMantenimiento)
        {
            throw new NotImplementedException();
        }

        public bool Update(Mantenimientos paMantenimiento)
        {
            throw new NotImplementedException();
        }

        Mantenimientos IMantenimientos.GetById(int idMantenimiento)
        {
            throw new NotImplementedException();
        }
    }
}
