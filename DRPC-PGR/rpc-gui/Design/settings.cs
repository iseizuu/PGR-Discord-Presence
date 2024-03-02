using System;
using System.Reflection;
using System.Windows.Forms;
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
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderBrowserDialog.SelectedPath;
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = selectedFolder;
                        openFileDialog.Filter = "Executable Files|*.exe";
                        openFileDialog.Title = "Choose launcher.exe";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedFilePath = openFileDialog.FileName;
                            string fileName = xml.GetFileNameFromPath(selectedFilePath);
                            if (fileName != "launcher.exe")
                            {
                                MessageBox.Show("Weird, seems like this exe is not launcher.exe \nPlease try again!!", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                save(selectedFilePath);
                            }
                        }
                    }
                }
            }
        }

        private void save(string path)
        {
            MessageBox.Show($"Path file .exe: {path}");
            textBox1.ResetText();
            textBox1.AppendText($"{path}");
            warning.Text = "Path Update: make sure that is correct path";
            xml.SaveToXml(path);
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
    }
}
