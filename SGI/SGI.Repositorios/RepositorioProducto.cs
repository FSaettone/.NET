using System;

namespace SGI.Repositorios;

using System.Collections.Generic;
using SGI.Aplicacion;

public class RepositorioProducto (SGIContext context) : IRepositorioProducto 
{


    public void Alta(Producto producto)
    {   
        context.Productos.Add(producto);
        context.SaveChanges();       
    }

    public void Baja(int ID)
    {
        var producto = context.Productos.Find(ID);
        if (producto != null)
        {
            context.Productos.Remove(producto);
            context.SaveChanges();
        }
    }	
    
    public void Modificar(Producto producto)
    {
        context.Productos.Update(producto);
        context.SaveChanges();
    }

        public Producto? ObtenerPorID(int id)
        {
            return context.Productos.Find(id);
        }

        public List<Producto> ObtenerTodos()
        {
            return context.Productos.ToList();
        }
}


