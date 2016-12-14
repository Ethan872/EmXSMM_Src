using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MX_Simulator_Mod_Manager
{
    class VariableManager
    {
        public XmlDocument loadedDatabase;
        public string activeModExtension = "";
        public string activeModWithoutPath = "";
        public string activeMod = "";
        public string modEnvironment = "";
        public bool installScreenActive = true;

        public void newXmlDocument()
        {
            loadedDatabase = new XmlDocument();
        }
        public XmlDocument getLoadedDatabase()
        {
            return loadedDatabase;
        }
        public string getActiveModExtension()
        {
            return activeModExtension;
        }
        public string getActiveModWithoutPath()
        {
            return activeModWithoutPath;
        }
        public string getActiveMod()
        {
            return activeMod;
        }
        public string getModEnvironment()
        {
            return modEnvironment;
        }
        public bool isInstallScreenActive()
        {
            return installScreenActive;
        }
        public void setActiveModExtension(string activeModExten)
        {
            activeModExtension = activeModExten;
        }
        public void setActiveModWithoutPath(string activeModWithoutPathh)
        {
            activeModWithoutPath = activeModWithoutPathh;
        }
        public void setActiveMod(string activeModToSet)
        {
            activeMod = activeModToSet;
        }
        public void setModEnvironment(string modEnvironmentToSet)
        {
            modEnvironment = modEnvironmentToSet;
        }
        public void setInstallScreenActive(bool trueOrFalse)
        {
            installScreenActive = trueOrFalse;
        }
    }
}
