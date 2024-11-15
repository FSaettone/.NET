using System;

namespace SGI.Aplicacion;

public class UseCase_AltaProducto (IRepositorioProducto repo, IServicioAutorizacion servicioAutorizacion)
{
    private readonly ProductoValidador _validador= new ProductoValidador();

    public void Ejecutar(Producto producto)
    {
        servicioAutorizacion.tienePermiso(Permiso.CategoriaAlta);
        _validador.Validar(producto);
        repo.Alta(producto);   
    }
}
