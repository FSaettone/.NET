using System;

namespace SGI.Aplicacion;

public class UseCase_AltaPermiso (IRepositorioUsuario repoUsuario,IServicioAutorizacion servicioAutorizacion) 
{
    private readonly UsuarioValidador _validador = new UsuarioValidador();
    public void Ejecutar(List<Permiso> permisos,Usuario usuario)
    {
        servicioAutorizacion.tienePermiso(Permiso.PermisoModificar);
        _validador.Validar(usuario);
        usuario.Permisos.Clear(); //limpio los permisos que puedan existir previamente
        foreach(var permiso in permisos)
        {
            usuario.Permisos.Add(permiso);
        }
        repoUsuario.Modificar(usuario);
    }
}
