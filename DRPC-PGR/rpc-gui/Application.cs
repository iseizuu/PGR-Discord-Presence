using System;
using System.Diagnostics;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Runtime.InteropServices;
using System.Timers;
using System.Text;
using System.Threading;
using PGRRPC_GUI;
using System.Windows.Forms;
using DRPC_PGR;
using XMLReader.Helpers;
using Discord_RPC.GUI;

namespace PGRRPC
{
    public static class PGRRPC_MAIN
    {
        private static DiscordRpcClient client;
        private static System.Timers.Timer timer;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        private static RichPresence RPC = new RichPresence()
        {
            Assets = new Assets()
            {
                LargeImageKey = "logo",
                LargeImageText = "Punishing: Gray Raven",
            }
        };
        public static void Init()
        {
            try
            {
                client = new DiscordRpcClient("1211636813425541150"); // APP ID
                client.Logger = new ConsoleLogger();

                client.OnReady += (sender, e) =>
                {
                    Console.WriteLine("Discord Rich Presence is ready!");
                };

                client.Initialize();

                // Set interval timer
                timer = new System.Timers.Timer(2000);
                timer.Elapsed += OnTimerElapsed;
                timer.AutoReset = true;
                timer.Enabled = true;
                RPC.Timestamps = new Timestamps()
                {
                    Start = DateTime.UtcNow
                };
                Console.WriteLine("Presence is running..");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"RPC Err: {ex.Message}");
                Environment.Exit(0);
            }
        }

        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Thread.Sleep(8000);
                if (findApp() == "PGR")
                {
                    RPC.Details = xml.ReadSettings().inGameMessage;
                    client.SetPresence(RPC);
                }
                else if (findApp() == "Punishing Gray Raven")
                {
                    RPC.Details = xml.ReadSettings().inLauncherMessage;
                    client.SetPresence(RPC);
                }
                else if (int.Parse(findApp()) == 0)
                {
                    stop();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                client.Dispose();
                Environment.Exit(0);
            }
        }
        static string game;
        private static string findApp()
        {
            // Hmm broken code fr
            if (FindWindow(null, "PGR") != IntPtr.Zero)
            {
                game = "PGR";
            }
            else if (FindWindow(null, "Punishing Gray Raven") != IntPtr.Zero)
            {
                game = "Punishing Gray Raven";
            }
            else
            {
                game = "0";
            }
            return game;
        }

        public static void stop()
        {
            Console.WriteLine("RPC Stopped");
            client.Dispose();
            Environment.Exit(0);
        }
    }
}

