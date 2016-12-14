using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MX_Simulator_Mod_Manager
{
    class DatabaseManager
    {
        //Object initialization

        Startup startupRoutine = new Startup();

        public void updateTrackDatabaseSaf(string mod)
        {
            string modName = Path.GetFileNameWithoutExtension(mod);
            string modNameWithoutExtension = Path.GetFileName(mod);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("emXS_trackDB.xml");
            XmlNode rootElement = xDoc.SelectSingleNode("trackDB"); //Select root element
            XmlElement newMod = xDoc.CreateElement("mod"); //Create another element / mod entry
            XmlAttribute modNameAttribute = xDoc.CreateAttribute("name"); //Create attribute for mod name
            modNameAttribute.Value = modName; //Set attribute to mod name
            rootElement.AppendChild(newMod); //Write mod entry to file
            newMod.Attributes.Append(modNameAttribute); //Write attribute to mod entry
            newMod.InnerText = modNameWithoutExtension; //Write mod contents to mod entry
            xDoc.Save("emXS_trackDB.xml");
        }
        public void updateGearpackDatabaseSaf(string mod)
        {
            string modName = Path.GetFileNameWithoutExtension(mod);
            string modNameWithoutExtension = Path.GetFileName(mod);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("emXS_gearDB.xml");
            XmlNode rootElement = xDoc.SelectSingleNode("gearDB"); //Select root element
            XmlElement newMod = xDoc.CreateElement("mod"); //Create another element / mod entry
            XmlAttribute modNameAttribute = xDoc.CreateAttribute("name"); //Create attribute for mod name
            modNameAttribute.Value = modName; //Set attribute to mod name
            rootElement.AppendChild(newMod); //Write mod entry to file
            newMod.Attributes.Append(modNameAttribute); //Write attribute to mod entry
            newMod.InnerText = modNameWithoutExtension; //Write mod contents to mod entry
            xDoc.Save("emXS_gearDB.xml");
        }
        public void updateTrackDatabaseZip(Ionic.Zip.ZipEntry e, string mod, bool isDirectory)
        {
            if (isDirectory)
            {

            }
            string modName = Path.GetFileNameWithoutExtension(mod);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("emXS_trackDB.xml");
            XmlNode rootElement = xDoc.SelectSingleNode("trackDB"); //Select root element
            XmlElement newMod = xDoc.CreateElement("mod"); //Create another element / mod entry
            XmlAttribute modNameAttribute = xDoc.CreateAttribute("name"); //Create attribute for mod name
            modNameAttribute.Value = modName; //Set attribute to mod name
            rootElement.AppendChild(newMod); //Write mod entry to file
            newMod.Attributes.Append(modNameAttribute); //Write attribute to mod entry
            newMod.InnerText = e.FileName; //Write mod contents to mod entry
            xDoc.Save("emXS_trackDB.xml");
        }
        public void updateGearpackDatabaseZip(Ionic.Zip.ZipEntry e, string mod)
        {
            string modName = Path.GetFileNameWithoutExtension(mod);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("emXS_gearDB.xml");
            XmlNode rootElement = xDoc.SelectSingleNode("gearDB"); //Select root element
            XmlElement newMod = xDoc.CreateElement("mod"); //Create another element / mod entry
            XmlAttribute modNameAttribute = xDoc.CreateAttribute("name"); //Create attribute for mod name
            modNameAttribute.Value = modName; //Set attribute to mod name
            rootElement.AppendChild(newMod); //Write mod entry to file
            newMod.Attributes.Append(modNameAttribute); //Write attribute to mod entry
            newMod.InnerText = e.FileName; //Write mod contents to mod entry
            xDoc.Save("emXS_gearDB.xml");
        }
        public void updateTrackDatabaseRar(RarArchiveEntry e, string mod)
        {
            
            string modName = Path.GetFileNameWithoutExtension(mod);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("emXS_trackDB.xml");
            XmlNode rootElement = xDoc.SelectSingleNode("trackDB"); //Select root element
            XmlElement newMod = xDoc.CreateElement("mod"); //Create another element / mod entry
            XmlAttribute modNameAttribute = xDoc.CreateAttribute("name"); //Create attribute for mod name
            modNameAttribute.Value = modName; //Set attribute to mod name
            rootElement.AppendChild(newMod); //Write mod entry to file
            newMod.Attributes.Append(modNameAttribute); //Write attribute to mod entry
            newMod.InnerText = e.FilePath; //Write mod contents to mod entry
            xDoc.Save("emXS_trackDB.xml");
        }

        public void checkDatabases()
        {
            if (startupRoutine.gearDBExist())
            {
                //Do nothing
            }
            else
            {
                MessageBox.Show("Gear DB doesn't exist, creating one now...");
                createGearpackDatabase();
            }
            if (startupRoutine.trackDBExist())
            {
                //Do nothing
            }
            else
            {
                MessageBox.Show("Track DB doesn't exist, creating one now...");
                createTrackDatabase();
            }
        }

        private void createGearpackDatabase()
        {
            File.Create("emXS_gearDB.xml").Close();
            XmlDocument xDoc = new XmlDocument();
            XmlElement rootElement = xDoc.CreateElement("gearDB");
            xDoc.AppendChild(rootElement);
            xDoc.Save("emXS_gearDB.xml");
        }
        private void createTrackDatabase()
        {
            File.Create("emXS_trackDB.xml").Close();
            XmlDocument xDoc = new XmlDocument();
            XmlElement rootElement = xDoc.CreateElement("trackDB");
            xDoc.AppendChild(rootElement);
            xDoc.Save("emXS_trackDB.xml");
        }

        public bool CheckTrackDatabase(string mod)
        {
            string modName = Path.GetFileNameWithoutExtension(mod);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("emXS_trackDB.xml");
            XmlNodeList xnList = xDoc.SelectNodes("/trackDB/mod[@name]");
            foreach (XmlNode xn in xnList)
            {
                XmlNode selectedNode = xn.Attributes["name"];
                //MessageBox.Show(selectedNode.Value);

                if (selectedNode.Value != modName)
                {
                    //MessageBox.Show("RETURNS TRUE SCOPE");
                    //MessageBox.Show("Node value: " + selectedNode.Value + " | ModName: " + modName);
                    continue;
                }
                else
                {
                    //MessageBox.Show("RETURNS FALSE SCOPE");
                    //MessageBox.Show("Node value: " + selectedNode.Value + " | ModName: " + modName);
                    return false;
                }

            }
            //MessageBox.Show("Returns global");
            return true;

        }
        public bool CheckGearpackDatabase(string mod)
        {
            string modName = Path.GetFileNameWithoutExtension(mod);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("emXS_gearDB.xml");
            XmlNodeList xnList = xDoc.SelectNodes("/gearDB/mod[@name]");
            foreach (XmlNode xn in xnList)
            {
                XmlNode selectedNode = xn.Attributes["name"];
                //MessageBox.Show(selectedNode.Value);

                if (selectedNode.Value != modName)
                {
                    //MessageBox.Show("RETURNS TRUE SCOPE");
                    //MessageBox.Show("Node value: " + selectedNode.Value + " | ModName: " + modName);
                    continue;
                }
                else
                {
                    //MessageBox.Show("RETURNS FALSE SCOPE");
                    //MessageBox.Show("Node value: " + selectedNode.Value + " | ModName: " + modName);
                    return false;
                }

            }
            //MessageBox.Show("Returns global");
            return true;

        }
        
        public void ExtractZipToDirectory(string zipFileName, string outputDirectory)
        {
            ZipFile zip = ZipFile.Read(zipFileName);
            Directory.CreateDirectory(outputDirectory);
            zip.ExtractAll(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
        }

        public void installZipMod(string zipModToInstall)
        {
            ExtractZipToDirectory(zipModToInstall, startupRoutine.getMXSDirectory());
        }
        public void installSafMod(string modTBoxText, string activeModWithoutPth)
        {
            File.Move(modTBoxText, startupRoutine.getMXSDirectory() + "\\" + activeModWithoutPth);
        }
        public void installRarMod(string rarModToInstall)
        {
            
        }

        public void removeSelectedModFiles(String[] checkedItems, XmlNodeList xList, string modEnviron, XmlDocument loadedDB)
        {      
            if (modEnviron == "gear")
            {
                int i = 0;
                XmlNode rootNode = loadedDB.SelectSingleNode("mod");
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
                            FileAttributes attr = File.GetAttributes(startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText);
                            if (attr.HasFlag(FileAttributes.Directory))
                            {
                                //MessageBox.Show("Its a directory");
                                MessageBox.Show("Will delete: " + startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText);
                                Directory.Delete(startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText, true);
                            }
                            else
                            {
                                //MessageBox.Show("Its a file");
                                MessageBox.Show("Will delete: " + startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText);
                                File.Delete(startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText);
                            }
                            i++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else if (modEnviron == "track")
            {
                int i = 0;
                XmlNode rootNode = loadedDB.SelectSingleNode("mod");
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
                            FileAttributes attr = File.GetAttributes(startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText);
                            if (attr.HasFlag(FileAttributes.Directory))
                            {
                                //MessageBox.Show("Its a directory");
                                MessageBox.Show("Will delete: " + startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText);
                                Directory.Delete(startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText, true);
                            }
                            else
                            {
                                //MessageBox.Show("Its a file");
                                MessageBox.Show("Will delete: " + startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText);
                                File.Delete(startupRoutine.getMXSDirectory() + "\\" + xNode.InnerText);
                            }
                            i++;
                        }
                        else
                        {
                            continue;
                        }

                    }

                }
            }
        }
    }
}
