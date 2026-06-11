using Microsoft.Data.SqlClient;
using System.Data;
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
            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"DELETE FROM Mantenimientos WHERE IdMantenimiento = @Id;", Con);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = idMantenimiento;

                return command.ExecuteNonQuery() == 1;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No se pudo eliminar el mantenimiento seleccionado.", ex);
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }

        public List<Mantenimientos> GetAll(string filtro = "")
        {
            var lista = new List<Mantenimientos>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                string sql = @"
                            SELECT Mantenimientos.IdMantenimiento, Vehiculos.IdVehiculo, Vehiculos.Placa,
                                   Mantenimientos.Fecha, Mantenimientos.Costo, Mantenimientos.Observaciones,
                                   TiposMantenimiento.IdTipoMantenimiento, TiposMantenimiento.NombreTipo
                            FROM Mantenimientos
                            INNER JOIN Vehiculos ON Vehiculos.IdVehiculo = Mantenimientos.IdVehiculo
                            INNER JOIN TiposMantenimiento ON TiposMantenimiento.IdTipoMantenimiento = Mantenimientos.IdTipoMantenimiento
                            /**where**/
                            ORDER BY Mantenimientos.IdMantenimiento DESC;";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql = sql.Replace("/**where**/", "WHERE Vehiculos.Placa LIKE @f OR TiposMantenimiento.NombreTipo LIKE @f");
                }
                else
                {
                    sql = sql.Replace("/**where**/", string.Empty);
                }

                command = new SqlCommand(sql, Con);
                if (!string.IsNullOrWhiteSpace(filtro))
                    command.Parameters.Add("@f", SqlDbType.NVarChar, 120).Value = $"%{filtro.Trim()}%";

                rd = command.ExecuteReader();

                while (rd.Read())
                {
                    lista.Add(Map(rd));
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible consultar los mantenimientos.", ex);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }

            return lista;
        }

        private static Mantenimientos Map(SqlDataReader rd) => new Mantenimientos
        {
            IdMantenimiento = rd.GetInt32(0),
            IdVehiculo = rd.GetInt32(1),
            Placa = rd.GetString(2),
            Fecha = rd.GetDateTime(3),
            Costo = rd.GetDecimal(4),
            Observaciones = rd.IsDBNull(5) ? string.Empty : rd.GetString(5),
            IdTipoMantenimiento = rd.GetInt32(6),
            NombreTipo = rd.GetString(7)
        };

        public int Insert(Mantenimientos paMantenimiento)
        {
            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"
                            INSERT INTO Mantenimientos (IdVehiculo, Fecha, Costo, Observaciones, IdTipoMantenimiento)
                            OUTPUT INSERTED.IdMantenimiento
                            VALUES (@IdVehiculo, @Fecha, @Costo, @Observaciones, @IdTipoMantenimiento);", Con);
                command.Parameters.Add("@IdVehiculo", SqlDbType.Int).Value = paMantenimiento.IdVehiculo;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = paMantenimiento.Fecha.Date;
                command.Parameters.Add("@Costo", SqlDbType.Decimal).Value = paMantenimiento.Costo;
                command.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 200).Value = (object?)paMantenimiento.Observaciones ?? DBNull.Value;
                command.Parameters.Add("@IdTipoMantenimiento", SqlDbType.Int).Value = paMantenimiento.IdTipoMantenimiento;

                var id = command.ExecuteScalar();
                return Convert.ToInt32(id);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible registrar el mantenimiento.", ex);
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }

        public bool Update(Mantenimientos paMantenimiento)
        {
            try
            {
                Con = OpenDb();

                command = new SqlCommand(@"UPDATE Mantenimientos
                        SET IdVehiculo = @IdVehiculo,
                            Fecha = @Fecha,
                            Costo = @Costo,
                            Observaciones = @Observaciones,
                            IdTipoMantenimiento = @IdTipoMantenimiento
                        WHERE IdMantenimiento = @Id;", Con);

                command.Parameters.Add("@IdVehiculo", SqlDbType.Int).Value = paMantenimiento.IdVehiculo;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = paMantenimiento.Fecha.Date;
                command.Parameters.Add("@Costo", SqlDbType.Decimal).Value = paMantenimiento.Costo;
                command.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 200).Value = (object?)paMantenimiento.Observaciones ?? DBNull.Value;
                command.Parameters.Add("@IdTipoMantenimiento", SqlDbType.Int).Value = paMantenimiento.IdTipoMantenimiento;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = paMantenimiento.IdMantenimiento;
                return command.ExecuteNonQuery() == 1;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible actualizar el mantenimiento.", ex);
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }

        public Mantenimientos? GetById(int idMantenimiento)
        {
            SqlDataReader rd = null;
            try
            {
                Con = OpenDb();

                command = new SqlCommand(@"
                            SELECT Mantenimientos.IdMantenimiento, Vehiculos.IdVehiculo, Vehiculos.Placa,
                                   Mantenimientos.Fecha, Mantenimientos.Costo, Mantenimientos.Observaciones,
                                   TiposMantenimiento.IdTipoMantenimiento, TiposMantenimiento.NombreTipo
                            FROM Mantenimientos
                            INNER JOIN Vehiculos ON Vehiculos.IdVehiculo = Mantenimientos.IdVehiculo
                            INNER JOIN TiposMantenimiento ON TiposMantenimiento.IdTipoMantenimiento = Mantenimientos.IdTipoMantenimiento
                            WHERE Mantenimientos.IdMantenimiento = @Id", Con);

                command.Parameters.Add("@Id", SqlDbType.Int).Value = idMantenimiento;
                rd = command.ExecuteReader(CommandBehavior.SingleRow);
                if (!rd.Read())
                    return null;

                return Map(rd);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible consultar el mantenimiento seleccionado.", ex);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }
        }
    }
}
