using System;

namespace SGI.Repositorios;
using SGI.Aplicacion;
public class RepositorioCategoriaTXT : RepositorioTXT,IRepositorio<Categoria> 
{ 
    public RepositorioCategoriaTXT() : base("Categorias.txt",0)
    {
    }
        

    public void Alta(Categoria categoria)
    {
        var ultId= ObtenerUltimoID("Categorias.txt") + 1; 
        categoria.ID = ultId;
        using var sw = new StreamWriter(_nombreArch, true);
        string line= string.Join(";",categoria.ID,categoria.Nombre,categoria.Descripcion,categoria.FechaCreacion,categoria.FechaUltimaModificacion);
        sw.WriteLine(line);
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
        sr.Close(); sw.Close();
        File.Delete(_nombreArch); //borro el archivo original
        File.Move(tempFile, _nombreArch); //renombro el archivo temporal
    }
    public void Modificar(Categoria categoria)
    {
        var tempFile = Path.GetTempFileName();
        var sr = new StreamReader(_nombreArch);
        var sw = new StreamWriter(tempFile);
        while(!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var fields = line?.Split(';');

            if(fields!= null && int.Parse(fields[0]) == categoria.ID)  //si el ID del producto es igual al ID del producto que quiero modificar
            {
                string newLine= string.Join(";",categoria.ID,categoria.Nombre,categoria.Descripcion,categoria.FechaCreacion,categoria.FechaUltimaModificacion);
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

    public Categoria? ObtenerPorID(int ID)
    {
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream)
        {
            var line= sr.ReadLine();
            var fields= line?.Split(';');
            if(fields != null && int.Parse(fields[0]) == ID)
            {
                return new Categoria
                {
                    ID = int.Parse(fields[0]),
                    Nombre = fields[1],
                    Descripcion = fields[2],
                    FechaCreacion = DateTime.Parse(fields[3]),
                    FechaUltimaModificacion = DateTime.Parse(fields[4])
                };
            }
        }
        sr.Close();
        return null;
    }

    public List<Categoria> ObtenerTodos()
    {
        var lista = new List<Categoria>();
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream)
        {
            var line= sr.ReadLine();
            var fields= line?.Split(';');
            if(fields != null)
            {
                lista.Add(new Categoria
                {
                    ID = int.Parse(fields[0]),
                    Nombre = fields[1],
                    Descripcion = fields[2],
                    FechaCreacion = DateTime.Parse(fields[3]),
                    FechaUltimaModificacion = DateTime.Parse(fields[4])
                });
            }
        }
        sr.Close();
        return lista;
    }
}
