using DesignPattern.API.Attribute;
using DesignPattern.Factory.BAL;
using DesignPattern.Factory.BAL.Factory;
using DesignPattern.Factory.BAL.Interfaces;
using DesignPattern.Singleton.DAL.Database;

var builder = WebApplication.CreateBuilder(args);

// Registration Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Service Registrations for Singleton Design Pattern

// Add Scoped means as deferred loading
builder.Services.AddScoped<ManageDatabaseForSingleton>();

// Add Singleton means as Eager Loading
builder.Services.AddSingleton<LogAttribute>();

// Use logging
//builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

#endregion

#region Registration for Factory Design Pattern

builder.Services.AddTransient<DesignPattern.Factory.BAL.Database.ManageDatabaseForFactory>();
builder.Services.AddTransient<IDepartmentFactory, DepartmentFactory>();
builder.Services.AddTransient<EmployeeCalculations>();

#endregion


var app = builder.Build();

#region Registration of Middleware

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion