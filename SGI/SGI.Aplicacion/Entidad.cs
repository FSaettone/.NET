using System;

namespace SGI.Aplicacion;

public abstract class Entidad
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaModificacion { get; set; }


    
}
