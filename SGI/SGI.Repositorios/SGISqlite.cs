using System;
using Microsoft.EntityFrameworkCore;
using SGI.Aplicacion;

namespace SGI.Repositorios;

public class SGISqlite
{
    public static void Inicializar()
    {
        using var context = new SGIContext();

        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");


            var u = new Usuario { 
                Nombre = "admin",
                Password= "admin",
                Permisos = new List<Permiso> { 
                    Permiso.CategoriaAlta,
                     Permiso.CategoriaBaja,
                      Permiso.CategoriaModificacion,
                       Permiso.ProductoAlta,
                        Permiso.ProductoBaja,
                         Permiso.ProductoModificacion,
                          Permiso.TransaccionAlta,
                           Permiso.TransaccionBaja,
                            Permiso.TransaccionListar,
                             Permiso.UsuarioAlta,
                              Permiso.UsuarioBaja,
                               Permiso.UsuarioModificacion,
                                Permiso.PermisoModificar
                                } 
            };
        
            context.Add(u);
            context.SaveChanges();
        }
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }


    }
}
