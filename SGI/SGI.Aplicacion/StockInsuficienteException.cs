using System;

namespace SGI.Aplicacion;

public class StockInsuficienteException : Exception
{
    public StockInsuficienteException(string message) : base(message)
    {}

}
