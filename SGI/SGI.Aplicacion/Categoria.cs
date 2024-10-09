using System;

namespace SGI.Aplicacion;

public class Categoria : Entidad
{
    public Categoria()
    {
        FechaCreacion = DateTime.Now;
        FechaUltimaModificacion = DateTime.Now;
    }
}
