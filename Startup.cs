using PFLogistcs.Context;
using Microsoft.EntityFrameworkCore;
using PFLogistcs.Services;
using PFLogistcs.Repositories;
using PFLogistcs.Repositories.Interfaces;

namespace PFLogistcs
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        
        public Startup(IConfiguration configuration) {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PFLogisticsDbContext>(opt => {
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IGenericRepository, GenericRepository>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env) {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            } else 
            {
                app.UseHttpsRedirection();
            }


            app.UseAuthorization();

            app.MapControllers();
        }
    }
}