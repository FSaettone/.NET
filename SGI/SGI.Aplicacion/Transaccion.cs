using System;

namespace SGI.Aplicacion;

public class Transaccion : Entidad
{
public int ProductoID { get; set; }
public int Cantidad { get; set; }
public Tipo Tipo { get; set; }


public Transaccion()
{
    FechaCreacion = DateTime.Now;
}

    public override string ToString()
    {
        return $"ID: {ID}, ProductoID: {ProductoID}, Cantidad: {Cantidad}, Tipo: {Tipo}, Fecha de transaccion: {FechaCreacion}";
    }

}
