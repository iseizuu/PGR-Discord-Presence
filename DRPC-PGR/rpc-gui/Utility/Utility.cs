using System;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace DRPC_PGR.rpc_gui.Utility
{
    public static class Utility
    {
        private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static void ShortcutUtility()
        {
            string[] setupFiles = Directory.GetFiles(desktopPath, $"setup-pgr.*");
            string shortcutLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PGR-RPC.lnk");

            // Create shortcut
            File.Delete(setupFiles[0]);
            CreateShortcut(Application.ExecutablePath, shortcutLocation);
            Application.Exit();
        }

        public static void CreateShortcut(string targetPath, string shortcutLocation)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            shortcut.Description = "Punishing: Discord Presence";
            shortcut.IconLocation = targetPath;
            shortcut.Save();
        }
    }
}
