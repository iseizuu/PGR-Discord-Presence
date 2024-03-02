using System;
using System.Threading;
using System.Windows.Forms;
using PGRRPC;

namespace PGRRPC_GUI
{
    static class GUI
    {
        static Thread t = new Thread(PGRRPC_MAIN.Init);
        [STAThread]
        public static void INIT()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            t.Start();
            using (NotifyIcon icon = new NotifyIcon())
            {
                icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                icon.ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Options", (s, e) => {new Discord_RPC.GUI.Form1().Show();}),
                    new MenuItem("Exit", (s, e) => { Application.Exit(); }),
                });
                icon.Visible = true;

                Application.Run();
                icon.Visible = false;
            }
        }
        static void OnApplicationExit(object sender, EventArgs e)
        {
            t.Abort();
        }
    }
}