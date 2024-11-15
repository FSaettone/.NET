using System;

namespace SGI.Aplicacion;

public class UseCase_ModificarCategoria (IRepositorioCategoria repo,IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Categoria categoria)
    {
        servicioAutorizacion.tienePermiso(Permiso.CategoriaModificacion);
        repo.Modificar(categoria);
    }
}
