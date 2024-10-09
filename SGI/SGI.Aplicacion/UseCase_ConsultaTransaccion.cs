using System;

namespace SGI.Aplicacion;

public class UseCase_ConsultaTransaccion (IRepositorio<Transaccion> repoTransaccion, IRepositorio<Producto> repoProducto)
{
    public void ConsultarTransaccion(int ID)
    {
        try
        {
        var transaccion=repoTransaccion.ObtenerPorID(ID);
        if(transaccion!=null)
        {
            var producto=repoProducto.ObtenerPorID(transaccion.ProductoID);
            if (producto!=null)
            {
                Console.WriteLine("Consulta: "+producto);
            }
            else
            {
                throw new Exception("No se encontro el producto con el ID: "+transaccion.ProductoID);
            }
        }
        else 
        {
            throw new Exception("No se encontro la transaccion con el ID: "+ID);
        }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
        }
    }

}
