
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;
using ReservationWorkplace.Repositories.EmployeeRepository;
using ReservationWorkplace.Repositories.EquipmentForWorkplaceRepository;
using ReservationWorkplace.Repositories.EquipmentRepository;
using ReservationWorkplace.Repositories.ReservationRepository;
using ReservationWorkplace.Repositories.WorkplaceRepository;
using ReservationWorkplace.Services.EmployeeService;
using ReservationWorkplace.Services.EquipmentService;
using ReservationWorkplace.Services.ReservationService;
using ReservationWorkplace.Services.WorkplaceService;
using ReservationWorkplace.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ReservationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WorkplaceConnectionString")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IWorkplaceRepository, WorkplaceRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentForWorkplaceRepository, EquipmentForWorkplaceRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IWorkplaceService, WorkplaceService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();

builder.Services.AddFluentValidationAutoValidation(/*conf =>
{
    
    conf.DisableDataAnnotationsValidation = true;
}*/);

builder.Services.AddScoped<IValidator<EmployeeViewModel>, EmployeeValidator>();
builder.Services.AddScoped<IValidator<ReservationViewModel>, ReservationValidator>();
builder.Services.AddScoped<IValidator<WorkplaceViewModel>, WorkplaceValidator>();
builder.Services.AddScoped<IValidator<EquipmentViewModel>, EquipmentValidator>();
builder.Services.AddScoped<IValidator<EquipmentForWorkplaceViewModel>, EquipmentForWorkplaceValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
