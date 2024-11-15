using System;

namespace SGI.Repositorios;

using System.Collections.Generic;
using SGI.Aplicacion;
public class RepositorioUsuario (SGIContext context): IRepositorioUsuario
{
    public void Alta(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        context.SaveChanges();
    }

    public void Baja(int ID)
    {
        var usuario = context.Usuarios.Find(ID);
        if (usuario != null)
        {
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
        }
    }

    public void Modificar(Usuario usuario)
    {
        context.Usuarios.Update(usuario);
        context.SaveChanges();
    }


    public Usuario? ObtenerPorID(int ID)
    {
        return context.Usuarios.Find(ID);
    }

    public Usuario? ObtenerPorNombreyPass(string usuario, string password)
    {
        return context.Usuarios.FirstOrDefault(u => u.Nombre == usuario && u.Password == password); 
    }

    public List<Usuario> ObtenerTodos()
    {
        return context.Usuarios.ToList();
    }



}
