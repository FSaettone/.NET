using System;

namespace SGI.Aplicacion;

public class UseCase_ListarTransacciones (IRepositorioTransaccion repoTransaccion)
{

    public List<Transaccion> Ejecutar()
    {
        return repoTransaccion.ObtenerTodos();
    }


    public List<Transaccion> ListarTransacciones(DateTime fechaInicio, DateTime fechaFin)
    {
        var transacciones=repoTransaccion.ObtenerTodos();
        return transacciones.FindAll(t => t.FechaTransaccion >= fechaInicio && t.FechaTransaccion <= fechaFin);
    }
}
