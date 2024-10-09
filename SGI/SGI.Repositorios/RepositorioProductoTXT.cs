using System;

namespace SGI.Repositorios;

using System.Collections.Generic;
using SGI.Aplicacion;

public class RepositorioProductoTXT : RepositorioTXT,IRepositorio<Producto>
{

    public RepositorioProductoTXT() : base("Productos.txt",0)
    {
    }

    public void Alta(Producto producto)
    {   
        var ultId= ObtenerUltimoID("Productos.txt") + 1;
        producto.ID = ultId;
        using var sw = new StreamWriter(_nombreArch, true);
        string line= string.Join(";",producto.ID,producto.Nombre,producto.CategoriaID,producto.Descripcion,producto.PrecioUnitario,producto.StockDisponible,producto.FechaCreacion,producto.FechaUltimaModificacion);
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
            var line= sr.ReadLine(); //leo una linea del archivo original
            var fields = line?.Split(';'); //separo los campos de la linea leida
            if(fields != null && int.Parse(fields[0]) != ID) //si el ID del producto es distinto al ID del producto que quiero eliminar
            {
                sw.WriteLine(line);   //escribo la linea en el archivo temporal
            }
        }
        sr.Close(); sw.Close(); //cierro los archivos
        File.Delete(_nombreArch); //borro el archivo original
        File.Move(tempFile, _nombreArch); //renombro el archivo temporal
    }	
    
    public void Modificar(Producto producto)
    {
        var tempFile = Path.GetTempFileName();
        var sr = new StreamReader(_nombreArch);
        var sw = new StreamWriter(tempFile);
        while(!sr.EndOfStream)
        {
           var line = sr.ReadLine();
           var fields = line?.Split(';');

            if(fields!= null && int.Parse(fields[0]) == producto.ID)  //si el ID del producto es igual al ID del producto que quiero modificar
            {
                string newLine= string.Join(";",producto.ID,producto.Nombre,producto.CategoriaID,producto.Descripcion,producto.PrecioUnitario,producto.StockDisponible,producto.FechaCreacion,producto.FechaUltimaModificacion);
                sw.WriteLine(newLine);
            }
            else //si el ID del producto es distinto al ID del producto que quiero modificar 
            {
                sw.WriteLine(line);
            }
        }
        sr.Close(); sw.Close(); //cierro los archivos
        File.Delete(_nombreArch); //borro el archivo original
        File.Move(tempFile, _nombreArch); //renombro el archivo temporal
    }

        public Producto? ObtenerPorID(int id)
        {
            using var sr = new StreamReader(_nombreArch);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var fields = line?.Split(';');
                if (fields != null && int.Parse(fields[0]) == id)
                {
                    return new Producto
                    {
                        ID = int.Parse(fields[0]),
                        Nombre = fields[1],
                        CategoriaID = int.Parse(fields[2]),
                        Descripcion = fields[3],
                        PrecioUnitario = double.Parse(fields[4]),
                        StockDisponible = int.Parse(fields[5]),
                        FechaCreacion = DateTime.Parse(fields[6]),
                        FechaUltimaModificacion = DateTime.Parse(fields[7])
                    };
                }
            }
            sr.Close();
            return null;
        }

        public List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();
            using var sr = new StreamReader(_nombreArch);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var fields = line?.Split(';');
                if (fields != null)
                {
                    lista.Add(new Producto
                    {
                        ID = int.Parse(fields[0]),
                        Nombre = fields[1],
                        CategoriaID = int.Parse(fields[2]),
                        Descripcion = fields[3],
                        PrecioUnitario = double.Parse(fields[4]),
                        StockDisponible = int.Parse(fields[5]),
                        FechaCreacion = DateTime.Parse(fields[6]),
                        FechaUltimaModificacion = DateTime.Parse(fields[7])
                    });
                }
            }
            sr.Close();
            return lista;
        }
}


