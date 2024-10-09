using System;

namespace SGI.Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException() {}

    public ValidacionException(string message) 
        : base(message) {}

    
}
