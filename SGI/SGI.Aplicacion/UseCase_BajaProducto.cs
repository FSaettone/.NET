using System;

namespace SGI.Aplicacion;

public class UseCase_BajaProducto (IRepositorioProducto repoProducto, IRepositorioTransaccion repoTransaccion, IServicioAutorizacion servicioAutorizacion)
{
    private readonly TransaccionValidador transaccionValidador=new TransaccionValidador();
    public void Ejecutar(int productoID)
    {
        //Debo eliminar todas las transacciones asociadas al producto
        servicioAutorizacion.tienePermiso(Permiso.ProductoBaja);
        transaccionValidador.ValidarBajaProducto(productoID,repoTransaccion);//aqui se valida la existencia de transacciones asociadas, y si las hay, se eliminan
        repoProducto.Baja(productoID);
        
    }

}
