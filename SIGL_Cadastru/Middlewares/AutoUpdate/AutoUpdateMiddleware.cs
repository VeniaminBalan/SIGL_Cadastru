using Microsoft.Extensions.Hosting;
using SIGL_Cadastru.Middlewares.Database;
using Squirrel;
using System.Diagnostics;

namespace SIGL_Cadastru.Middlewares.AutoUpdate;

public static class AutoUpdateMiddleware
{
    
    public static async Task CheckForUpdatesAsync(this IHost host)
    {
        using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/VeniaminBalan/SIGL_Cadastru"))
        {
            try
            {
                var version = mgr.CurrentlyInstalledVersion();

                if (version is null)
                {
                    Program.Version = "Development";
                }
                else 
                {
                    Program.Version = version.ToString();
                }
                

                var updateInfo = await mgr.CheckForUpdate();

                if (updateInfo.ReleasesToApply.Any())
                {
                    // Update available, apply it
                    CreateDatabaseBackup();

                    await mgr.UpdateApp();     
                    UpdateManager.RestartApp();
                }
            }
            catch (Exception ex)
            {
                // Handle update check error
                Debug.WriteLine($"Update check failed: {ex.Message}");
            }
        }
    }

    static void CreateDatabaseBackup()
    {
        string filePath = Path.Combine(DatabaseOptions.Path, DatabaseOptions.DataBaseFile);


        string backupFolderPath = DatabaseOptions.BackupPath;
        string backupFilePath = Path.Combine(backupFolderPath, $"DB_{Program.Version}_{DateTime.Now.ToString("dd-MM-yyyy")}");

        try
        {
            if (File.Exists(filePath))
            {
                if (!Directory.Exists(backupFolderPath))
                {
                    Directory.CreateDirectory(backupFolderPath);
                    Console.WriteLine($"Backup folder '{backupFolderPath}' created.");
                }

                // Copy the file to the backup folder
                File.Copy(filePath, backupFilePath);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


}
