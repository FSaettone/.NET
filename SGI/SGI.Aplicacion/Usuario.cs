using System;

namespace SGI.Aplicacion;

public class Usuario : Entidad
{
    public List<Permiso> Permisos { get; set; }= new List<Permiso>();


}
