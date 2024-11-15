using System;

namespace SGI.Aplicacion;

public class UseCase_BajaTransaccion (IRepositorioTransaccion repoTransaccion, IServicioAutorizacion servicioAutorizacion, IRepositorioProducto repoProducto)
{
    private readonly UseCase_ModificarProducto modificador= new UseCase_ModificarProducto(repoProducto, servicioAutorizacion);
    public void Ejecutar(int ID)
    {
        
        servicioAutorizacion.tienePermiso(Permiso.TransaccionBaja);
        var transaccion=repoTransaccion.ObtenerPorID(ID);
        if(transaccion!=null)
        {
            var producto=repoProducto.ObtenerPorID(transaccion.ProductoID);
            ActualizarStock(transaccion, producto);
            repoTransaccion.Baja(ID);
        }
        else 
        {
            throw new ValidacionException("No se encontro la transaccion con el ID: "+ID);
        }
    }


    private void ActualizarStock(Transaccion transaccion, Producto? producto)
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
        modificador.Ejecutar(producto);
    }
}
