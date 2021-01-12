using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager
{
    public partial class Form_Unity_Setting : Form
    {
        private Setting.Unity setting;

        private Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog FolderSelectorDialog_Work = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();

        public Form_Unity_Setting()
        {
            InitializeComponent();

        }

        private Setting.Unity.UnityPath nowSelectUnityPath = null;

        private Setting.Unity.WorkPath nowSelectWorkPath = null;

        private void Form_Unity_Setting_Load(object sender , EventArgs e)
        {
            setting = Setting.Instance.unitySetting;

            FolderSelectorDialog_Work.IsFolderPicker = true;
            FolderSelectorDialog_Work.Title = "选择工作路径";

            ListBox_Unity.Items.Clear();
            for (int i = 0 ; i < setting.unityPathList.Count ; i++)
            {
                ListBox_Unity.Items.Add(setting.unityPathList[i]);
            }

            ListBox_Work.Items.Clear();
            for (int i = 0 ; i < setting.workPathList.Count ; i++)
            {
                ListBox_Work.Items.Add(setting.workPathList[i]);
            }

            if (ListBox_Unity.Items.Count > 0) ListBox_Unity.SelectedIndex = 0;
            if (ListBox_Work.Items.Count > 0) ListBox_Work.SelectedIndex = 0;

        }

        private void Form_Unity_Setting_FormClosing(object sender , FormClosingEventArgs e)
        {
            setting.SaveSetting();
        }

        private void ListRemove<T>(ListBox lb , List<T> list)
        {
            int index = lb.SelectedIndex;
            if (index < 0 || index >= lb.Items.Count) return;

            T up = (T)lb.Items[index];
            list.Remove(up);
            lb.Items.RemoveAt(index);

            index -= 1;
            if (index >= 0)
            {
                lb.SelectedIndex = index;
            }
        }



        private void Button_Add_Unity_Click(object sender , EventArgs e)
        {
            var up = new Setting.Unity.UnityPath { version = "未命名版本" , path = "未设置路径" };
            setting.unityPathList.Add(up);
            ListBox_Unity.Items.Add(up);
        }

        private void Button_Delete_Unity_Click(object sender , EventArgs e)
        {
            ListRemove(ListBox_Unity , setting.unityPathList);
        }

        private void ListBox_Unity_SelectedIndexChanged(object sender , EventArgs e)
        {
            int index = ListBox_Unity.SelectedIndex;
            if (index < 0 || index >= ListBox_Unity.Items.Count)
            {
                nowSelectUnityPath = null;
                return;
            }
            nowSelectUnityPath = ListBox_Unity.Items[index] as Setting.Unity.UnityPath;

            TextBox_Version_Unity.Text = nowSelectUnityPath.version;
            TextBox_Path_Unity.Text = nowSelectUnityPath.path;
        }

        private void TextBox_Version_Unity_TextChanged(object sender , EventArgs e)
        {
            if (nowSelectUnityPath == null) return;
            nowSelectUnityPath.version = TextBox_Version_Unity.Text;
            ListBox_Unity.Items[ListBox_Unity.SelectedIndex] = nowSelectUnityPath;
        }

        private void TextBox_Path_Unity_TextChanged(object sender , EventArgs e)
        {
            if (nowSelectUnityPath == null) return;
            nowSelectUnityPath.path = TextBox_Path_Unity.Text;
            ListBox_Unity.Items[ListBox_Unity.SelectedIndex] = nowSelectUnityPath;
        }

        private void Button_Path_Unity_Click(object sender , EventArgs e)
        {
            if (OpenFileDialog_Unity.ShowDialog() == DialogResult.OK)
            {
                TextBox_Path_Unity.Text = OpenFileDialog_Unity.FileName.FormatPath();
            }
        }



        private void Button_Add_Work_Click(object sender , EventArgs e)
        {
            var up = new Setting.Unity.WorkPath { name = "未命名" , path = "未设置路径" };
            setting.workPathList.Add(up);
            ListBox_Work.Items.Add(up);
        }

        private void Button_Delete_Work_Click(object sender , EventArgs e)
        {
            ListRemove(ListBox_Work , setting.workPathList);
        }

        private void TextBox_Name_Work_TextChanged(object sender , EventArgs e)
        {
            if (nowSelectWorkPath == null) return;
            nowSelectWorkPath.name = TextBox_Name_Work.Text;
            ListBox_Work.Items[ListBox_Work.SelectedIndex] = nowSelectWorkPath;
        }

        private void TextBox_Path_Work_TextChanged(object sender , EventArgs e)
        {
            if (nowSelectWorkPath == null) return;
            nowSelectWorkPath.path = TextBox_Path_Work.Text;
            ListBox_Work.Items[ListBox_Work.SelectedIndex] = nowSelectWorkPath;
        }

        private void Button_Path_Work_Click(object sender , EventArgs e)
        {
            if(FolderSelectorDialog_Work.ShowDialog(this.Handle) == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                TextBox_Path_Work.Text = FolderSelectorDialog_Work.FileName.FormatPath();
            }
        }

        private void ListBox_Work_SelectedIndexChanged(object sender , EventArgs e)
        {
            int index = ListBox_Work.SelectedIndex;
            if (index < 0 || index >= ListBox_Work.Items.Count)
            {
                nowSelectWorkPath = null;
                return;
            }
            nowSelectWorkPath = ListBox_Work.Items[index] as Setting.Unity.WorkPath;

            TextBox_Name_Work.Text = nowSelectWorkPath.name;
            TextBox_Path_Work.Text = nowSelectWorkPath.path;
        }
    }
}
