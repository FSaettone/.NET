using System;

namespace SGI.Aplicacion;

public interface IRepositorioUsuario
{
    void Alta(Usuario usuario);
    void Baja(int ID);
    void Modificar(Usuario usuario);

    Usuario? ObtenerPorID(int ID);
    Usuario? ObtenerPorNombreyPass(string usuario, string password);
    List<Usuario> ObtenerTodos();
}
