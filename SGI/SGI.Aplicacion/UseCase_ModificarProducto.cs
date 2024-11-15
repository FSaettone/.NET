using System;

namespace SGI.Aplicacion;

public class UseCase_ModificarProducto (IRepositorioProducto repo,IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Producto producto)
    {   
        servicioAutorizacion.tienePermiso(Permiso.ProductoModificacion);
        repo.Modificar(producto);     
    }
}
