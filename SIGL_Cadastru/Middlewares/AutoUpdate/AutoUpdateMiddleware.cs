using Microsoft.Extensions.Hosting;
using Squirrel;
using System.Diagnostics;

namespace SIGL_Cadastru.Middlewares.AutoUpdate;

public static class AutoUpdateMiddleware
{
    
    public static async Task CheckForUpdatesAsync(this IHost host, IUpdateManager updateManager)
    {
        try
        {
            var updateInfo = await updateManager.CheckForUpdate();

            if (updateInfo.ReleasesToApply.Any())
            {
                // Update available, apply it
                await updateManager.UpdateApp();
            }
        }
        catch (Exception ex)
        {
            // Handle update check error
            Debug.WriteLine($"Update check failed: {ex.Message}");
        }
    }
    
}
