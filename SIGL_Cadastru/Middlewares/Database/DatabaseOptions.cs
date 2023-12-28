using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Middlewares.Database;

public static class DatabaseOptions
{
    public static string Path { get; } = $"{AppDomain.CurrentDomain.BaseDirectory}\\..\\DB";
    public static string DataBaseFile { get;} = "SIGLDB.db";
    public static string ConnectionString { get; } = $"Data Source={Path}\\{DataBaseFile}";

}
