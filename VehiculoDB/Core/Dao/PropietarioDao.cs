using Microsoft.Data.SqlClient;
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
            throw new NotImplementedException();
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


        public Propietario GetById(int idPropietario)
        {
            throw new NotImplementedException();
        }

        public int Insert(Propietario paPropietario)
        {
            throw new NotImplementedException();
        }

        public bool Update(Propietario paPropietario)
        {
            throw new NotImplementedException();
        }
    }
}
