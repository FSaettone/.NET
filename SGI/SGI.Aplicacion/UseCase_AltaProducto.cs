using System;

namespace SGI.Aplicacion;

public class UseCase_AltaProducto (IRepositorio<Producto> repo, IServicioAutorizacion servicioAutorizacion)
{
    private readonly ProductoValidador _validador= new ProductoValidador();

    public void Ejecutar(Producto producto, int idUsuario)
    {
        try 
        {
            servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.CategoriaAlta);
            _validador.Validar(producto);
            repo.Alta(producto);
            Console.WriteLine($"El producto {producto.Nombre} ha sido dado de alta con exito con stock: {producto.StockDisponible}");
        }
        catch (ValidacionException ex)
        {
            System.Console.WriteLine("Error de Validacion: "+ex.Message);
        }
        catch (PermisosException ex)
        {
            System.Console.WriteLine("Error de Permisos: "+ex.Message);
        }
        
    }
}
