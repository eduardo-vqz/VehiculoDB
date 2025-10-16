using Microsoft.Data.SqlClient;
using System.Data;
using VehiculoDB.Core.Clases;
using VehiculoDB.Core.Lib;

namespace VehiculoDB.Core.Dao
{
    internal class PropietarioDao : Cnn, IPropietarioDao
    {
        SqlConnection Con = null;
        SqlCommand command = null;

        public bool Delete(int idPropietario)
        {
            try 
            {
                Con = OpenDb();
                command = new SqlCommand(@"DELETE FROM Propietarios WHERE IdPropietario = @Id;", Con);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = idPropietario;

                return command.ExecuteNonQuery() == 1;
            }
            catch (SqlException ex) when (ex.Number == 547)
            { 
                throw new ApplicationException("No se puede eliminar: " +
                    "El propietario esta asociado a un vehículo." + ex);
            }
            finally { 
            command?.Dispose();
                CloseDb();
            }
        }

        public List<Propietario> GetAll(string filtro = "")
        {
            var lista = new List<Propietario>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                string sql = @"
                            SELECT IdPropietario, Nombre, Apellido, DUI, Telefono, Direccion
                            FROM Propietarios /**where**/
                            ORDER BY IdPropietario DESC;";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql = sql.Replace("/**where**/", "WHERE Nombre LIKE @f OR Apellido LIKE @f OR DUI @f");
                }
                else
                {
                    sql = sql.Replace("/**where**/", string.Empty);
                }

                command = new SqlCommand(sql, Con);
                if (!string.IsNullOrWhiteSpace(filtro))
                    command.Parameters.Add("@f", System.Data.SqlDbType.NVarChar, 120).Value = $"%{filtro}%";

                rd = command.ExecuteReader();

                while (rd.Read())
                {
                    lista.Add(Map(rd));
                }

            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }

            return lista;
        }

        private static Propietario Map(SqlDataReader rd) => new Propietario
        {
            IdPropietario = rd.GetInt32(0),
            Nombre = rd.GetString(1),
            Apellido = rd.GetString(2),
            DUI = rd.GetString(3),
            Telefono = rd.IsDBNull(4) ? null : rd.GetString(4),
            Direccion = rd.IsDBNull(5) ? null : rd.GetString(5)

        };


        public Propietario? GetById(int idPropietario)
        {
            SqlDataReader rd = null;
            try
            {
                Con = OpenDb();

                command = new SqlCommand(@"SELECT IdPropietario, Nombre, Apellido, DUI,
                                         Telefono, Direccion
                                         FROM Propietarios
                                         WHERE IdPropietario = @Id", Con);


                command.Parameters.Add("@Id", SqlDbType.Int).Value = idPropietario;
                rd = command.ExecuteReader(CommandBehavior.SingleRow);
                if (!rd.Read())
                    return null;

                return Map(rd);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb() ;
            }
        }

        public int Insert(Propietario paPropietario)
        {
            try
            {
                Con = OpenDb();

                command = new SqlCommand(@"INSERT INTO Propietarios (Nombre, Apellido, DUI, Telefono, Direccion)
                            OUTPUT INSERTED.IdPropietario 
                            VALUES (@Nombre, @Apellido, @DUI, @Telefono, @Direccion);", Con);
                command.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = paPropietario.Nombre;
                command.Parameters.Add("@Apellido", SqlDbType.NVarChar, 100).Value = paPropietario.Apellido;
                command.Parameters.Add("@DUI", SqlDbType.VarChar, 10).Value = paPropietario.DUI;
                command.Parameters.Add("@Telefono", SqlDbType.VarChar, 15).Value = (object?)paPropietario.Telefono ?? DBNull.Value;
                command.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = (object?)paPropietario.Direccion ?? DBNull.Value;

                var id = command.ExecuteScalar();
                return Convert.ToInt32(id);
            }
            catch (SqlException ex) when ( ex.Number == 2627 || ex.Number == 2601 )
            {
                throw new ApplicationException("El DUI ya existe, verifica la información. " + ex);
            }
            finally {
                command?.Dispose();
                CloseDb();
            }
        }

        public bool Update(Propietario paPropietario)
        {
            try
            {
                Con = OpenDb();

                command = new SqlCommand(@"UPDATE Propietarios
                        SET Nombre = @Nombre,
                            Apellido = @Apellido,
                            DUI = @DUI,
                            Telefono = @Telefono,
                            Direccion = @Direccion
                        WHERE IdPropietario = @id;", Con);

                command.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = paPropietario.Nombre;
                command.Parameters.Add("@Apellido", SqlDbType.NVarChar, 100).Value = paPropietario.Apellido;
                command.Parameters.Add("@DUI", SqlDbType.VarChar, 10).Value = paPropietario.DUI;
                command.Parameters.Add("@Telefono", SqlDbType.VarChar, 15).Value = (object?)paPropietario.Telefono ?? DBNull.Value;
                command.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = (object?)paPropietario.Direccion ?? DBNull.Value;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = paPropietario.IdPropietario;
                return command.ExecuteNonQuery() == 1;

            }

            catch (SqlException ex)
            {
                throw new ApplicationException("Error inesperado: " + ex);
                
            }
            finally
            {
                command?.Dispose();
                CloseDb();  
            }
        
        }
    }
}
