
using Microsoft.EntityFrameworkCore;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Repositories.EmployeeRepository;
using ReservationWorkplace.Repositories.EquipmentForWorkplaceRepository;
using ReservationWorkplace.Repositories.EquipmentRepository;
using ReservationWorkplace.Repositories.ReservationRepository;
using ReservationWorkplace.Repositories.WorkplaceRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ReservationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WorkplaceConnectionString")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEquipmentForWorkplaceRepository, EquipmentForWorkplaceRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IWorkplaceRepository, WorkplaceRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
