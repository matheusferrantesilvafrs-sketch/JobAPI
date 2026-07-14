using Microsoft.EntityFrameworkCore;
using JobAPI.Data;
using JobAPI.Models;
using JobAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var defaultConnection =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found."
    );

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        defaultConnection,
        ServerVersion.AutoDetect(defaultConnection)
    )
);

builder.Services.AddScoped<CadastroService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("PermitirFrontend");

app.MapGet("/", () =>
{
    return Results.Ok("API JobTracker funcionando!");
});

app.MapGet("/dadoscad", async (AppDbContext context) =>
{
    var cadastros = await context.PostDados.ToListAsync();

    return Results.Ok(cadastros);
});

app.MapGet("/dadoscad/{id:int}", async (
    int id,
    AppDbContext context) =>
{
    var cadastro = await context.PostDados.FindAsync(id);

    if (cadastro is null)
    {
        return Results.NotFound("Cadastro não encontrado.");
    }

    return Results.Ok(cadastro);
});

app.MapPost("/dadoscad", async (
    PostDados novoCadastro,
    AppDbContext context) =>
{
    context.PostDados.Add(novoCadastro);

    await context.SaveChangesAsync();

    return Results.Created(
        $"/dadoscad/{novoCadastro.ID}",
        novoCadastro
    );
});

app.MapPut("/dadoscad/{id:int}", async (
    int id,
    PutDados cadastroAtualizado,
    AppDbContext context) =>
{
    var cadastroExistente = await context.PostDados.FindAsync(id);

    if (cadastroExistente is null)
    {
        return Results.NotFound("Cadastro não encontrado.");
    }

    cadastroExistente.Empresa = cadastroAtualizado.Empresa;
    cadastroExistente.Cargo = cadastroAtualizado.Cargo;
    cadastroExistente.Data = cadastroAtualizado.Data;
    cadastroExistente.Descrições = cadastroAtualizado.Descrições;

    await context.SaveChangesAsync();

    return Results.Ok(cadastroExistente);
});

app.MapDelete("/dadoscad/{id:int}", async (
    int id,
    AppDbContext context) =>
{
    var cadastro = await context.PostDados.FindAsync(id);

    if (cadastro is null)
    {
        return Results.NotFound("Cadastro não encontrado.");
    }

    context.PostDados.Remove(cadastro);

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();