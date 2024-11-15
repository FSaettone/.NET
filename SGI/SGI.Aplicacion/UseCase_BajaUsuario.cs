using System;

namespace SGI.Aplicacion;

public class UseCase_BajaUsuario(IRepositorioUsuario repo, IServicioAutorizacion servicioAutorizacion)
{
    private readonly UsuarioValidador _validador= new UsuarioValidador();
    public void Ejecutar(int ID) 
    {
            servicioAutorizacion.tienePermiso(Permiso.UsuarioBaja);
            _validador.ValidarBaja(ID,repo);  
            repo.Baja(ID);
   }
}
