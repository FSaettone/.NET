using System;
using System.Diagnostics;
using SGI.Aplicacion;

namespace SGI.Repositorios;

public class RepositorioTransaccion (SGIContext context): IRepositorioTransaccion
{


    public void Alta(Transaccion transaccion)
    {
        context.Transacciones.Add(transaccion);
        context.SaveChanges();        
    }

    public void Baja(int ID)
    {
        var transaccion = context.Transacciones.Find(ID);
        if (transaccion != null)
        {
            context.Transacciones.Remove(transaccion);
            context.SaveChanges();
        }   
    }

    public Transaccion? ObtenerPorID(int ID)
    {
        return context.Transacciones.Find(ID);
    }

    public List<Transaccion> ObtenerTodos()
    {
        return context.Transacciones.ToList();
    }


    public void Modificar(Transaccion transaccion)
    {return;}
}
