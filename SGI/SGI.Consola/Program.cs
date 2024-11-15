using Microsoft.Extensions.DependencyInjection;
using SGI.Aplicacion;
using SGI.Repositorios;

var serviceProvider = new ServiceCollection()
    .AddDbContext<SGIContext>()
    .AddScoped<IRepositorioCategoria, RepositorioCategoria>()
    .AddScoped<IRepositorioProducto, RepositorioProducto>()
    .AddScoped<IRepositorioTransaccion, RepositorioTransaccion>()
    .AddScoped<IRepositorioUsuario, RepositorioUsuario>()
    .AddScoped<IServicioAutorizacion, ServicioAutorizacion>()
    .AddScoped<UseCase_AltaCategoria>()
    .AddScoped<UseCase_AltaProducto>()
    .AddScoped<UseCase_AltaTransaccion>()
    .AddScoped<UseCase_AltaUsuario>()
    .AddScoped<UseCase_BajaCategoria>()
    .AddScoped<UseCase_BajaProducto>()
    .AddScoped<UseCase_BajaTransaccion>()
    .AddScoped<UseCase_BajaUsuario>()
    .AddScoped<UseCase_ConsultaTransaccion>()
    .AddScoped<UseCase_ListarTransacciones>()
    .AddScoped<UseCase_ModificarCategoria>()
    .AddScoped<UseCase_ModificarProducto>()

    .BuildServiceProvider();



SGISqlite.Inicializar();
using (var context = new SGIContext())
{
    var repoCategoria = serviceProvider.GetService<IRepositorioCategoria>()!;
    var repoProducto = serviceProvider.GetService<IRepositorioProducto>()!;
    var repoTransaccion = serviceProvider.GetService<IRepositorioTransaccion>()!;
    var repoUsuario = serviceProvider.GetService<IRepositorioUsuario>()!;  
    
    var useCaseAltaCategoria = serviceProvider.GetService<UseCase_AltaCategoria>()!;
    var useCaseAltaProducto = serviceProvider.GetService<UseCase_AltaProducto>()!;
    var useCaseAltaTransaccion = serviceProvider.GetService<UseCase_AltaTransaccion>()!;
    var useCaseAltaUsuario = serviceProvider.GetService<UseCase_AltaUsuario>()!;
    
    var useCaseBajaCategoria = serviceProvider.GetService<UseCase_BajaCategoria>()!;
    var useCaseBajaProducto = serviceProvider.GetService<UseCase_BajaProducto>()!;
    var useCaseBajaTransaccion = serviceProvider.GetService<UseCase_BajaTransaccion>()!;
    var useCaseBajaUsuario = serviceProvider.GetService<UseCase_BajaUsuario>()!;
    
    var useCaseConsultaTransaccion = serviceProvider.GetService<UseCase_ConsultaTransaccion>()!;
    var useCaseListarTransacciones = serviceProvider.GetService<UseCase_ListarTransacciones>()!;
    
    var useCaseModificarCategoria = serviceProvider.GetService<UseCase_ModificarCategoria>()!;
    var useCaseModificarProducto = serviceProvider.GetService<UseCase_ModificarProducto>()!;



    var usuario = new Usuario { Nombre = "Facu", Password = "Saettone", Permisos = new List<Permiso> { Permiso.CategoriaAlta, Permiso.CategoriaBaja, Permiso.CategoriaModificacion, Permiso.ProductoAlta, Permiso.ProductoBaja, Permiso.ProductoModificacion, Permiso.TransaccionAlta, Permiso.TransaccionBaja, Permiso.UsuarioAlta, Permiso.UsuarioBaja, Permiso.UsuarioModificacion} };
    var usuario2 = new Usuario { Nombre = "Nico", Password = "", Permisos = new List<Permiso> { Permiso.CategoriaAlta, Permiso.CategoriaBaja, Permiso.CategoriaModificacion, Permiso.ProductoAlta, Permiso.ProductoBaja, Permiso.ProductoModificacion, Permiso.TransaccionAlta, Permiso.TransaccionBaja} };
    var categoria = new Categoria { Nombre = "Electrodomésticos" };
    var transaccion = new Transaccion { Cantidad = 10, Tipo = Tipo.Entrada };
    var producto = new Producto { Nombre = "Heladera", CategoriaID = categoria.ID, StockDisponible = 100 };
    var producto2 = new Producto { Nombre = "Microondas", CategoriaID = categoria.ID, StockDisponible = 50 };

    useCaseAltaCategoria.Ejecutar(categoria, 1);
    useCaseAltaProducto.Ejecutar(producto, 1);
    useCaseAltaProducto.Ejecutar(producto2, 1);
    useCaseAltaUsuario.Ejecutar(usuario, 1);
    useCaseAltaUsuario.Ejecutar(usuario2, 1);
    useCaseAltaTransaccion.Ejecutar(transaccion, usuario.Id);
    


    useCaseBajaCategoria.Ejecutar(categoria.ID, usuario.Id);
    useCaseBajaProducto.Ejecutar(producto.ID, usuario.Id);
    useCaseBajaTransaccion.Ejecutar(transaccion.ID, usuario.Id);
    useCaseBajaUsuario.Ejecutar(usuario2.Id, usuario.Id);
    
    useCaseListarTransacciones.Ejecutar();
    useCaseConsultaTransaccion.Ejecutar(transaccion.ID);
    useCaseModificarCategoria.Ejecutar(categoria, usuario.Id);
    useCaseModificarProducto.Ejecutar(producto, usuario.Id);
    


    
}



