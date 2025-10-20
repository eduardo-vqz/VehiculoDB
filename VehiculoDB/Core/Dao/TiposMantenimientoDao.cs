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
    internal class TiposMantenimientoDao : Cnn, ITiposMantenimiento
    {
        SqlConnection Con = null;
        SqlCommand command = null;
        public bool Delete(int idTiposMantenimiento)
        {
            throw new NotImplementedException();
        }

        public List<TiposMantenimiento> GetAll(string filtro = "")
        {
            var lista = new List<TiposMantenimiento>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                string sql = @"
                            SELECT IdTipoMantenimiento, NombreTipo
                            FROM TiposMantenimiento /**where**/
                            ORDER BY IdTipoMantenimiento DESC;";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql = sql.Replace("/**where**/", "WHERE NombreTipo LIKE @f ");
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
         private static TiposMantenimiento Map(SqlDataReader rd) => new TiposMantenimiento
         {
            IdTipoMantenimiento = rd.GetInt32(0),
            NombreTipo = rd.GetString(1),


          };

        public TiposMantenimiento GetById(int idTiposMantenimiento)
        {
            throw new NotImplementedException();
        }

        public int Insert(TiposMantenimiento paTiposMantenimiento)
        {
            throw new NotImplementedException();
        }

        public bool Update(TiposMantenimiento paTiposMantenimiento)
        {
            throw new NotImplementedException();
        }
    }
}
