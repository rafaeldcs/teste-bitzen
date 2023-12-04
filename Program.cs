using AutoMapper;
using Microsoft.EntityFrameworkCore;
using teste.Entidade;
using teste.Models;
using teste.Repository;
using teste.Repository.Interface;
using teste.Services;
using teste.Services.Interface;

namespace teste
{
    public class Program
    {

        private readonly IConfiguration _configuration;

        public Program(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var services = builder.Services;

            string connectionString = "Server=LAPTOP-6F9ISQ9R\\SQLEXPRESS;Database=Teste;User Id=rafael;Password=1234;TrustServerCertificate=True";

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            services.AddScoped<IAbastecimentoService, AbastecimentoService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IMotoristaService, MotoristaService>();

            services.AddScoped<IAbastecimentoRepository, AbastecimentoRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<MotoristaModel, Motorista>();
                config.CreateMap<Motorista, MotoristaModel>();
                config.CreateMap<Veiculo, VeiculoModel>();
                config.CreateMap<VeiculoModel, Veiculo>();
                config.CreateMap<Abastecimento, AbastecimentoModel>();
                config.CreateMap<AbastecimentoModel, Abastecimento>();
            }).CreateMapper());

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
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
