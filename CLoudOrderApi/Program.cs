using Autofac;
using Autofac.Extensions.DependencyInjection;
using CloudOrderApi.Contexts;
using CloudOrderApi.Services;
using Microsoft.EntityFrameworkCore.Internal;

namespace CloudOrderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
          

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.Register(c => 
                    new CloudDBContext("Host=localhost;Port=5433;Username=postgres;Password=example;Database=CloudOrderDb")).InstancePerDependency();
            });

            builder.Services.AddSingleton<ICloudOrderService, CloudOrderService>();

            var app = builder.Build();

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
