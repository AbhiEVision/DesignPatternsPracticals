using DesignPattern.API.Attribute;
using DesignPattern.Singleton.DAL.Database;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Service Registrations for Singleton Design Pattern
// Registration Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Scoped means as deferred loading
builder.Services.AddScoped<ManageDatabase>();

// Add Singleton means as Eager Loading
builder.Services.AddSingleton<LogAttribute>();

// Use logging
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

#endregion

var app = builder.Build();

#region Registration of Middleware

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion