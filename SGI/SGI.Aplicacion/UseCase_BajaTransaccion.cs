using System;

namespace SGI.Aplicacion;

public class UseCase_BajaTransaccion (IRepositorio<Transaccion> repoTransaccion, IServicioAutorizacion servicioAutorizacion, IRepositorio<Producto> repoProducto)
{
    private readonly UseCase_ModificarProducto modificador= new UseCase_ModificarProducto(repoProducto, servicioAutorizacion);
    public void Ejecutar(int ID, int idUsuario)
    {
        try
        {
        servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TransaccionBaja);
        var transaccion=repoTransaccion.ObtenerPorID(ID);
        if(transaccion!=null)
        {
            var producto=repoProducto.ObtenerPorID(transaccion.ProductoID);
            ActualizarStock(transaccion, producto, idUsuario);
            repoTransaccion.Baja(ID);
            Console.WriteLine($"La transaccion con ID: {transaccion.ID} ha sido dada de baja con exito");
        }
        else 
        {
            throw new ValidacionException("No se encontro la transaccion con el ID: "+ID);
        }
        }
        catch (PermisosException ex)
        {
            Console.WriteLine("Error de Permisos: "+ex.Message);
        }
        catch (ValidacionException ex)
        {
            Console.WriteLine("Error de Validacion: "+ex.Message);
        }
    }


    private void ActualizarStock(Transaccion transaccion, Producto? producto, int idUsuario)
    {
        if(producto!=null)
        {
            if(transaccion.Tipo==Tipo.Entrada)
            {
                producto.StockDisponible-=transaccion.Cantidad;
            }
            else //si es de tipo Salida
            {
               producto.StockDisponible+=transaccion.Cantidad;
            }
        }
        else 
        {
            throw new ValidacionException("Producto Invalido");
        }
        modificador.Ejecutar(producto,idUsuario);
    }
}
