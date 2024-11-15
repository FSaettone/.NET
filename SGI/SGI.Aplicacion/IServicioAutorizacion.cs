using System;

namespace SGI.Aplicacion;

public interface IServicioAutorizacion
{
    public bool tienePermiso(Permiso permiso);

    void IniciarSesion(Usuario usuario);
    void CerrarSesion();
    Usuario? ObtenerUsuarioActual();
    bool EstaLogueado();

}
