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
    public partial class Form_Log : Form
    {
        private static Form_Log instance;
        public static Form_Log Instance
        {
            get
            {
                return instance ?? (instance = new Form_Log());
            }
        }

        public Form_Log()
        {
            InitializeComponent();
        }

        private void Form_Log_FormClosing(object sender , FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void Log(string text)
        {
            ListBox_Log.Items.Insert(0 , DateTime.Now.ToLongTimeString() + "  -- " + text);
        }

        public void LogError(string text)
        {
            Log(text);
            if (!Visible) Show();
        }
    }
}
