using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    public class Setting
    {
        public interface ISetting
        {
            string JsonPath
            {
                get;
            }
        }

        #region UnitySetting

        public class Unity : ISetting
        {
            public class UnityPath
            {
                public string version;
                public string path;
                public override string ToString()
                {
                    return version + "  --  " + path;
                }
            }
            public class WorkPath
            {
                public string name;
                public string path;
                public override string ToString()
                {
                    return name + "  --  " + path;
                }
            }
            public class Project
            {
                public string name;
                public string info;
                public string imageFile;
            }

            public List<WorkPath> workPathList = new List<WorkPath>();
            public List<UnityPath> unityPathList = new List<UnityPath>();
            public List<Project> projectList = new List<Project>();
            public List<string> recentPathList = new List<string>();

            [JsonIgnore]
            public string JsonPath => AppValue.JsonFile_Unity_Setting;
        }

        #endregion

        private static Setting instance;
        public static Setting Instance
        {
            get
            {
                return instance ?? (instance = new Setting());
            }
        }

        public Unity unitySetting = new Unity();

    }
    public static class SettingEX
    {
        public static bool SaveSetting<T>(this T t) where T : Setting.ISetting
        {
            string json = t.JsonSerialize();
            if (string.IsNullOrEmpty(json))
            {
                return false;
            }
            else
            {
                json.SaveString(t.JsonPath);
                return true;
            }
        }
        public static T LoadSetting<T>(this T t) where T : Setting.ISetting, new()
        {
            string json = t.JsonPath.LoadString();
            if (json == null)
            {
                return new T();
            }
            else
            {
                T result = json.JsonDeserialize<T>();
                return result;
            }
        }
    }

}
