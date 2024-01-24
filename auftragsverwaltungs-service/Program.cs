using auftragsverwaltungs_service.Model;
using auftragsverwaltungs_service.Model.Repository.Customer;
using auftragsverwaltungs_service.Model.Repository.Milestone;
using auftragsverwaltungs_service.Model.Repository.Order;
using auftragsverwaltungs_service.Model.Repository.Team;
using auftragsverwaltungs_service.Service;
using auftragsverwaltungs_service.Service.Customer;
using auftragsverwaltungs_service.Service.Milestone;
using auftragsverwaltungs_service.Service.Order;
using auftragsverwaltungs_service.Service.Team;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace auftragsverwaltungs_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<IMilestoneRepository, MilestoneRepository>();
            builder.Services.AddScoped<IMilestoneService, MilestoneService>();

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            builder.Services.AddScoped<ITeamService, TeamService>();

            // Add services to the container.
            builder.Services.AddDbContext<AuftragsverwaltungsContext>(options =>
                options.UseSqlServer(AuftragsverwaltungsContext.GetConnectionString()));
            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddMvc();

            builder.Services.Configure<CultureInfo>(options =>
            {
                options.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
                options.DateTimeFormat.DateSeparator = ".";
                options.DateTimeFormat.ShortTimePattern = "HH:mm";
                options.DateTimeFormat.TimeSeparator = ":";
            });

            var app = builder.Build();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseCors();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}