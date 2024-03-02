using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
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
                                MessageBox.Show($"Path file .exe: {selectedFilePath}\nNew Shortcut has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                label2.Text = selectedFilePath;
                                xml.SaveToXml(selectedFilePath);

                                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                string[] setupFiles = Directory.GetFiles(desktopPath, $"setup-pgr.*");
                                string shortcutLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PGR-RPC.lnk");

                                // Create shortcut
                                File.Delete(setupFiles[0]);
                                xml.CreateShortcut(Application.ExecutablePath, shortcutLocation);
                                // Process.Start(Application.ExecutablePath);
                                Application.Exit();
                            }
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void regist_Load(object sender, EventArgs e)
        {

        }
    }
}
