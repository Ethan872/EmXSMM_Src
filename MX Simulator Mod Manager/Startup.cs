using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX_Simulator_Mod_Manager
{
    class Startup
    {

        public bool settingsExist()
        {
            string settingFileName = "emxsmm.txt";
            if(File.Exists(settingFileName))
            {
                return true;
            } else
            {
                return false;
            }
        }
        public bool trackDBExist()
        {
            string trackDBfileName = "emXS_trackDB.xml";
            if(File.Exists(trackDBfileName))
            {
                return true;
            } else
            {
                return false;
            }
        }
        public bool bikeDBExist()
        {
            string bikeDBfileName = "emXS_bikeDB.xml";
            if(File.Exists(bikeDBfileName))
            {
                return true;
            } else
            {
                return false;
            }
        }
        public bool gearDBExist()
        {
            string gearDBfileName = "emXS_gearDB.xml";
            if(File.Exists(gearDBfileName))
            {
                return true;
            } else
            {
                return false;
            }
        }
        public string getMXSDirectory()
        {
            string settingFileName = "emxsmm.txt";
            if (File.Exists(settingFileName))
            {
                string mxsDirectory = File.ReadAllText(settingFileName, Encoding.UTF8);
                return mxsDirectory;
            }
            else
            {
                return "MX Simulator Directory";
            }
        }

    }
}
