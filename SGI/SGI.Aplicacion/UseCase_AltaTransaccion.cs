using System;

namespace SGI.Aplicacion;

public class UseCase_AltaTransaccion (IRepositorioTransaccion repo, IServicioAutorizacion servicioAutorizacion, IRepositorioProducto repoProducto) 
{
    private readonly TransaccionValidador _validador = new TransaccionValidador();
    private readonly UseCase_ModificarProducto modificador= new UseCase_ModificarProducto(repoProducto, servicioAutorizacion);
    public void Ejecutar(Transaccion transaccion)
    {
        
        Producto? producto = repoProducto.ObtenerPorID(transaccion.ProductoID);
        servicioAutorizacion.tienePermiso(Permiso.TransaccionAlta);
        _validador.ValidarAlta(transaccion,producto); 
        ActualizarStock(transaccion,producto);//tira exception por alguna razon
        repo.Alta(transaccion);
        Console.WriteLine($"La transaccion de {transaccion.Tipo} ID: {transaccion.ID} ha sido dada de alta con exito");
            
    }

    private void ActualizarStock(Transaccion transaccion, Producto? prod)
    {
        if (prod==null)
        {
            throw new ValidacionException("El producto solicitado no se encuentra en el sistema");
        }

        if (transaccion.Tipo== Tipo.Salida)
        {
            if(prod.StockDisponible<transaccion.Cantidad)
            {
                throw new StockInsuficienteException($"No hay suficiente stock, {prod.StockDisponible} unidades disponibles, {transaccion.Cantidad} unidades solicitadas");
            }
            prod.StockDisponible-=transaccion.Cantidad;
            //Console.WriteLine($"Stock del producto ID: {prod.ID} actualizado a {prod.StockDisponible}");    
        }

        if (transaccion.Tipo== Tipo.Entrada)
        {
            prod.StockDisponible+=transaccion.Cantidad;
            //Console.WriteLine($"Stock del producto ID: {prod.ID} actualizado a {prod.StockDisponible}");
         
        }
        modificador.Ejecutar(prod); 
    }

}
