using System;
using SGI.Aplicacion;

namespace SGI.Repositorios;

public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IDUsuario, Permiso permiso)
    {
        if (IDUsuario == 1)
        {
            return true;
        }   
        else 
        {
            throw new PermisosException($"El usuario con ID: {IDUsuario} no tiene permisos para realizar esta acción");
        }
        

        /*Este servicio siempre debe responder true cuando el 
        IdUsuario sea igual a 1 y false en cualquier otro caso (no hace falta realizar
        ninguna verificación).*/
    }
}
