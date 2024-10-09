using System;
using Microsoft.VisualBasic;

namespace SGI.Repositorios;

public abstract class RepositorioTXT
{
    protected string _nombreArch=""; //si no le asigno un valor "" aparece el warning
    protected int ultimoID;
    protected RepositorioTXT(string _nombreArch,int ultimoID)
    {
        this._nombreArch = _nombreArch;
        this.ultimoID = ultimoID;
    }
    protected int ObtenerUltimoID(string _nombreArch)
    {
        int maxID = 0;
        if(File.Exists(_nombreArch))
        {
            using var sr= new StreamReader(_nombreArch);
            while(!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var fields = line?.Split(';');
                if(fields != null && int.Parse(fields[0]) > maxID)
                {
                    maxID = int.Parse(fields[0]);
                }
            }
        }
        return maxID;
    }
}
