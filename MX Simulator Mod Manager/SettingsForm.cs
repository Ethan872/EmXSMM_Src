using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MX_Simulator_Mod_Manager
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            Startup startupRoutine = new Startup();
            mxsDirTbox.Text = startupRoutine.getMXSDirectory();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                mxsDirTbox.Text = folderBrowser.SelectedPath;
            } else
            {
                MessageBox.Show("No directory selected");
            }
        }
        private void settingsCloseBtn_Click(object sender, EventArgs e)
        {
            
            if (mxsDirTbox.Text == "" || mxsDirTbox.Text == "MX Simulator Directory")
            {
                notiBox.Show();
                
            } else
            {
                updateSettings();
                notiBox.Hide();
                Hide();
            }
        }
        private void updateSettings()
        {
            using (StreamWriter sw = new StreamWriter("emxsmm.txt"))
            {
                sw.Write(mxsDirTbox.Text);
                sw.Close();
            }
        }
    }
}
