using System;

namespace SGI.Aplicacion;

public class UseCase_ModificarProducto (IRepositorio<Producto> repo,IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Producto producto, int idUsuario)
    {
        try
        {
            servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ProductoModificacion);
            repo.Modificar(producto);
            //Console.WriteLine($"El producto {producto.Nombre} ha sido modificado con exito");
        }
        catch(PermisosException ex)
        {
            Console.WriteLine("Error de Permisos: "+ex.Message);
        }
    }
}
