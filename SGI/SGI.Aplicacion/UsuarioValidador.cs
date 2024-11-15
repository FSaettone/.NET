using System;

namespace SGI.Aplicacion;

public class UsuarioValidador
{
    public void Validar(Usuario usuario)
    {
        if (usuario.Nombre == null || usuario.Nombre == "")
        {
            throw new ValidacionException("El nombre del usuario no puede estar vacío");
        }
    }

    public void ValidarBaja(int ID, IRepositorioUsuario repo) 
    {
        var usuario = repo.ObtenerPorID(ID);
        if (usuario == null)
        {
            throw new ValidacionException("El usuario no existe");
        }
    }    

    public Usuario ValidarInicioSesion(string usuario, string password, IRepositorioUsuario repo)
    {
        var us = repo.ObtenerPorNombreyPass(usuario, password);
        if (us == null)
        {
            throw new ValidacionException( "El usuario o la contraseña son incorrectos");
        }
        return us;
    }
}
