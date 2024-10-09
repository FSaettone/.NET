using SGI.Aplicacion;
using SGI.Repositorios;


IRepositorio<Categoria> repoCategoria = new RepositorioCategoriaTXT();
IRepositorio<Producto> repoProducto = new RepositorioProductoTXT();
IRepositorio<Transaccion> repoTransaccion = new RepositorioTransaccionTXT();
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacion();

var agregarProducto = new UseCase_AltaProducto(repoProducto, servicioAutorizacion);
var agregarCategoria = new UseCase_AltaCategoria(repoCategoria, servicioAutorizacion);
var agregarTransaccion = new UseCase_AltaTransaccion(repoTransaccion, servicioAutorizacion, repoProducto);

var eliminarProducto = new UseCase_BajaProducto(repoProducto, repoTransaccion,servicioAutorizacion);
var eliminarCategoria = new UseCase_BajaCategoria(repoProducto, repoCategoria, servicioAutorizacion);
var eliminarTransaccion = new UseCase_BajaTransaccion(repoTransaccion, servicioAutorizacion, repoProducto);


var modificarProducto = new UseCase_ModificarProducto(repoProducto, servicioAutorizacion);
var modificarCategoria = new UseCase_ModificarCategoria(repoCategoria, servicioAutorizacion);


var listarTransacciones = new UseCase_ListarTransacciones(repoTransaccion);
var consultarTransaccion = new UseCase_ConsultaTransaccion(repoTransaccion, repoProducto);

agregarCategoria.Ejecutar(new Categoria(){Nombre="Perfumeria", Descripcion="Productos de Perfumeria"},1);
agregarCategoria.Ejecutar(new Categoria(){Nombre="Limpieza", Descripcion="Productos de limpieza"},1);

agregarProducto.Ejecutar(new Producto(){Nombre="Shampoo", Descripcion="Shampoo para cabello", PrecioUnitario=100, CategoriaID=1},1);
agregarProducto.Ejecutar(new Producto(){Nombre="Detergente", Descripcion="Detergente para ropa", PrecioUnitario=50, CategoriaID=2},1);
agregarProducto.Ejecutar(new Producto(){Nombre="Jabon", Descripcion="Jabon para manos", PrecioUnitario=30, CategoriaID=2},1);

agregarTransaccion.Ejecutar(new Transaccion(){ProductoID=1, Cantidad=20, Tipo=Tipo.Entrada},1);
agregarTransaccion.Ejecutar(new Transaccion(){ProductoID=2, Cantidad=1, Tipo=Tipo.Entrada},1);
agregarTransaccion.Ejecutar(new Transaccion(){ProductoID=3, Cantidad=3, Tipo=Tipo.Entrada},1);


listarTransacciones.ListarTransacciones();

consultarTransaccion.ConsultarTransaccion(1);
agregarTransaccion.Ejecutar(new Transaccion(){ProductoID=1, Cantidad=10, Tipo=Tipo.Salida},1);
consultarTransaccion.ConsultarTransaccion(1);

listarTransacciones.ListarTransacciones();

listarTransacciones.ListarTransacciones(DateTime.Now.AddDays(-1), DateTime.Now);


eliminarTransaccion.Ejecutar(1,1);
eliminarTransaccion.Ejecutar(2,2); //aqui lanzara una excepcion de permisos, ya que el usuario 2 no tiene permisos para eliminar transacciones


eliminarProducto.Ejecutar(1,1);
eliminarProducto.Ejecutar(2,1); //aqui se eliminaran las transacciones asociadas al producto 2, y luego se eliminara el producto 2


modificarProducto.Ejecutar(new Producto(){ID=2, Nombre="Detergente en polvo", Descripcion="Detergente en polvo para ropa", PrecioUnitario=60, CategoriaID=2},1);
modificarCategoria.Ejecutar(new Categoria(){ID=2, Nombre="Limpieza", Descripcion="Productos de limpieza y aseo"},1);


eliminarCategoria.Ejecutar(1,1);


listarTransacciones.ListarTransacciones(); // se listaran las transacciones restantes, solo la de ID 3

Console.WriteLine("----------------------------------------Fin----------------------------------------");
//poner breakpoint aca para ver los archivos generados, ya que seran eliminados al finalizar el programa
File.Delete("Categorias.txt");
File.Delete("Productos.txt");
File.Delete("Transacciones.txt");



