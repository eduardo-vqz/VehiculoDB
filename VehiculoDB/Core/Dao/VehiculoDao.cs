using Microsoft.Data.SqlClient;
using System.Data;
using VehiculoDB.Core.Clases;
using VehiculoDB.Core.Lib;

namespace VehiculoDB.Core.Dao
{
    internal class VehiculoDao : Cnn, IVehiculo
    {
        SqlConnection Con = null;
        SqlCommand command = null;

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

        public bool Delete(int idVehiculo)
        {
            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"DELETE FROM Vehiculos WHERE IdVehiculo = @Id;", Con);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = idVehiculo;

                return command.ExecuteNonQuery() == 1;
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new ApplicationException("No se puede eliminar: el vehiculo esta asociado a uno o mas mantenimientos.", ex);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible eliminar el vehiculo seleccionado.", ex);
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }

        public List<Vehiculos> GetAll(string filtro = "")
        {
            var lista = new List<Vehiculos>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                string sql = @"
                            SELECT Vehiculos.IdVehiculo, Vehiculos.Placa, Vehiculos.Modelo, Vehiculos.Anio, Vehiculos.Color,
                                   Marcas.IdMarca, Marcas.NombreMarca,
                                   Propietarios.IdPropietario, Propietarios.DUI,
                                   TiposCarro.IdTipoCarro, TiposCarro.NombreTipo
                            FROM Vehiculos
                            INNER JOIN Marcas ON Vehiculos.IdMarca = Marcas.IdMarca
                            INNER JOIN Propietarios ON Vehiculos.IdPropietario = Propietarios.IdPropietario
                            INNER JOIN TiposCarro ON Vehiculos.IdTipoCarro = TiposCarro.IdTipoCarro
                            /**where**/
                            ORDER BY Vehiculos.IdVehiculo DESC;";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql = sql.Replace("/**where**/",
                        "WHERE Vehiculos.Placa LIKE @f OR Vehiculos.Modelo LIKE @f OR Marcas.NombreMarca LIKE @f OR Propietarios.DUI LIKE @f OR TiposCarro.NombreTipo LIKE @f");
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
                throw new ApplicationException("No fue posible consultar los vehiculos.", ex);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }

            return lista;
        }

        public Vehiculos? GetById(int idVehiculo)
        {
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"
                            SELECT Vehiculos.IdVehiculo, Vehiculos.Placa, Vehiculos.Modelo, Vehiculos.Anio, Vehiculos.Color,
                                   Marcas.IdMarca, Marcas.NombreMarca,
                                   Propietarios.IdPropietario, Propietarios.DUI,
                                   TiposCarro.IdTipoCarro, TiposCarro.NombreTipo
                            FROM Vehiculos
                            INNER JOIN Marcas ON Vehiculos.IdMarca = Marcas.IdMarca
                            INNER JOIN Propietarios ON Vehiculos.IdPropietario = Propietarios.IdPropietario
                            INNER JOIN TiposCarro ON Vehiculos.IdTipoCarro = TiposCarro.IdTipoCarro
                            WHERE Vehiculos.IdVehiculo = @Id;", Con);

                command.Parameters.Add("@Id", SqlDbType.Int).Value = idVehiculo;
                rd = command.ExecuteReader(CommandBehavior.SingleRow);

                if (!rd.Read())
                    return null;

                return Map(rd);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible consultar el vehiculo seleccionado.", ex);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }
        }

        public int Insert(Vehiculos paVehiculo)
        {
            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"
                            INSERT INTO Vehiculos (Placa, Modelo, Anio, Color, IdMarca, IdPropietario, IdTipoCarro)
                            OUTPUT INSERTED.IdVehiculo
                            VALUES (@Placa, @Modelo, @Anio, @Color, @IdMarca, @IdPropietario, @IdTipoCarro);", Con);

                command.Parameters.Add("@Placa", SqlDbType.VarChar, 15).Value = paVehiculo.Placa;
                command.Parameters.Add("@Modelo", SqlDbType.NVarChar, 100).Value = paVehiculo.Modelo;
                command.Parameters.Add("@Anio", SqlDbType.Int).Value = paVehiculo.Anio;
                command.Parameters.Add("@Color", SqlDbType.NVarChar, 50).Value = paVehiculo.Color;
                command.Parameters.Add("@IdMarca", SqlDbType.Int).Value = paVehiculo.IdMarca;
                command.Parameters.Add("@IdPropietario", SqlDbType.Int).Value = paVehiculo.IdPropietario;
                command.Parameters.Add("@IdTipoCarro", SqlDbType.Int).Value = paVehiculo.IdTipoCarro;

                var id = command.ExecuteScalar();
                return Convert.ToInt32(id);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new ApplicationException("La placa ya existe, verifica la informacion.", ex);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible registrar el vehiculo.", ex);
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }

        public bool Update(Vehiculos paVehiculo)
        {
            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"
                            UPDATE Vehiculos
                            SET Placa = @Placa,
                                Modelo = @Modelo,
                                Anio = @Anio,
                                Color = @Color,
                                IdMarca = @IdMarca,
                                IdPropietario = @IdPropietario,
                                IdTipoCarro = @IdTipoCarro
                            WHERE IdVehiculo = @Id;", Con);

                command.Parameters.Add("@Placa", SqlDbType.VarChar, 15).Value = paVehiculo.Placa;
                command.Parameters.Add("@Modelo", SqlDbType.NVarChar, 100).Value = paVehiculo.Modelo;
                command.Parameters.Add("@Anio", SqlDbType.Int).Value = paVehiculo.Anio;
                command.Parameters.Add("@Color", SqlDbType.NVarChar, 50).Value = paVehiculo.Color;
                command.Parameters.Add("@IdMarca", SqlDbType.Int).Value = paVehiculo.IdMarca;
                command.Parameters.Add("@IdPropietario", SqlDbType.Int).Value = paVehiculo.IdPropietario;
                command.Parameters.Add("@IdTipoCarro", SqlDbType.Int).Value = paVehiculo.IdTipoCarro;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = paVehiculo.IdVehiculo;

                return command.ExecuteNonQuery() == 1;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new ApplicationException("La placa ya existe, verifica la informacion.", ex);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("No fue posible actualizar el vehiculo.", ex);
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }
    }
}
