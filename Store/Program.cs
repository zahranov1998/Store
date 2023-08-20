using Store.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(option => option.Filters.Add<ResultFilter>());

builder.RegistrationService();

var app = builder.Build();

app.MapControllers();

app.Use(ExceptionMiddleware.Handle);

app.Run();