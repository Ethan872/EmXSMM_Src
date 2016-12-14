using Ionic.Zip;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
namespace MX_Simulator_Mod_Manager
{

    public partial class Form1 : Form
    {
        /*public XmlDocument loadedDatabase;
        public string activeModExtension = "";
        public string activeModWithoutPath = "";
        public string activeMod = "";
        public string modEnvironment = "";
        public bool installScreenActive = true;
        */
        VariableManager vManager = new VariableManager();
        SettingsForm settingsForm = new SettingsForm();
        Startup startupRoutine = new Startup();
        DatabaseManager dbManager = new DatabaseManager();

        public Form1()
        {
            this.ShowIcon = true;
            this.Icon = Properties.Resources.emXSLogo;
            InitializeComponent();
            if (startupRoutine.settingsExist())
            {
                MessageBox.Show("Settings exist");
                initilizeEnvironment();
            }
            else
            {
                MessageBox.Show("Settings don't exist, update settings!");
                askToCreateSettings();
            }
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                vManager.setActiveModExtension(Path.GetExtension(file));
                vManager.setActiveMod(file);
                modTBox.Text = file;
            }
        }
        private void initilizeEnvironment()
        {
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }
        private void askToCreateSettings()
        {
            settingsForm.Show();
        }
        private void installBtn_Click(object sender, EventArgs e)
        {
            vManager.setActiveMod(modTBox.Text);
            vManager.setActiveModWithoutPath(Path.GetFileName(modTBox.Text));
            dbManager.checkDatabases();
            install(); //Check extension and install
            if (gearPackRadioBtn.Checked == true)
            {
                if (dbManager.CheckGearpackDatabase(vManager.getActiveMod()))
                {
                    MessageBox.Show("Doesn't exist, will add", "DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (checkExtension() == "zip")
                    {
                        registerZipMod();
                    }
                    else if (checkExtension() == "rar")
                    {
                        //registerRarMod();
                    }
                    else if (checkExtension() == "saf")
                    {
                        registerSafMod();
                    }
                    else if (checkExtension() == "notsupported")
                    {
                        MessageBox.Show("The file you specified is not supported!", "File not supported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ALREADY EXISTS!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (trackRadioBtn.Checked == true)
            {
                if (dbManager.CheckTrackDatabase(vManager.getActiveMod()))
                {
                    MessageBox.Show("Doesn't exist, will add", "DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (checkExtension() == "zip")
                    {
                        registerZipMod();
                    }
                    else if (checkExtension() == "rar")
                    {
                        //registerRarMod();
                    }
                    else if (checkExtension() == "saf")
                    {
                        registerSafMod();
                    }
                    else if (checkExtension() == "notsupported")
                    {
                        MessageBox.Show("The file you specified is not supported!", "File not supported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void registerZipMod()
        {
            using (ZipFile zip = ZipFile.Read(vManager.getActiveMod()))
            {
                foreach (ZipEntry e in zip)
                {
                    if (trackRadioBtn.Checked == true)
                    {
                        if (e.IsDirectory)
                        {
                            dbManager.updateTrackDatabaseZip(e, vManager.getActiveMod(), true);
                            break;
                        }
                        else
                        {
                            dbManager.updateTrackDatabaseZip(e, vManager.getActiveMod(), false);
                        }
                    }
                    else if (bikeRadioBtn.Checked == true)
                    {
                        //updateBikeDatabase(e);
                    }
                    else if (gearPackRadioBtn.Checked == true)
                    {
                        dbManager.updateGearpackDatabaseZip(e, vManager.getActiveMod());
                    }
                }
            }
        }
        /*private void registerRarMod()
        {
            foreach (RarArchiveEntry e in archive.Entries)
            {
                if (trackRadioBtn.Checked == true)
                {
                    dbManager.updateTrackDatabaseRar(e, vManager.getActiveMod());
                }
                else if (bikeRadioBtn.Checked == true)
                {
                    //updateBikeDatabase(e);
                }
                else if (gearPackRadioBtn.Checked == true)
                {
                    //dbManager.updateGearpackDatabaseRar(e, vManager.getActiveMod());
                }
            }
        }*/
        private void registerSafMod()
        {
            if(trackRadioBtn.Checked == true)
            {
                dbManager.updateTrackDatabaseSaf(vManager.getActiveMod());
            }
            else if (gearPackRadioBtn.Checked == true)
            {
                dbManager.updateGearpackDatabaseSaf(vManager.getActiveMod());
            }
        }
        private String checkExtension()
        {
            if(vManager.getActiveModExtension() == ".zip")
            {
                return "zip";
            } else if(vManager.getActiveModExtension() == ".saf")
            {
                return "saf";
            } else if(vManager.getActiveModExtension() == ".rar")
            {
                return "rar";
            }
            return "notsupported";
        }
        private void install()
        {
            if (vManager.getActiveModExtension() == ".saf")
            {
                dbManager.installSafMod(modTBox.Text, vManager.getActiveModWithoutPath());
                //MessageBox.Show(activeMod + " extension is " + activeModExtension);
            }
            else if (vManager.getActiveModExtension() == ".zip")
            {
                dbManager.installZipMod(vManager.getActiveMod());
                //MessageBox.Show(activeMod + " extension is " + activeModExtension);
            }
            else if(vManager.getActiveModExtension() == ".rar")
            {
                dbManager.installRarMod(vManager.getActiveMod());
            }
            else
            {
                MessageBox.Show("Unsupported file type", "emXS Mod Manager", MessageBoxButtons.OK);
            }
        }
        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            settingsForm.Show();
        }
        private void managerBtn_Click(object sender, EventArgs e)
        {
            if (vManager.isInstallScreenActive() == true)
            {
                showManagerScreen(); //Switch to manager
                installBtn.Enabled = false;
                managerBtn.Text = "Installer";
                vManager.setInstallScreenActive(false);
            }
            else if (vManager.isInstallScreenActive() == false)
            {
                showInstallerScreen(); //Switch to installer
                installBtn.Enabled = true;
                managerBtn.Text = "Manager";
                vManager.setInstallScreenActive(true);
            }

        }
        private void showManagerScreen()
        {
            managerPanel.Show();
            installPanel.Hide();
        }
        private void showInstallerScreen()
        {
            installPanel.Show();
            managerPanel.Hide();
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //loadModDatabase();
        }
        /*private void loadModDatabase()
        {
            modListBox.Items.Clear();
            string[] safModsWithPath = Directory.GetFiles(startupRoutine.getMXSDirectory(), "*.saf*");
            string[] safMods = new string[safModsWithPath.Length];
            for (int counter = 0; counter < safModsWithPath.Length; counter++)
            {
                safMods[counter] = Path.GetFileName(safModsWithPath[counter]);
            }
            for (int counter = 0; counter < safMods.Length; counter++)
            {
                modListBox.Items.Add(safMods[counter]);
            }
        }
        */
        private void filterGearBtn_Click(object sender, EventArgs e)
        {
            vManager.setModEnvironment("gear");
            vManager.newXmlDocument();
            vManager.getLoadedDatabase().Load("emXS_gearDB.xml");
            loadGearDatabase();
        }
        private void loadGearDatabase()
        {
            modListBox.Items.Clear();
            comboBox1.Items.Clear();
            XmlNode rootNode = vManager.getLoadedDatabase().SelectSingleNode("gearDB");
            if (rootNode.HasChildNodes)
            {
                foreach (XmlNode selectedNode in rootNode)
                {
                    if (comboBox1.Items.Count == 0)
                    {
                        comboBox1.Items.Add(selectedNode.Attributes[0].Value);
                    }
                    else
                    {
                        if (comboBox1.Items.Contains(selectedNode.Attributes[0].Value))
                        {
                            continue; //Select the next node
                        }
                        else
                        {
                            comboBox1.Items.Add(selectedNode.Attributes[0].Value);
                        }
                    }
                }
                foreach (XmlNode selectedNode in rootNode)
                {
                    modListBox.Items.Add(selectedNode.InnerText);
                }
            }
            else
            {
                MessageBox.Show("Gear Database is empty!", "Database is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void filterTracksBtn_Click(object sender, EventArgs e)
        {
            vManager.setModEnvironment("track");
            vManager.newXmlDocument();
            vManager.getLoadedDatabase().Load("emXS_trackDB.xml");
            loadTrackDatabase();
        }
        private void loadTrackDatabase()
        {
            modListBox.Items.Clear();
            comboBox1.Items.Clear();
            XmlNode rootNode = vManager.getLoadedDatabase().SelectSingleNode("trackDB");
            if (rootNode.HasChildNodes)
            {
                foreach (XmlNode selectedNode in rootNode)
                {
                    if (comboBox1.Items.Count == 0)
                    {
                        comboBox1.Items.Add(selectedNode.Attributes[0].Value);
                    }
                    else
                    {
                        if (comboBox1.Items.Contains(selectedNode.Attributes[0].Value))
                        {
                            continue; //Select the next node
                        }
                        else
                        {
                            comboBox1.Items.Add(selectedNode.Attributes[0].Value);
                        }
                    }
                }
                foreach (XmlNode selectedNode in rootNode)
                {
                    modListBox.Items.Add(selectedNode.InnerText);
                }
            }
            else
            {
                MessageBox.Show("Track Database is empty!", "Database is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vManager.getModEnvironment() == "gear")
            {
                modListBox.Items.Clear();
                XmlNode rootNode = vManager.getLoadedDatabase().SelectSingleNode("gearDB");
                string selectedMod = (string)comboBox1.SelectedItem;
                foreach (XmlNode selectedNode in rootNode)
                {
                    if (selectedNode.Attributes[0].Value == selectedMod)
                    {
                        modListBox.Items.Add(selectedNode.InnerText);
                    }
                }

            }
            else if (vManager.getModEnvironment() == "track")
            {
                modListBox.Items.Clear();
                XmlNode rootNode = vManager.getLoadedDatabase().SelectSingleNode("trackDB");
                string selectedMod = (string)comboBox1.SelectedItem;
                foreach (XmlNode selectedNode in rootNode)
                {
                    if (selectedNode.Attributes[0].Value == selectedMod)
                    {
                        modListBox.Items.Add(selectedNode.InnerText);
                    }
                }
            }
            else if (vManager.getModEnvironment() == "bike")
            {

            }
        }
        private void deleteModsBtn_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                deleteMod();
            }
            else
            {
                MessageBox.Show("Select a mod to delete", "No mod selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void deleteMod()
        {
            if (vManager.getModEnvironment() == "track")
            {
                //Remove entries from DB and modlist
                string selectedMod = (string)comboBox1.SelectedItem;
                XmlNode rootNode = vManager.getLoadedDatabase().SelectSingleNode("trackDB");
                foreach (XmlNode selectedNode in rootNode) //Remove from disk
                {
                    if (selectedNode.Attributes[0].Value == selectedMod)
                    {
                        //MessageBox.Show("Will delete: " + selectedNode.InnerText);
                        FileAttributes attr = File.GetAttributes(startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText);
                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            //MessageBox.Show("Its a directory");
                            MessageBox.Show("Will delete: " + startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText);
                            Directory.Delete(startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText, true);
                        }
                        else
                        {
                            //MessageBox.Show("Its a file");
                            MessageBox.Show("Will delete: " + startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText);
                            File.Delete(startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText);
                        }
                    }
                }
                foreach (XmlNode selectedNode in rootNode) //Remove from listbox
                {
                    if (selectedNode.Attributes[0].Value == selectedMod)
                    {
                        modListBox.Items.Remove(selectedNode.InnerText);
                    }
                }
                XmlNodeList xlist = rootNode.SelectNodes("mod");
                for (int counter = 0; counter < xlist.Count; counter++) //Remove from Database
                {
                    if (xlist[counter].Attributes[0].Value == selectedMod)
                    {
                        xlist[counter].ParentNode.RemoveChild(xlist[counter]);
                    }
                }
                comboBox1.Items.Remove(selectedMod);
                vManager.getLoadedDatabase().Save("emXS_trackDB.xml");
            }
            else if (vManager.getModEnvironment() == "gear")
            {
                //Remove entries from DB and modlist
                string selectedMod = (string)comboBox1.SelectedItem;
                XmlNode rootNode = vManager.getLoadedDatabase().SelectSingleNode("gearDB");
                foreach (XmlNode selectedNode in rootNode) //Remove from disk
                {
                    if (selectedNode.Attributes[0].Value == selectedMod)
                    {
                        //MessageBox.Show("Will delete: " + selectedNode.InnerText);
                        String fileToDelete = startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText;
                        if (File.Exists(fileToDelete) || Directory.Exists(fileToDelete))
                        {
                            FileAttributes attr = File.GetAttributes(startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText);
                            if (attr.HasFlag(FileAttributes.Directory))
                            {
                                //MessageBox.Show("Its a directory");
                                MessageBox.Show("Will delete: " + startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText);
                                Directory.Delete(startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText, true);
                            }
                            else
                            {
                                //MessageBox.Show("Its a file");
                                MessageBox.Show("Will delete: " + startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText);
                                File.Delete(startupRoutine.getMXSDirectory() + "\\" + selectedNode.InnerText);
                            }
                        }
                        else
                        {
                            MessageBox.Show(fileToDelete + " doesn't exist!");
                        }

                    }
                }
                foreach (XmlNode selectedNode in rootNode) //Remove from listbox
                {
                    if (selectedNode.Attributes[0].Value == selectedMod)
                    {
                        modListBox.Items.Remove(selectedNode.InnerText);
                    }
                }
                XmlNodeList xlist = rootNode.SelectNodes("mod");
                for (int counter = 0; counter < xlist.Count; counter++) //Remove from Database
                {
                    if (xlist[counter].Attributes[0].Value == selectedMod)
                    {
                        xlist[counter].ParentNode.RemoveChild(xlist[counter]);
                    }
                }
                comboBox1.Items.Remove(selectedMod);
                vManager.getLoadedDatabase().Save("emXS_gearDB.xml");
            }
        }
        private void deleteSelectedModsBtn_Click(object sender, EventArgs e)
        {
            deleteSelectedMod();
        }
        private void deleteSelectedMod()
        {
            if(vManager.getModEnvironment() == "gear")
            {
                XmlNode rootNode = vManager.getLoadedDatabase().SelectSingleNode("gearDB");
                String[] checkedItems = new String[modListBox.Items.Count];
                XmlNodeList xList = rootNode.SelectNodes("mod");
                int chkItemCounter = 0;
                foreach(String activeItem in modListBox.CheckedItems) //Populate array
                {
                    checkedItems[chkItemCounter] = activeItem;
                    chkItemCounter++;
                }
                dbManager.removeSelectedModFiles(checkedItems, xList, vManager.getModEnvironment(), vManager.getLoadedDatabase());
                foreach (String activeItem in checkedItems) //Remove from listbox
                {
                    modListBox.Items.Remove(activeItem);
                }
                int i = 0;
                foreach (XmlNode xNode in xList) //Remove from database
                {
                    if(i >= checkedItems.Length)
                    {
                        break;
                    }
                    else
                    {
                        if (xNode.InnerText == checkedItems[i])
                        {
                            xNode.ParentNode.RemoveChild(xNode);
                            i++;
                        }
                        else
                        {
                            continue;
                        }
                        
                    }
                    
                }
                vManager.getLoadedDatabase().Save("emXS_gearDB.xml");
            }
            if (vManager.getModEnvironment() == "track")
            {
                XmlNode rootNode = vManager.getLoadedDatabase().SelectSingleNode("trackDB");

                String[] checkedItems = new String[modListBox.Items.Count];
                XmlNodeList xList = rootNode.SelectNodes("mod");
                int chkItemCounter = 0;
                foreach (String activeItem in modListBox.CheckedItems) //Populate array with checked items
                {
                    checkedItems[chkItemCounter] = activeItem;
                    chkItemCounter++;
                }
                dbManager.removeSelectedModFiles(checkedItems, xList, vManager.getModEnvironment(), vManager.getLoadedDatabase());
                foreach (String activeItem in checkedItems) //Remove from listbox
                {
                    modListBox.Items.Remove(activeItem);
                }
                int i = 0;
                foreach (XmlNode xNode in xList) //Remove from database
                {
                    if (i >= checkedItems.Length)
                    {
                        break;
                    }
                    else
                    {
                        if (xNode.InnerText == checkedItems[i])
                        {
                            xNode.ParentNode.RemoveChild(xNode);
                            i++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                vManager.getLoadedDatabase().Save("emXS_trackDB.xml");
            }
        }
        
    }
}