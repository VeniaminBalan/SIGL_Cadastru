using Microsoft.Extensions.Hosting;
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
    
}
