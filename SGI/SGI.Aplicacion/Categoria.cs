using System;

namespace SGI.Aplicacion;

public class Categoria 
{
    public int ID { get; set; }
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaModificacion { get; set; }


    public Categoria()
    {
        FechaCreacion = DateTime.Now;
        FechaUltimaModificacion = DateTime.Now; 
    }

    public override string ToString()
    {
        return $"ID: {ID}, Nombre: {Nombre}, Descripcion {Descripcion}, Fecha de creacion: {FechaCreacion}, Fecha de ultima modificacion: {FechaUltimaModificacion}";
    }
}
