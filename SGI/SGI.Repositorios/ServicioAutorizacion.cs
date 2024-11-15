using System;

namespace SGI.Repositorios;
using SGI.Aplicacion;
public class ServicioSesion : IServicioAutorizacion
{
    private Usuario? _currentUser; 

    public void IniciarSesion(Usuario usuario)
    {
        _currentUser = usuario;
    }

    public void CerrarSesion()
    {
        _currentUser = null;
    }

    public Usuario? ObtenerUsuarioActual()
    {
        return _currentUser;
    }

    public bool EstaLogueado()
    {
        return _currentUser != null;
    }


    public bool tienePermiso(Permiso permiso)
    {
        return _currentUser?.Permisos.Contains(permiso) ?? false;
    }
}
