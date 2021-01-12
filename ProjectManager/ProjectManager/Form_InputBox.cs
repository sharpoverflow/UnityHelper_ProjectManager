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
    public partial class Form_InputBox : Form
    {
        public Form_InputBox()
        {
            InitializeComponent();
        }

        public string Result
        {
            get
            {
                return Text_Input.Text;
            }
        }

        public Action<string , Label> OnInputTextChanged;

        public void Init(string title = "" , string message = "")
        {
            if (title == "") Text = "键入文本";
            else Text = title;
            Text_Input.Text = message;
            Text = title;
            if (message == "") Btn_Confirm.Enabled = false;
        }

        private void Btn_Confirm_Click(object sender , EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        public void SetAvailable(bool b)
        {
            Btn_Confirm.Enabled = b;
        }

        private void Text_Input_TextChanged(object sender , EventArgs e)
        {
            OnInputTextChanged?.Invoke(Text_Input.Text , Label_StateShow);
        }

    }
}
