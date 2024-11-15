using System;

namespace SGI.Aplicacion;

public class UseCase_AltaCategoria (IRepositorioCategoria repo, IServicioAutorizacion servicioAutorizacion)
{
    private readonly CategoriaValidador _validador= new CategoriaValidador();


    public void Ejecutar(Categoria categoria)
    {
    
        servicioAutorizacion.tienePermiso(Permiso.CategoriaAlta);
        _validador.Validar(categoria);
        repo.Alta(categoria);

        
    }
}
