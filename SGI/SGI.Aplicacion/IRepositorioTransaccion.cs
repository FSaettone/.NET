using System;

namespace SGI.Aplicacion;

public interface IRepositorioTransaccion
{
    void Alta(Transaccion transaccion);
    void Baja(int ID);

    Transaccion? ObtenerPorID(int ID);
    List<Transaccion> ObtenerTodos();

}
