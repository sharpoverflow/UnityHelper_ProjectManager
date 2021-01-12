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
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender , EventArgs e)
        {
            this.Hide();
            ShowInTaskbar = false;

            new Form_Unity().Show();
        }

        private void MenuCloseToolStripMenuItem_Click(object sender , EventArgs e)
        {
            Close();
        }

        private void MenuShowToolStripMenuItem_Click(object sender , EventArgs e)
        {
            Hide();
        }




    }
}
