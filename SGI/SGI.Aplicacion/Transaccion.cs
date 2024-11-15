using System;

namespace SGI.Aplicacion;

public class Transaccion 
{
    public int ID { get; set; }
    public int ProductoID { get; set; }
    public int? Cantidad { get; set; }  //lo hice nullable ya que se inicializaba en 0 y me complicaba los cuadros para completar
    public Tipo? Tipo { get; set; }
    public DateTime FechaTransaccion { get; set; }

public Transaccion()
{
    FechaTransaccion = DateTime.Now;
}

    public override string ToString()
    {
        return $"ID: {ID}, ProductoID: {ProductoID}, Cantidad: {Cantidad}, Tipo: {Tipo}, Fecha de transaccion: {FechaTransaccion}";
    }

}
