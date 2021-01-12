using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    public class AppValue
    {
        public static readonly string JsonFile_Main_Setting = Environment.CurrentDirectory + "/MainSetting.json";
        public static readonly string JsonFile_Unity_Setting = Environment.CurrentDirectory + "/UnitySetting.json";
        public static readonly string Path_BinData = Environment.CurrentDirectory + "/BinData/";
        static AppValue()
        {
            Utils.CreatePath(Path_BinData);
        }

    }
}
