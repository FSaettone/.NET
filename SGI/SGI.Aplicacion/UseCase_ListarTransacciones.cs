using System;

namespace SGI.Aplicacion;

public class UseCase_ListarTransacciones (IRepositorio<Transaccion> repoTransaccion)
{

    public void ListarTransacciones()
    {
        var transacciones=repoTransaccion.ObtenerTodos();
        Console.WriteLine("Listado de todas las transacciones");
        foreach(var transaccion in transacciones)
        {
            Console.WriteLine(transaccion);
        }
    }


    public void ListarTransacciones(DateTime fechaInicio, DateTime fechaFin)
    {
        var transacciones=repoTransaccion.ObtenerTodos();
        Console.WriteLine($"Listado de todas las transacciones entre {fechaInicio} y {fechaFin}");
        foreach(var transaccion in transacciones)
        {
            if(transaccion.FechaCreacion>=fechaInicio && transaccion.FechaCreacion<=fechaFin)
            {
                Console.WriteLine(transaccion);
            }
        }
    }
}
