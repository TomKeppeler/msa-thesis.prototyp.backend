
using AutoMapper;
using buchhaltungs_service.Model;
using buchhaltungs_service.Model.Repository.Activity;
using buchhaltungs_service.Model.Repository.Employee;
using buchhaltungs_service.Model.Repository.Invoice;
using buchhaltungs_service.Service;
using buchhaltungs_service.Service.Activity;
using buchhaltungs_service.Service.Employee;
using buchhaltungs_service.Service.Invoice;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Web.Cors;

var builder = WebApplication.CreateBuilder(args);
var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

// Add services to the container.
builder.Services.AddDbContext<BuchhaltungsContext>(options =>
    options.UseSqlServer(BuchhaltungsContext.GetConnectionString()));
builder.Services.AddControllers(); 
builder.Services.AddHttpContextAccessor();/*
builder.Services.Configure<RequestLocalizationOptions>(options =>

{
    var supportedCultures = new[]
    {
        CultureInfo.InvariantCulture,
    };
    options.DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
*/
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc();


builder.Services.Configure<CultureInfo>(options =>
{
    options.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
    options.DateTimeFormat.DateSeparator = ".";
    options.DateTimeFormat.ShortTimePattern = "HH:mm";
    options.DateTimeFormat.TimeSeparator = ":";
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();

app.Run();
