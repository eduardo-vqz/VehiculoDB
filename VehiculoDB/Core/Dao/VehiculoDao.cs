using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculoDB.Core.Clases;
using VehiculoDB.Core.Lib;

namespace VehiculoDB.Core.Dao
{
    internal class VehiculoDao : Cnn, IVehiculo
    {
        SqlConnection Con = null;
        SqlCommand command = null;

        bool IVehiculo.Delete(int idVehiculo)
        {
            throw new NotImplementedException();
        }

        List<Vehiculos> IVehiculo.GetAll(string filtro)
        {
            var lista = new List<Vehiculos>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                string sql = @"Select Vehiculos.IdVehiculo, Vehiculos.Placa, Vehiculos.Modelo, Vehiculos.Anio, Vehiculos.Color, 
		                            Marcas.IdMarca, Marcas.NombreMarca, 
		                            Propietarios.IdPropietario, Propietarios.DUI, 
		                            TiposCarro.IdTipoCarro, TiposCarro.NombreTipo
                            from Vehiculos 
	                            inner join Marcas on Vehiculos.IdMarca = Marcas.IdMarca
	                            inner join Propietarios on Vehiculos.IdPropietario = Propietarios.IdPropietario
	                            inner join TiposCarro on Vehiculos.IdTipoCarro = TiposCarro.IdTipoCarro
                            /**where**/
                            ORDER BY IdVehiculo DESC;";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql = sql.Replace("/**where**/", "WHERE Vehiculos.Placa LIKE @f ");
                }
                else
                {
                    sql = sql.Replace("/**where**/", string.Empty);
                }

                command = new SqlCommand(sql, Con);
                if (!string.IsNullOrWhiteSpace(filtro))
                    command.Parameters.Add("@f", System.Data.SqlDbType.VarChar).Value = $"%{filtro}%";

                rd = command.ExecuteReader();

                while (rd.Read())
                {
                    lista.Add(Map(rd));
                }

            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Ha sucedido un herror inesperado. ", ex);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }

            return lista;
        }

        private static Vehiculos Map(SqlDataReader rd) => new Vehiculos
        {
            IdVehiculo = rd.GetInt32(0),
            Placa = rd.GetString(1),
            Modelo = rd.GetString(2),
            Anio = rd.GetInt32(3),
            Color = rd.GetString(4),
            IdMarca = rd.GetInt32(5),
            NombreMarca = rd.GetString(6),
            IdPropietario = rd.GetInt32(7),
            DUI = rd.GetString(8),
            IdTipoCarro = rd.GetInt32(9),
            NombreTipo = rd.GetString(10),

        };


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
