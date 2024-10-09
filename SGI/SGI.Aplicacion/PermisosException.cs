using System;

namespace SGI.Aplicacion;

public class PermisosException : Exception
{
    public PermisosException() {}

    public PermisosException(string message) 
        : base(message) {} 
}
