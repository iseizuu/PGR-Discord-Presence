using DRPC_PGR;
using PGRRPC_GUI;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using XMLReader.Helpers;

public class Program
{
    [STAThread]
    public static void Main()
    {
        string path = xml.ReadSettings().appPath;
        if (string.IsNullOrEmpty(path))
        {
            MessageBox.Show("Welcome!!\nThis is first time you use this app, you need to setup first\n>//<", "Setup");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new regist());
        }
        else
        {
            run(path);
        }
    }

    private static void run(string path)
    {
        if (System.IO.File.Exists(path))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(path);
            Process process = new Process
            {
                StartInfo = startInfo
            };

            try
            {
                process.Start();
                GUI.INIT();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }
        else
        {
            MessageBox.Show("Executable file not found at: " + path);
            Environment.Exit(0);
        }

    }
}
