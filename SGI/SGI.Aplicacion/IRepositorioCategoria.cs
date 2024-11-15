using System;

namespace SGI.Aplicacion;

public interface IRepositorioCategoria
{
    void Alta(Categoria categoria);
    void Baja(int ID);
    void Modificar(Categoria categoria);

    Categoria? ObtenerPorID(int ID);
    List<Categoria> ObtenerTodos();
}
