using System;

namespace SGI.Aplicacion;

public class UseCase_AltaCategoria (IRepositorio<Categoria> repo, IServicioAutorizacion servicioAutorizacion)
{
    private readonly CategoriaValidador _validador= new CategoriaValidador();


    public void Ejecutar(Categoria categoria, int idUsuario)
    {
        try 
        {
            servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.CategoriaAlta);
            _validador.Validar(categoria);
            repo.Alta(categoria);
            Console.WriteLine($"La categoria {categoria.Nombre} ha sido dada de alta con exito");
        }
        catch (ValidacionException ex)
        {
            System.Console.WriteLine("Error de Validacion: "+ex.Message);
        }
        catch (PermisosException ex)
        {
            System.Console.WriteLine("Error de Permisios: "+ex.Message);
        }
        
    }
}
