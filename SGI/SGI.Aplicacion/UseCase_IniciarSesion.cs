using System;

namespace SGI.Aplicacion;

public class UseCase_IniciarSesion (IRepositorioUsuario repoUsuario)
{
    private readonly UsuarioValidador _validador= new UsuarioValidador();
     public Usuario? Ejecutar(String usuario, String password)
    {
        var us = _validador.ValidarInicioSesion(usuario, password, repoUsuario);
        return us;       
    }
}
