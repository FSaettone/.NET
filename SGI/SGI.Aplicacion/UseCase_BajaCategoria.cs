using System;

namespace SGI.Aplicacion;

public class UseCase_BajaCategoria  (IRepositorio<Producto> repoProducto, IRepositorio<Categoria> repoCategoria, IServicioAutorizacion servicioAutorizacion)
{

    private readonly CategoriaValidador _validador = new CategoriaValidador();
    public void Ejecutar(int ID, int idUsuario)    
    {
        //Solo se puede dar de baja si no hay productos asociados
        try
        {
            servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.CategoriaBaja);
            _validador.ValidarBaja(repoProducto.ObtenerTodos(), ID);
            repoCategoria.Baja(ID);
            Console.WriteLine($"La categoria con ID: {ID} ha sido dada de baja con exito");
        }
        catch (ValidacionException ex)
        {
            Console.WriteLine("Error de Validacion: "+ex.Message);
        }
        catch (PermisosException ex)
        {
            Console.WriteLine("Error de Permisios: "+ex.Message);
        }
    }


}