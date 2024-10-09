using System;

namespace SGI.Aplicacion;

public interface IRepositorio<Entidad>
{
    void Alta(Entidad entidad);
    void Baja(int ID);
    void Modificar(Entidad entidad);

    Entidad? ObtenerPorID(int ID); //si no encuentra la entidad, devuelve null
    List<Entidad> ObtenerTodos();
}
