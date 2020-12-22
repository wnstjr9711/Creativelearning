using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public static class Dpi
{
    [DllImport("Shcore.dll")]
    public static extern int SetProcessDpiAwareness(int processDpiAwareness);
    public enum DpiAwareness
    {
        None = 0,
        SystemAware = 1,
        PerMonitorAware = 2
    }
}


namespace ACTIVITY_CONNECTED
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dpi.SetProcessDpiAwareness((int)Dpi.DpiAwareness.PerMonitorAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
