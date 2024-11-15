using System;

namespace SGI.Aplicacion;

public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public double? PrecioUnitario { get; set; }
    public int? StockDisponible { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaModificacion { get; set; }
    public int? CategoriaID { get; set; }
    public int ProductoID { get; internal set; }

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
