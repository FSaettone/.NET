
using InterfazBlzr.Components;
using Microsoft.EntityFrameworkCore;
using SGI.Aplicacion;
using SGI.Repositorios;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SGIContext>();
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
builder.Services.AddScoped<IRepositorioProducto, RepositorioProducto>();
builder.Services.AddScoped<IRepositorioTransaccion, RepositorioTransaccion>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

builder.Services.AddScoped<UseCase_AltaCategoria>();
builder.Services.AddScoped<UseCase_AltaProducto>();
builder.Services.AddScoped<UseCase_AltaPermiso>();
builder.Services.AddScoped<UseCase_AltaTransaccion>();
builder.Services.AddScoped<UseCase_AltaUsuario>();
builder.Services.AddScoped<UseCase_BajaCategoria>();
builder.Services.AddScoped<UseCase_BajaProducto>();
builder.Services.AddScoped<UseCase_BajaTransaccion>();
builder.Services.AddScoped<UseCase_BajaUsuario>();
builder.Services.AddScoped<UseCase_ConsultaTransaccion>();
builder.Services.AddScoped<UseCase_ListarTransacciones>();
builder.Services.AddScoped<UseCase_ModificarCategoria>();
builder.Services.AddScoped<UseCase_ModificarProducto>();
builder.Services.AddScoped<UseCase_IniciarSesion>();
builder.Services.AddScoped<UseCase_ModificarUsuario>();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IServicioAutorizacion, ServicioSesion>();



SGISqlite.Inicializar();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
