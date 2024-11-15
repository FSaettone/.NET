using System;

namespace SGI.Aplicacion;

public interface IRepositorioProducto
{
    void Alta(Producto producto);
    void Baja(int ID);
    void Modificar(Producto producto);

    Producto? ObtenerPorID(int ID);
    List<Producto> ObtenerTodos();
}
