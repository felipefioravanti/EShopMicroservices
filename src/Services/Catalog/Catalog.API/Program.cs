var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Inject Carter from BuildingBlocks, in the current assembly
builder.Services.AddCarter(null, config =>
{
    var modules = typeof(Program).Assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();
    config.WithModules(modules);
});

// Inject MediatR from BuildingBlocks, in the current assembly
builder.Services.AddMediatR(config =>
{
    Console.WriteLine(typeof(Program).Assembly);
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();