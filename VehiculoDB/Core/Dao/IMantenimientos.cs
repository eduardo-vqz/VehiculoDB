using VehiculoDB.Core.Clases;

namespace VehiculoDB.Core.Dao
{
    internal interface IMantenimientos
    {
        int Insert(Mantenimientos paMantenimiento);
        bool Update(Mantenimientos paMantenimiento);
        bool Delete(int idMantenimiento);
        Mantenimientos? GetById(int idMantenimiento);
        List<Mantenimientos> GetAll(string filtro = "");
    }
}
