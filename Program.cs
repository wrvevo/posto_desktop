using posto_desktop;
using posto_desktop.UI;
using System;
using System.Windows.Forms;

namespace posto_desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
