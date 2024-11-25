var builder = WebApplication.CreateBuilder(args);

builder
    .Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile(
        $"appsettings.{builder.Environment.EnvironmentName}.json",
        optional: false,
        reloadOnChange: true
    )
    .AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
