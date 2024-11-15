using System;

namespace SGI.Repositorios;
using SGI.Aplicacion;
public class RepositorioCategoria (SGIContext context):  IRepositorioCategoria 
{ 
        

    public void Alta(Categoria categoria)
    {
        context.Categorias.Add(categoria);
        context.SaveChanges();
    }

    public void Baja(int ID)
    {
        var categoria = context.Categorias.Find(ID);
        if (categoria != null)
        {
            context.Categorias.Remove(categoria);
            context.SaveChanges();
        }
    }
    public void Modificar(Categoria categoria)
    {
        context.Categorias.Update(categoria);
        context.SaveChanges();
    }

    public Categoria? ObtenerPorID(int ID)
    {
        return context.Categorias.Find(ID);
    }

    public List<Categoria> ObtenerTodos()
    {
        return context.Categorias.ToList();
    }

}
