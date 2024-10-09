using System;

namespace SGI.Aplicacion;

public class UseCase_ModificarCategoria (IRepositorio<Categoria> repo,IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Categoria categoria, int idUsuario)
    {
        try
        {
            servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.CategoriaModificacion);
            repo.Modificar(categoria);
            Console.WriteLine($"La categoria {categoria.Nombre} ha sido modificada con exito");
        }
        catch(PermisosException ex)
        {
            Console.WriteLine("Error de Permisos: "+ex.Message);
        }   
    }
}
