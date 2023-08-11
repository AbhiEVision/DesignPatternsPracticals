using DesignPatterns.AbstractFactory.BAL;
using DesignPatterns.AbstractFactory.BAL.Database;
using DesignPatterns.AbstractFactory.BAL.Implemantations.Factories;
using DesignPatterns.AbstractFactory.BAL.Interfaces;
using DesignPatterns.API.Attribute;
using DesignPatterns.CQRS.DAL.Implementation.Repository;
using DesignPatterns.CQRS.DAL.Interface;
using DesignPatterns.Factory.BAL;
using DesignPatterns.Factory.BAL.Factory;
using DesignPatterns.Factory.BAL.Interfaces;
using DesignPatterns.Repository.DAL.Interface;
using DesignPatterns.Repository.DAL.Repositories;
using DesignPatterns.Singleton.DAL.Database;
using Serilog;
using System.Reflection;

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

//Use logging
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

#endregion

#region Registration for Factory Design Pattern

builder.Services.AddTransient<DesignPatterns.Factory.BAL.Database.ManageDatabaseForFactory>();
builder.Services.AddTransient<IDepartmentFactory, DepartmentFactory>();
builder.Services.AddTransient<EmployeeCalculations>();

#endregion

#region Registration for Abstract Factory Pattern

builder.Services.AddScoped<ManageDatabaseForAbstractFactory>();
builder.Services.AddScoped<IAbstractFactory, AbstractFactory>();
builder.Services.AddScoped<EmployeeCalculationsWithAbstractFactory>();

#endregion

#region Registration for Repository Design Pattern

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


#endregion

#region Registration for CQRS Design Pattern

builder.Services.AddScoped<IQueryRepository, QueryRepository>();
builder.Services.AddScoped<ICommandRepository, CommandRepository>();

#endregion

#region Registration for Mediator Pattern

builder.Services.AddMediatR(x =>
{
	x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
	//var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
	var Assemblies = new List<Assembly>();
	var newAssembly = new AssemblyName("DesignPatterns.Mediator");
	//foreach (var item in assemblyNames)
	//{
	//	Assemblies.Add(Assembly.Load(item));
	//}

	//foreach (var item in Assemblies)
	//{
	//	x.RegisterServicesFromAssembly(item);
	//}

	x.RegisterServicesFromAssembly(Assembly.Load(newAssembly));
});

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