using SinergyRP.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);

// Configuración de Sentry
builder.WebHost.UseSentry(o =>
{
    o.Dsn = builder.Configuration["Sentry:Dsn"];

    o.Debug = builder.Environment.IsDevelopment();

    // Sin monitoreo de rendimiento por ahora
    o.TracesSampleRate = 0.0;

    o.EnableLogs = true;
});
// Configuración de Sentry

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();