using System;

namespace SGI.Aplicacion;

public class UseCase_BajaCategoria  (IRepositorioProducto repoProducto, IRepositorioCategoria repoCategoria, IServicioAutorizacion servicioAutorizacion)
{

    private readonly CategoriaValidador _validador = new CategoriaValidador();
    public void Ejecutar(int ID)    
    {
        //Solo se puede dar de baja si no hay productos asociados
        servicioAutorizacion.tienePermiso(Permiso.CategoriaBaja);
        _validador.ValidarBaja(repoProducto.ObtenerTodos(), ID);
        repoCategoria.Baja(ID);
    }


}