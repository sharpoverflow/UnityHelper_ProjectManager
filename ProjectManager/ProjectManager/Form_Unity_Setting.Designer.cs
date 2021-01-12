namespace ProjectManager
{
    partial class Form_Unity_Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPage_WorkPath = new System.Windows.Forms.TabPage();
            this.ListBox_Work = new System.Windows.Forms.ListBox();
            this.TabPage_UnityPath = new System.Windows.Forms.TabPage();
            this.OpenFileDialog_Unity = new System.Windows.Forms.OpenFileDialog();
            this.Button_Add_Work = new System.Windows.Forms.Button();
            this.Button_Delete_Work = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_Name_Work = new System.Windows.Forms.TextBox();
            this.TextBox_Path_Work = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_Path_Work = new System.Windows.Forms.Button();
            this.Button_Path_Unity = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox_Path_Unity = new System.Windows.Forms.TextBox();
            this.TextBox_Version_Unity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Button_Delete_Unity = new System.Windows.Forms.Button();
            this.Button_Add_Unity = new System.Windows.Forms.Button();
            this.ListBox_Unity = new System.Windows.Forms.ListBox();
            this.TabControl.SuspendLayout();
            this.TabPage_WorkPath.SuspendLayout();
            this.TabPage_UnityPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPage_UnityPath);
            this.TabControl.Controls.Add(this.TabPage_WorkPath);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(566, 212);
            this.TabControl.TabIndex = 0;
            // 
            // TabPage_WorkPath
            // 
            this.TabPage_WorkPath.Controls.Add(this.Button_Path_Work);
            this.TabPage_WorkPath.Controls.Add(this.label2);
            this.TabPage_WorkPath.Controls.Add(this.TextBox_Path_Work);
            this.TabPage_WorkPath.Controls.Add(this.TextBox_Name_Work);
            this.TabPage_WorkPath.Controls.Add(this.label1);
            this.TabPage_WorkPath.Controls.Add(this.Button_Delete_Work);
            this.TabPage_WorkPath.Controls.Add(this.Button_Add_Work);
            this.TabPage_WorkPath.Controls.Add(this.ListBox_Work);
            this.TabPage_WorkPath.Location = new System.Drawing.Point(4, 22);
            this.TabPage_WorkPath.Name = "TabPage_WorkPath";
            this.TabPage_WorkPath.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_WorkPath.Size = new System.Drawing.Size(558, 186);
            this.TabPage_WorkPath.TabIndex = 0;
            this.TabPage_WorkPath.Text = "工作路径";
            this.TabPage_WorkPath.UseVisualStyleBackColor = true;
            // 
            // ListBox_Work
            // 
            this.ListBox_Work.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListBox_Work.FormattingEnabled = true;
            this.ListBox_Work.ItemHeight = 12;
            this.ListBox_Work.Location = new System.Drawing.Point(3, 3);
            this.ListBox_Work.Name = "ListBox_Work";
            this.ListBox_Work.Size = new System.Drawing.Size(552, 124);
            this.ListBox_Work.TabIndex = 0;
            this.ListBox_Work.SelectedIndexChanged += new System.EventHandler(this.ListBox_Work_SelectedIndexChanged);
            // 
            // TabPage_UnityPath
            // 
            this.TabPage_UnityPath.Controls.Add(this.Button_Path_Unity);
            this.TabPage_UnityPath.Controls.Add(this.label3);
            this.TabPage_UnityPath.Controls.Add(this.TextBox_Path_Unity);
            this.TabPage_UnityPath.Controls.Add(this.TextBox_Version_Unity);
            this.TabPage_UnityPath.Controls.Add(this.label4);
            this.TabPage_UnityPath.Controls.Add(this.Button_Delete_Unity);
            this.TabPage_UnityPath.Controls.Add(this.Button_Add_Unity);
            this.TabPage_UnityPath.Controls.Add(this.ListBox_Unity);
            this.TabPage_UnityPath.Location = new System.Drawing.Point(4, 22);
            this.TabPage_UnityPath.Name = "TabPage_UnityPath";
            this.TabPage_UnityPath.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_UnityPath.Size = new System.Drawing.Size(558, 186);
            this.TabPage_UnityPath.TabIndex = 1;
            this.TabPage_UnityPath.Text = "Unity路径";
            this.TabPage_UnityPath.UseVisualStyleBackColor = true;
            // 
            // OpenFileDialog_Unity
            // 
            this.OpenFileDialog_Unity.Filter = "Unity|Unity.exe";
            // 
            // Button_Add_Work
            // 
            this.Button_Add_Work.Location = new System.Drawing.Point(495, 132);
            this.Button_Add_Work.Name = "Button_Add_Work";
            this.Button_Add_Work.Size = new System.Drawing.Size(60, 48);
            this.Button_Add_Work.TabIndex = 1;
            this.Button_Add_Work.Text = "添加";
            this.Button_Add_Work.UseVisualStyleBackColor = true;
            this.Button_Add_Work.Click += new System.EventHandler(this.Button_Add_Work_Click);
            // 
            // Button_Delete_Work
            // 
            this.Button_Delete_Work.Location = new System.Drawing.Point(3, 132);
            this.Button_Delete_Work.Name = "Button_Delete_Work";
            this.Button_Delete_Work.Size = new System.Drawing.Size(60, 48);
            this.Button_Delete_Work.TabIndex = 2;
            this.Button_Delete_Work.Text = "删除";
            this.Button_Delete_Work.UseVisualStyleBackColor = true;
            this.Button_Delete_Work.Click += new System.EventHandler(this.Button_Delete_Work_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "名称";
            // 
            // TextBox_Name_Work
            // 
            this.TextBox_Name_Work.Location = new System.Drawing.Point(104, 132);
            this.TextBox_Name_Work.Name = "TextBox_Name_Work";
            this.TextBox_Name_Work.Size = new System.Drawing.Size(385, 21);
            this.TextBox_Name_Work.TabIndex = 4;
            this.TextBox_Name_Work.TextChanged += new System.EventHandler(this.TextBox_Name_Work_TextChanged);
            // 
            // TextBox_Path_Work
            // 
            this.TextBox_Path_Work.BackColor = System.Drawing.SystemColors.Window;
            this.TextBox_Path_Work.Location = new System.Drawing.Point(104, 158);
            this.TextBox_Path_Work.Name = "TextBox_Path_Work";
            this.TextBox_Path_Work.ReadOnly = true;
            this.TextBox_Path_Work.Size = new System.Drawing.Size(341, 21);
            this.TextBox_Path_Work.TabIndex = 5;
            this.TextBox_Path_Work.TextChanged += new System.EventHandler(this.TextBox_Path_Work_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "路径";
            // 
            // Button_Path_Work
            // 
            this.Button_Path_Work.Location = new System.Drawing.Point(449, 158);
            this.Button_Path_Work.Name = "Button_Path_Work";
            this.Button_Path_Work.Size = new System.Drawing.Size(40, 22);
            this.Button_Path_Work.TabIndex = 7;
            this.Button_Path_Work.Text = "<";
            this.Button_Path_Work.UseVisualStyleBackColor = true;
            this.Button_Path_Work.Click += new System.EventHandler(this.Button_Path_Work_Click);
            // 
            // Button_Path_Unity
            // 
            this.Button_Path_Unity.Location = new System.Drawing.Point(449, 158);
            this.Button_Path_Unity.Name = "Button_Path_Unity";
            this.Button_Path_Unity.Size = new System.Drawing.Size(40, 22);
            this.Button_Path_Unity.TabIndex = 15;
            this.Button_Path_Unity.Text = "<";
            this.Button_Path_Unity.UseVisualStyleBackColor = true;
            this.Button_Path_Unity.Click += new System.EventHandler(this.Button_Path_Unity_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "路径";
            // 
            // TextBox_Path_Unity
            // 
            this.TextBox_Path_Unity.BackColor = System.Drawing.SystemColors.Window;
            this.TextBox_Path_Unity.Location = new System.Drawing.Point(104, 158);
            this.TextBox_Path_Unity.Name = "TextBox_Path_Unity";
            this.TextBox_Path_Unity.ReadOnly = true;
            this.TextBox_Path_Unity.Size = new System.Drawing.Size(341, 21);
            this.TextBox_Path_Unity.TabIndex = 13;
            this.TextBox_Path_Unity.TextChanged += new System.EventHandler(this.TextBox_Path_Unity_TextChanged);
            // 
            // TextBox_Version_Unity
            // 
            this.TextBox_Version_Unity.Location = new System.Drawing.Point(104, 132);
            this.TextBox_Version_Unity.Name = "TextBox_Version_Unity";
            this.TextBox_Version_Unity.Size = new System.Drawing.Size(385, 21);
            this.TextBox_Version_Unity.TabIndex = 12;
            this.TextBox_Version_Unity.TextChanged += new System.EventHandler(this.TextBox_Version_Unity_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "版本";
            // 
            // Button_Delete_Unity
            // 
            this.Button_Delete_Unity.Location = new System.Drawing.Point(3, 132);
            this.Button_Delete_Unity.Name = "Button_Delete_Unity";
            this.Button_Delete_Unity.Size = new System.Drawing.Size(60, 48);
            this.Button_Delete_Unity.TabIndex = 10;
            this.Button_Delete_Unity.Text = "删除";
            this.Button_Delete_Unity.UseVisualStyleBackColor = true;
            this.Button_Delete_Unity.Click += new System.EventHandler(this.Button_Delete_Unity_Click);
            // 
            // Button_Add_Unity
            // 
            this.Button_Add_Unity.Location = new System.Drawing.Point(495, 132);
            this.Button_Add_Unity.Name = "Button_Add_Unity";
            this.Button_Add_Unity.Size = new System.Drawing.Size(60, 48);
            this.Button_Add_Unity.TabIndex = 9;
            this.Button_Add_Unity.Text = "添加";
            this.Button_Add_Unity.UseVisualStyleBackColor = true;
            this.Button_Add_Unity.Click += new System.EventHandler(this.Button_Add_Unity_Click);
            // 
            // ListBox_Unity
            // 
            this.ListBox_Unity.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListBox_Unity.FormattingEnabled = true;
            this.ListBox_Unity.ItemHeight = 12;
            this.ListBox_Unity.Location = new System.Drawing.Point(3, 3);
            this.ListBox_Unity.Name = "ListBox_Unity";
            this.ListBox_Unity.Size = new System.Drawing.Size(552, 124);
            this.ListBox_Unity.TabIndex = 8;
            this.ListBox_Unity.SelectedIndexChanged += new System.EventHandler(this.ListBox_Unity_SelectedIndexChanged);
            // 
            // Form_Unity_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 212);
            this.Controls.Add(this.TabControl);
            this.Name = "Form_Unity_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工程管理 - Unity - 设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Unity_Setting_FormClosing);
            this.Load += new System.EventHandler(this.Form_Unity_Setting_Load);
            this.TabControl.ResumeLayout(false);
            this.TabPage_WorkPath.ResumeLayout(false);
            this.TabPage_WorkPath.PerformLayout();
            this.TabPage_UnityPath.ResumeLayout(false);
            this.TabPage_UnityPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPage_WorkPath;
        private System.Windows.Forms.TabPage TabPage_UnityPath;
        private System.Windows.Forms.ListBox ListBox_Work;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_Unity;
        private System.Windows.Forms.Button Button_Add_Work;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_Path_Work;
        private System.Windows.Forms.TextBox TextBox_Name_Work;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Delete_Work;
        private System.Windows.Forms.Button Button_Path_Work;
        private System.Windows.Forms.Button Button_Path_Unity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox_Path_Unity;
        private System.Windows.Forms.TextBox TextBox_Version_Unity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Button_Delete_Unity;
        private System.Windows.Forms.Button Button_Add_Unity;
        private System.Windows.Forms.ListBox ListBox_Unity;
    }
}