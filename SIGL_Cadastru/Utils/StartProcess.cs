using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Utils
{
    internal class StartProcess
    {
        public static void Run(string path)
        {
            var processStartInfo = new ProcessStartInfo("cmd", $"/c start {path}");
            processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(processStartInfo);
        }
    }
}
