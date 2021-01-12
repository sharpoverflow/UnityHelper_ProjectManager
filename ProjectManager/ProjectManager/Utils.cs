using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Shell32;
using System.Collections;

namespace ProjectManager
{
    public static class Utils
    {
        public static string JsonSerialize<T>(this T t)
        {
            return JsonConvert.SerializeObject(t , Formatting.Indented);
        }

        public static T JsonDeserialize<T>(this string s)
        {
            return JsonConvert.DeserializeObject<T>(s); ;
        }

        public static byte[] Compress(byte[] bytes)
        {
            using (MemoryStream cms = new MemoryStream())
            {
                using (System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(cms , System.IO.Compression.CompressionMode.Compress))
                {
                    gzip.Write(bytes , 0 , bytes.Length);
                }
                return cms.ToArray();
            }
        }

        public static byte[] Uncompress(byte[] bytes)
        {
            using (MemoryStream dms = new MemoryStream())
            {
                using (MemoryStream cms = new MemoryStream(bytes))
                {
                    using (System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(cms , System.IO.Compression.CompressionMode.Decompress))
                    {
                        byte[] b = new byte[1024];
                        int len = 0;
                        while ((len = gzip.Read(b , 0 , b.Length)) > 0)
                        {
                            dms.Write(b , 0 , len);
                        }
                    }
                }
                return dms.ToArray();
            }
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static string TS08(this int i)
        {
            return i.ToString("00000000");
        }

        public static DirectoryInfo CreatePath(this string path)
        {
            return Directory.CreateDirectory(path);
        }

        public static void SaveString(this string str , string path)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            File.WriteAllBytes(path , data);
        }

        public static string LoadString(this string path)
        {
            if (File.Exists(path))
            {
                byte[] data = File.ReadAllBytes(path);
                return Encoding.UTF8.GetString(data);
            }
            else
            {
                return null;
            }
        }

        public static byte[] ToUTF8Bytes(this string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string FormatPath(this string path)
        {
            return path.Replace("\\" , "/");
        }

        public static bool CheckPath(string path)
        {
            string pattern = @"^[a-zA-Z]:(((\\(?! )[^/:*?<>\""|\\]+)+\\?)|(\\)?)\s*$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(path);
        }

        /// <summary>
        /// 替换字符串字符
        /// </summary>
        /// <param name="s"></param>
        /// <param name="targetStr">替换后的字符串</param>
        /// <param name="charStr">需要被替换的字符串</param>
        /// <returns></returns>
        public static string Replace(this string s , string targetStr , params string[] charStr)
        {
            for (int i = 0 ; i < charStr.Length ; i++)
            {
                s = s.Replace(charStr[i] , targetStr);
            }
            return s;
        }

        public static List<string> GetExplorerSelected()
        {
            List<string> selected = new List<string>();


            foreach (SHDocVw.InternetExplorer window in new SHDocVw.ShellWindows())
            {
                string filename = Path.GetFileNameWithoutExtension(window.FullName).ToLower();
                if (filename.ToLowerInvariant() == "explorer")
                {
                    Shell32.FolderItems items = ((Shell32.IShellFolderViewDual2)window.Document).SelectedItems();
                    foreach (Shell32.FolderItem item in items)
                    {
                        selected.Add(item.Path);
                    }
                }
            }

            return selected;
        }

        public static void OpenDirectoryByExplorer(string path)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = "\"" + path.Replace("/" , "\\") + "\"";
            p.Start();
        }

        public static void OpenFileByExplorer(string path)
        {
            string arg =  "/select,\"" + path.Replace("/" , "\\") + "\"";
            System.Diagnostics.Process.Start("explorer.exe" , arg);
        }
    }
}
