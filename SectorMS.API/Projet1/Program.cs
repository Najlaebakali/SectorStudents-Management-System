using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SectorMS.Dao.Abstraction;
using SectorMS.Dao.EF.Sectors;
using SectorMS.Dao.EF.Students;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Ajouter les services nécessaires
        builder.Services.AddControllers();
        builder.Services.AddScoped<ISectorRepository, SectorsRepository>(); // Injection de dépendance pour le repository
        builder.Services.AddScoped<IStudentRepository, StudentsRepository>(); // Ajouter l'injection de dépendance pour les étudiants

       
        // Add Swagger to the project
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();
        
 
        // Configurer le pipeline HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(); // Page d'exception en développement
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthorization(); // Si vous avez besoin de l'authentification/autorisation

        app.MapControllers(); // Mappe les contrôleurs aux routes HTTP

        app.Run(); // Lance l'application
    }
}