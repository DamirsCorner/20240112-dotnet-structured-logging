var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.AddApplicationInsights(
    config =>
    {
        config.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
    },
    options => { }
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
