using System;

namespace SGI.Aplicacion;

public class Producto : Entidad
{
    public double PrecioUnitario { get; set; }
    public int StockDisponible { get; set; }
    public int? CategoriaID { get; set; }



    public Producto()
    {
        FechaCreacion = DateTime.Now;
        FechaUltimaModificacion = DateTime.Now; 
    }


    public override string ToString()
    {
        return $"ID: {ID}, Nombre de producto: {Nombre}, Descripcion: {Descripcion} Precio unitario: {PrecioUnitario}, Stock disponible: {StockDisponible}";
    }
}
