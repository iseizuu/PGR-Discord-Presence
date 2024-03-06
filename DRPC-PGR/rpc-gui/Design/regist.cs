using DRPC_PGR.rpc_gui.Utility;
using System;
using System.IO;
using System.Windows.Forms;
using XMLReader;
using XMLReader.Helpers;

namespace DRPC_PGR
{
    public partial class regist : Form
    {
        public regist()
        {
            InitializeComponent();
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
                MessageBox.Show($"Path file .exe: {selectedFilePath}\nNew Shortcut has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveSettings(selectedFilePath);

                path.Text = selectedFilePath;
                Utility.ShortcutUtility();
            }
        }

        public void SaveSettings(string path)
        {
            XmlSettings settings = new XmlSettings();
            settings.appPath = path;
            settings.inLauncherMessage = "In Launcher";
            settings.inGameMessage = "In Game";
            xml.SaveToXml(settings);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void regist_Load(object sender, EventArgs e)
        {

        }

        private void LocateButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Choose launcher.exe";
            openFileDialog.Filter = "Executable Files|launcher.exe";
            openFileDialog.CheckFileExists = true;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                MessageBox.Show($"Path file .exe: {selectedFilePath}\nNew Shortcut has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveSettings(selectedFilePath);

                path.Text = selectedFilePath;
                Utility.ShortcutUtility();
            }
        }

        private void path_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text.ToString();

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Are you serious?\nSubmit empty form >:(");
            }
      
            if (File.Exists(path))
            {
                string verifyExe = xml.regexExe(path);
                if (string.IsNullOrEmpty(verifyExe))
                {
                    MessageBox.Show("Invalid name, file name must be launcher.exe");
                }
                else
                {
                    MessageBox.Show($"Path file .exe: {path}\nNew Shortcut has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveSettings(path);
                    Utility.ShortcutUtility();
                }
            }
            else
            {
                MessageBox.Show($"{path} not found.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
