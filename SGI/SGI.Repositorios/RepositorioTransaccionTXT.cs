using System;
using System.Diagnostics;
using SGI.Aplicacion;

namespace SGI.Repositorios;

public class RepositorioTransaccionTXT : RepositorioTXT,IRepositorio<Transaccion>
{

    
    public RepositorioTransaccionTXT() : base("Transacciones.txt",0)
    { }


    public void Alta(Transaccion transaccion)
    {
        var ultId = ObtenerUltimoID("Transacciones.txt") + 1; 
        transaccion.ID = ultId;
        using var sw = new StreamWriter(_nombreArch, true);
        string line= string.Join(";",transaccion.ID,transaccion.ProductoID,transaccion.Cantidad,transaccion.FechaCreacion,transaccion.Tipo);
        sw.WriteLine(line);
        sw.Close();
    }

    public void Baja(int ID)
    {
        var tempFile = Path.GetTempFileName();
        using var sr = new StreamReader(_nombreArch); //variable sr para leer el archivo original
        using var sw = new StreamWriter(tempFile); //variable sw para escribir en un archivo temporal que luego reemplazara al original
        while(!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var fields = line?.Split(';');
            if(fields != null && int.Parse(fields[0]) != ID) //si el ID del producto es distinto al ID del producto que quiero eliminar
            {
                sw.WriteLine(line);   //escribo la linea en el archivo temporal
            }                                                                            
        }
        sr.Close(); sw.Close(); //cierro los archivos
        File.Delete(_nombreArch); //borro el archivo original
        File.Move(tempFile, _nombreArch); //renombro el archivo temporal
    }

    public Transaccion? ObtenerPorID(int ID)
    {
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var fields = line?.Split(';');
            if(fields != null && int.Parse(fields[0]) == ID)
            {
                return new Transaccion{
                        ID = int.Parse(fields[0]),
                        ProductoID = int.Parse(fields[1]),
                        Cantidad = int.Parse(fields[2]),
                        FechaCreacion = DateTime.Parse(fields[3]),
                        Tipo = (Tipo)Enum.Parse(typeof(Tipo), fields[4])
                };
            }
        }
        sr.Close();
        return null;
    }

    public List<Transaccion> ObtenerTodos()
    {
        var lista = new List<Transaccion>();
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var fields = line?.Split(';');
            if(fields != null)
            {
                lista.Add(new Transaccion{
                    ID = int.Parse(fields[0]),
                    ProductoID = int.Parse(fields[1]),
                    Cantidad = int.Parse(fields[2]),
                    FechaCreacion = DateTime.Parse(fields[3]),
                    Tipo = (Tipo)Enum.Parse(typeof(Tipo), fields[4])
                });
            }
        }
        sr.Close();
        return lista;
    }


    public void Modificar(Transaccion transaccion)
    {return;}
}
