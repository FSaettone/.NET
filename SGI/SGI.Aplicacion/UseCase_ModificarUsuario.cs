using System;

namespace SGI.Aplicacion;

public class UseCase_ModificarUsuario (IRepositorioUsuario repoUsuario)
{
    public void Ejecutar(Usuario usuario)
    {
        repoUsuario.Modificar(usuario);
    }
}
