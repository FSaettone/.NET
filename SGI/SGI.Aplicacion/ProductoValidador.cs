using System;

namespace SGI.Aplicacion;

public class ProductoValidador 
{
    public void Validar(Producto producto)
    {
        if (producto.Nombre == null || producto.Nombre == "")
        {
            throw new ValidacionException("El nombre del producto no puede estar vacío");
        }

        if (producto.PrecioUnitario <= 0)
        {
            throw new ValidacionException("El precio del producto debe ser mayor a 0");
        }

        if (producto.StockDisponible < 0)
        {
            throw new ValidacionException("El stock del producto no puede ser negativo");
        }

        if(producto.CategoriaID==null)
        {
            throw new ValidacionException("La categoria del producto debe ser especificada");
        }
    }
}
