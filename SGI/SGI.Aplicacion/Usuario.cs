using System;

namespace SGI.Aplicacion;

public class Usuario 
{
    public int Id { get; set; }
    public string Nombre { get; set; }="";
    public string Apellido { get; set; }="";
    public string Email { get; set; }="";
    public string Password { get; set; }="";
    public List<Permiso> Permisos { get; set; }= new List<Permiso>();

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}";
    }
}
