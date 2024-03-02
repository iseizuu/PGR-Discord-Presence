using PGRRPC;
using System;
using System.Windows.Forms;

namespace Discord_RPC.GUI
{
    public partial class Form1 : Form
    {
        private settings settingsFormInstance;
        public Form1()
        {
            InitializeComponent();

            console.AppendText("Presence Now Running..! \n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            console.AppendText("Stopping thread... \n");
            PGRRPC_MAIN.stop();
            Environment.Exit(0);
        }

        private void settings_button_Click(object sender, EventArgs e)
        {
            if (settingsFormInstance == null || settingsFormInstance.IsDisposed)
            {
                // Jika form belum terbuka atau sudah ditutup, buat instance baru
                settingsFormInstance = new settings();
                settingsFormInstance.Show();
            }
            else
            {
                // Jika form sudah terbuka, fokus pada form yang sudah ada
                settingsFormInstance.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NOX_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.com/invite/dveQtqx");
        }
    }
}
