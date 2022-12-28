using CurlingChallenge.Services;
using CurlingChallenge.Services.Interfaces;

namespace CurlingChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICurlingService, CurlingService>();
            //builder.Services.AddSingleton<IXCoordinateGenerator, XCoordinateGeneratorWithStaticOutput>(); //for testing
            builder.Services.AddSingleton<IXCoordinateGenerator, XCoordinateGenerator>(); //original

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}