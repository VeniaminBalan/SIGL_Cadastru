using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SIGL_Cadastru.Repo.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Middlewares.Database;

public static class MigrationMiddleware
{
    public static void MigrateIfNeeded(this IHost host)
    {
        var dbContext = host.Services.GetService<AppDbContext>();

        if (dbContext is null)
            throw new Exception("dbcontext is null");

        CheckDatabaseFiles();

        dbContext.Database.MigrateAsync().Wait();

    }

    private static bool CheckDatabaseFiles()
    {
        string folderPath = DatabaseOptions.Path;
        string fileName = DatabaseOptions.DataBaseFile;
        string connectionString  = DatabaseOptions.ConnectionString;

        string filePath = Path.Combine(folderPath, fileName);

        try
        {
            // Ensure the folder exists; create it if it doesn't
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Folder '{folderPath}' created.");
            }

            if (File.Exists(filePath))
            {
                Console.WriteLine($"File '{fileName}' already exists in the folder.");
            }
            else
            {
                // Create the file
                File.OpenWrite(filePath);

                Console.WriteLine($"File '{fileName}' created in the folder.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return false;
    }
}
