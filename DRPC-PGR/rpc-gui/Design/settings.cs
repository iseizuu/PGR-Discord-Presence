using System;
using System.Reflection;
using System.Windows.Forms;
using XMLReader;
using XMLReader.Helpers;

namespace Discord_RPC.GUI
{
    public partial class settings : Form
    {

        public settings()
        {
            InitializeComponent();
            labelVersion.Text = $"ver {Assembly.GetExecutingAssembly().GetName().Version}";
            textBox1.ReadOnly = true;
            textBox1.AppendText(xml.ReadSettings().appPath);
            testerLabel.Text = "1. Runecy\n2. Wege";
            launcherMsg.AppendText(xml.ReadSettings().inLauncherMessage);
            gameMsg.AppendText(xml.ReadSettings().inGameMessage);
        }

        private void SaveSettings()
        {
            XmlSettings settings = new XmlSettings();
            settings.appPath = textBox1.Text.ToString();
            settings.inLauncherMessage = launcherMsg.Text.ToString();
            settings.inGameMessage = gameMsg.Text.ToString();
            xml.SaveToXml(settings);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void settings_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/iseizuu");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Choose launcher.exe";
            openFileDialog.Filter = "Executable Files|launcher.exe";
            openFileDialog.CheckFileExists = true;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                savePath(selectedFilePath);
            }
        }

        private void savePath(string path)
        {
            MessageBox.Show($"Path file .exe: {path}");
            textBox1.ResetText();
            textBox1.AppendText($"{path}");
            warning.Text = "Path Update: make sure that is correct path";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pathLabel_Click(object sender, EventArgs e)
        {

        }

        private void testerLabel_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void launcherMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(launcherMsg.Text.ToString()) || string.IsNullOrEmpty(gameMsg.Text.ToString()))
            {
                MessageBox.Show("Form can't be blank");
            }
            else
            {
                MessageBox.Show("Saved", "Data Update!");
                SaveSettings();
            }
        }
    }
}
