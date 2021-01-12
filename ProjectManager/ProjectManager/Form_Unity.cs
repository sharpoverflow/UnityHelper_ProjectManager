using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager
{
    public partial class Form_Unity : Form
    {
        private Setting.Unity setting;

        private Form_Unity_Setting form_setting = new Form_Unity_Setting();
        private Form_InputBox form_InputBox = new Form_InputBox();
        private ContextMenuStrip ContextMenuStrip_OpenWithVersion = new ContextMenuStrip();
        private ListBox[] ListBoxsInTabpage;

        private List<FileSystemWatcher> fileSystemWatcherPool = new List<FileSystemWatcher>();

        private bool hookState = false;
        private DateTime lastHookTime = DateTime.Now;
        private Queue<Action> hookQueue = new Queue<Action>();
        private Queue<Action> mainThreadQueue = new Queue<Action>();

        public Form_Unity()
        {
            InitializeComponent();
        }

        private void Form_Unity_Load(object sender, EventArgs e)
        {
            ChangeVisibleState();

            ReloadSetting();
            ReloadList();
            ChangeHookState();
            RefreshRecent();
            ReloadVersionMenuList();

            ReloadFileSystemWatcher();
        }

        private void ReloadFileSystemWatcher()
        {
            foreach (var w in fileSystemWatcherPool)
            {
                w.EnableRaisingEvents = false;
                w.Dispose();
            }
            fileSystemWatcherPool.Clear();

            for (int i = 0; i < setting.workPathList.Count; i++)
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = setting.workPathList[i].path;
                watcher.NotifyFilter = NotifyFilters.DirectoryName;
                watcher.Changed += (object source, FileSystemEventArgs e) =>
                {
                    mainThreadQueue.Enqueue(() => ReloadList());
                };
                watcher.Created += (object source, FileSystemEventArgs e) =>
                {
                    mainThreadQueue.Enqueue(() => ReloadList());
                };
                watcher.Deleted += (object source, FileSystemEventArgs e) =>
                {
                    mainThreadQueue.Enqueue(() =>
                    {
                        ReloadList();
                        RefreshRecent();
                    });
                };
                watcher.Renamed += (object source, RenamedEventArgs e) =>
                {
                    mainThreadQueue.Enqueue(() =>
                    {
                        ReloadList();
                        RefreshRecent();
                    });
                };
                watcher.EnableRaisingEvents = true;
                fileSystemWatcherPool.Add(watcher);
            }
        }

        /// <summary>
        /// 更改按键钩子状态
        /// </summary>
        private void ChangeHookState()
        {
            hookState = !hookState;
            if (hookState)
            {
                Hook.HookRestart(HookListener);
            }
        }

        /// <summary>
        /// 按键钩子
        /// </summary>
        /// <param name="key"></param>
        /// <param name="kbhs"></param>
        private void HookListener(Keys key, Hook.KeyBoardHookStruct kbhs)
        {
            hookQueue.Enqueue(() =>
            {
                if ((DateTime.Now - lastHookTime).Seconds < 2)
                {
                    return;
                }
                if (key == Keys.F9)
                {
                    lastHookTime = DateTime.Now;
                    DetectSelectFolderAndOpenUnityProject();
                }
                //if (key == Keys.F8)
                //{
                //    MessageBox.Show(Visible + "");
                //}
            });
        }

        /// <summary>
        /// 检测 系统-资源管理器 所选择的文件夹(不包括桌面) ,判断是否为Unity工程文件夹,并打开
        /// </summary>
        private void DetectSelectFolderAndOpenUnityProject()
        {
            List<string> list = Utils.GetExplorerSelected();
            for (int i = 0; i < list.Count; i++)
            {
                string assetsPath = list[i] + "/Assets";
                if (Directory.Exists(assetsPath))
                {
                    string version = GetUnityProjectVersion(list[i]);
                    if (!MatchVersionAndOpenUnityProject(version, list[i]))
                    {
                        Show();
                        Label_Name.Name = list[i];
                        Button_OpenWithVersion_Click(null, null);
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// 重载设置文件
        /// </summary>
        private void ReloadSetting()
        {
            Setting.Instance.unitySetting = Setting.Instance.unitySetting.LoadSetting();
            setting = Setting.Instance.unitySetting;
        }

        /// <summary>
        /// 重新加载所有工程列表
        /// </summary>
        private void ReloadList()
        {
            TabControl_ProjectGroup.TabPages.Clear();
            ListBoxsInTabpage = new ListBox[setting.workPathList.Count];
            for (int i = 0; i < setting.workPathList.Count; i++)
            {
                var workPath = setting.workPathList[i];
                TabPage tp = new TabPage() { Text = workPath.name };
                TabControl_ProjectGroup.TabPages.Add(tp);
                ListBox lb = new ListBox { Parent = tp, Dock = DockStyle.Fill };
                lb.SelectedIndexChanged += (sender, e) => ShowProject(workPath, lb);
                ListBoxsInTabpage[i] = lb;
                if (!Utils.CheckPath(workPath.path))
                {
                    try
                    {
                        string[] dirs = Directory.GetDirectories(workPath.path);
                        for (int t = 0; t < dirs.Length; t++)
                        {
                            lb.Items.Add(Path.GetFileName(dirs[t]));
                        }
                    }
                    catch
                    {
                        Form_Log.Instance.LogError(workPath.name + "  路径设置错误");
                    }
                }
                if (lb.Items.Count > 0) lb.SelectedIndex = 0;
            }
            if (TabControl_ProjectGroup.TabPages.Count > 1)
            {
                TabControl_ProjectGroup.SelectedIndex = 1;
                TabControl_ProjectGroup.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 展示所选项目信息
        /// </summary>
        /// <param name="workPath"></param>
        /// <param name="lb"></param>
        private void ShowProject(Setting.Unity.WorkPath workPath, ListBox lb)
        {
            if (lb.SelectedIndex < 0) return;

            Label_Name.Text = "名称: " + lb.SelectedItem.ToString();

            string projectPath = workPath.path + "/" + lb.SelectedItem;

            string assetsPath = projectPath + "/Assets";
            Label_Name.Name = projectPath;
            GroupBox_Unity.Visible = Directory.Exists(assetsPath);

            if (TabControl_ProjectGroup.SelectedTab != null)
            {
                GroupBox_Unity.Text = "选择项目-" + TabControl_ProjectGroup.SelectedTab.Text + "-" + projectPath;
            }

            string version = GetUnityProjectVersion(workPath.path + "/" + lb.SelectedItem);
            Label_Version.Text = "版本: " + version;
            Label_Version.Name = version;
        }

        /// <summary>
        /// 获取所选工程的Unity版本
        /// </summary>
        /// <param name="projectPath"></param>
        /// <returns></returns>
        private string GetUnityProjectVersion(string projectPath)
        {
            try
            {
                string path = projectPath + "/ProjectSettings/ProjectVersion.txt";
                string version = File.ReadAllText(path);
                int xn = version.IndexOf("\n", 17);
                version = version.Substring(17, xn - 17);
                version = version.Replace("", "\r", "\n", " ");
                return version;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 打开设置对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!form_setting.Visible)
            {
                form_setting.ShowDialog();
                ReloadByChangedSetting();
            }
        }

        /// <summary>
        /// 由更改设置重新加载相应界面及数据
        /// </summary>
        private void ReloadByChangedSetting()
        {
            ReloadList();
            ReloadVersionMenuList();
            ReloadFileSystemWatcher();
        }

        /// <summary>
        /// 重新生成右下角菜单中 新建 项中的版本列表
        /// </summary>
        private void ReloadVersionMenuList()
        {

            MenuCreateNewProjectToolStripMenuItem.DropDown.Items.Clear();
            for (int i = 0; i < setting.workPathList.Count; i++)
            {
                var workPath = setting.workPathList[i];
                MenuCreateNewProjectToolStripMenuItem.DropDown.Items.Add(workPath.name);
                for (int t = 0; t < setting.unityPathList.Count; t++)
                {
                    int k = t;
                    (MenuCreateNewProjectToolStripMenuItem.DropDown.Items[i] as ToolStripDropDownItem).DropDown.Items.Add(setting.unityPathList[t].version);
                    (MenuCreateNewProjectToolStripMenuItem.DropDown.Items[i] as ToolStripDropDownItem).DropDown.Items[t].Click += (sender, e) =>
                    {

                        form_InputBox.Init($"在 {workPath.name} 中创建新工程,请输入工程名称");
                        form_InputBox.OnInputTextChanged = (str, lab) =>
                        {
                            form_InputBox.SetAvailable(true);
                            string path = workPath.path + "/" + str;
                            lab.Text = "符合";
                            if (str == "")
                            {
                                lab.Text = "文件名为空";
                                form_InputBox.SetAvailable(false);
                            }
                            else
                            {
                                if (Directory.Exists(path))
                                {
                                    lab.Text = "工程已存在";
                                    form_InputBox.SetAvailable(false);
                                }
                            }
                        };

                        if (form_InputBox.ShowDialog() == DialogResult.OK)
                        {
                            string projectName = form_InputBox.Result;
                            string path = workPath.path + "/" + projectName;
                            try
                            {
                                DirectoryInfo di = (path + "/Assets").CreatePath();
                                OpenUnity(setting.unityPathList[k].path, path);
                            }
                            catch (Exception ex)
                            {

                            }
                        }


                    };
                }
            }


        }

        /// <summary>
        /// 工程目录选项卡切换后,刷新包含列表的所选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_ProjectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl_ProjectGroup.SelectedTab != null)
            {
                if (ListBoxsInTabpage[TabControl_ProjectGroup.SelectedIndex].Items.Count == 0)
                {
                    GroupBox_Unity.Visible = false;
                }
                else
                {
                    int index = ListBoxsInTabpage[TabControl_ProjectGroup.SelectedIndex].SelectedIndex;
                    ListBoxsInTabpage[TabControl_ProjectGroup.SelectedIndex].SelectedIndex = -1;
                    ListBoxsInTabpage[TabControl_ProjectGroup.SelectedIndex].SelectedIndex = 0;
                    if (index != -1)
                    {
                        ListBoxsInTabpage[TabControl_ProjectGroup.SelectedIndex].SelectedIndex = index;
                    }
                }
            }
        }

        /// <summary>
        /// 打开所选择的Unity工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Open_Click(object sender, EventArgs e)
        {
            if (!MatchVersionAndOpenUnityProject(Label_Version.Name, Label_Name.Name))
            {
                Button_OpenWithVersion_Click(null, null);
            }
        }

        /// <summary>
        /// 检测工程的Unity版本,并且打开
        /// </summary>
        /// <param name="version"></param>
        /// <param name="projectPath"></param>
        /// <returns></returns>
        private bool MatchVersionAndOpenUnityProject(string version, string projectPath)
        {
            for (int i = 0; i < setting.unityPathList.Count; i++)
            {
                if (version == setting.unityPathList[i].version)
                {
                    OpenUnity(setting.unityPathList[i].path, projectPath);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 弹出 用指定Unity版本打开 的菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OpenWithVersion_Click(object sender, EventArgs e)
        {
            OpenWithVersion(Label_Name.Name);
        }

        private void OpenWithVersion(string path)
        {
            ContextMenuStrip_OpenWithVersion.Items.Clear();

            for (int i = 0; i < setting.unityPathList.Count; i++)
            {
                ContextMenuStrip_OpenWithVersion.Items.Add(setting.unityPathList[i].version);
                string unityPath = setting.unityPathList[i].path;

                ContextMenuStrip_OpenWithVersion.Items[i].Click += (sender1, e1) =>
                {
                    OpenUnity(unityPath, path);
                };
            }
            ContextMenuStrip_OpenWithVersion.Show(Button_OpenWithVersion, Button_OpenWithVersion.Size.Width, 0);
        }

        /// <summary>
        /// 打开Unity工程
        /// </summary>
        /// <param name="path">Unity程序的Path</param>
        /// <param name="projectPath">工程文件的Path</param>
        private void OpenUnity(string path, string projectPath)
        {
            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.Arguments = "-projectPath " + "\"" + projectPath + "\"";
            p.Start();
            ShowInTaskbar = false;
            Hide();

            AddRecent(projectPath);
            RefreshRecent();
        }

        /// <summary>
        /// 添加到最近打开的项目
        /// </summary>
        /// <param name="projectPath"></param>
        private void AddRecent(string projectPath)
        {
            projectPath = projectPath.Replace(@"\", "/");
            while (setting.recentPathList.Count > 20)
            {
                setting.recentPathList.RemoveAt(0);
            }
            setting.recentPathList.RemoveAll(s => s == projectPath);
            setting.recentPathList.Add(projectPath);
            setting.SaveSetting();
        }

        /// <summary>
        /// 右下角图标双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_Unity_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeVisibleState();
        }

        /// <summary>
        /// 改变主窗体状态
        /// </summary>
        private void ChangeVisibleState()
        {
            Visible = !Visible;
            ShowInTaskbar = Visible;
        }

        /// <summary>
        /// 更改主窗体关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Unity_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChangeVisibleState();
            e.Cancel = true;
        }

        //string deskselect = "";
        //private void button1_Click(object sender , EventArgs e)
        //{
        //    //Shell32.Shell shell = new Shell32.Shell();
        //    //shell.WindowSwitcher();
        //    ShellItems si = new ShellItems();

        //    int index = si.GetSelectedItemIndex();
        //    string text = si.GetItemText(index) + "  ";
        //    text += si.GetItemText(index , 1) + "  ";
        //    text += si.GetItemText(index , 2) + "  ";
        //    text += si.GetItemText(index , 3) + "  ";
        //    text += si.GetItemText(index , 4) + "  ";
        //    text += si.GetItemText(index , 5) + "  ";
        //    text += si.GetItemText(index , 6) + "  ";

        //    deskselect = index + " " + text.Length + "  --  :" + text;
        //}

        /// <summary>
        /// 主线程队列处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Hook_Tick(object sender, EventArgs e)
        {
            //钩子事件队列处理
            while (hookQueue.Count > 0)
            {
                Action act = hookQueue.Dequeue();
                act?.Invoke();
            }
            //主线程事件队列
            while (mainThreadQueue.Count > 0)
            {
                Action act = mainThreadQueue.Dequeue();
                act?.Invoke();
            }
        }

        /// <summary>
        /// 打开选中项目的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OpenFolder_Click(object sender, EventArgs e)
        {
            Utils.OpenDirectoryByExplorer(Label_Name.Name);
        }

        /// <summary>
        /// 刷新最近打开项目列表
        /// </summary>
        private void RefreshRecent()
        {
            MenuRecentToolStripMenuItem.DropDown.Items.Clear();
            for (int i = 0; i < setting.recentPathList.Count; i++)
            {

                string fullPath = setting.recentPathList[i];
                string name = Path.GetFileName(fullPath);
                string path = fullPath.Replace("/" + name, "");

                if (!Directory.Exists(fullPath))
                {
                    setting.recentPathList.RemoveAt(i);
                    i--;
                    continue;
                }

                var finded = setting.workPathList.Find(m => m.path == path);
                string showName;
                if (finded != null)
                {
                    showName = finded.name + " -- " + name;
                }
                else
                {
                    showName = fullPath;
                }
                MenuRecentToolStripMenuItem.DropDown.Items.Add(showName);
                MenuRecentToolStripMenuItem.DropDown.Items[i].Click += (sender, e) =>
                {

                    string version = GetUnityProjectVersion(fullPath);
                    if (!MatchVersionAndOpenUnityProject(version, fullPath))
                    {
                        Show();
                        Label_Name.Name = fullPath;
                        Button_OpenWithVersion_Click(null, null);
                    }

                };

            }
        }

        /// <summary>
        /// 直接在Load事件中调用visible会产生2次false的bug,加此方法解决
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Unity_Shown(object sender, EventArgs e)
        {
            ChangeVisibleState();
        }
    }
}
