using System;

namespace SGI.Aplicacion;

public class UseCase_AltaUsuario(IRepositorioUsuario repo, IServicioAutorizacion servicioAutorizacion)
{
    private readonly UsuarioValidador _validador= new UsuarioValidador();
    public void Ejecutar(Usuario usuario)
    {
        servicioAutorizacion.tienePermiso(Permiso.UsuarioAlta);
        _validador.Validar(usuario);
        repo.Alta(usuario);
    }
}
