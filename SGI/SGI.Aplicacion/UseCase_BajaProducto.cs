using System;

namespace SGI.Aplicacion;

public class UseCase_BajaProducto (IRepositorio<Producto> repoProducto, IRepositorio<Transaccion> repoTransaccion, IServicioAutorizacion servicioAutorizacion)
{
    private readonly TransaccionValidador transaccionValidador=new TransaccionValidador();
    public void Ejecutar(int productoID, int idUsuario)
    {
        //Debo eliminar todas las transacciones asociadas al producto
        try
        {
            servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ProductoBaja);
            transaccionValidador.ValidarBajaProducto(productoID,repoTransaccion);//aqui se valida la existencia de transacciones asociadas, y si las hay, se eliminan
            repoProducto.Baja(productoID);
        }
        catch (ValidacionException ex)
        {
            Console.WriteLine("Error de Validacion: "+ex.Message);
        }
        catch (PermisosException ex)
        {
            Console.WriteLine("Error de Permisos: "+ex.Message);
        }
    }

}
