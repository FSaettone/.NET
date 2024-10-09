using System;

namespace SGI.Aplicacion;

public interface IServicioAutorizacion
{
    public bool PoseeElPermiso(int IDUsuario, Permiso permiso);
}
