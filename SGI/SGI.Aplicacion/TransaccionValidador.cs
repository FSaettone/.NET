using System;

namespace SGI.Aplicacion;

public class TransaccionValidador 
{
    public void ValidarAlta(Transaccion transaccion, Producto? prod)
    {
        if (transaccion.Cantidad <=0)
        {
            throw new ValidacionException("La cantidad debe ser mayor a 0");
        }
    }
    
    public void ValidarBajaProducto(int ID, IRepositorio<Transaccion> repo)
    {
        var transacciones = repo.ObtenerTodos();
        foreach (var transaccion in transacciones)
        {
            if (transaccion.ProductoID == ID)
            {
                repo.Baja(transaccion.ID);//Elimino la transaccion directamente sin incrementar o decrementar el stock del producto, ya que dicho producto esta siendo eliminado.                
            }
        }
    }
}
