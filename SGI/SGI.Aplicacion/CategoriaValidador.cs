using System;

namespace SGI.Aplicacion;

public class CategoriaValidador 
{
    public void Validar(Categoria categoria)
    {
        if (categoria.Nombre == null || categoria.Nombre == "")
        {
            throw new ValidacionException("El nombre de la categoria no puede estar vacío");
        }
    }

    public void  ValidarBaja(List<Producto> productos, int ID)
    {
        foreach (var producto in productos)
        {
            if (producto.CategoriaID == ID)
            {
                throw new ValidacionException("No se puede dar de baja una categoria con productos asociados");
            }
        }
    }
}
