namespace ProjectManager
{
    partial class Form_Unity
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Unity));
            this.NotifyIcon_Unity = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip_Unity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHookStateChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuCreateNewProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDragBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl_ProjectGroup = new System.Windows.Forms.TabControl();
            this.Label_Version = new System.Windows.Forms.Label();
            this.GroupBox_Unity = new System.Windows.Forms.GroupBox();
            this.Button_OpenFolder = new System.Windows.Forms.Button();
            this.Button_OpenWithVersion = new System.Windows.Forms.Button();
            this.Button_Open = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label_Info = new System.Windows.Forms.Label();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Timer_Hook = new System.Windows.Forms.Timer(this.components);
            this.ContextMenuStrip_Unity.SuspendLayout();
            this.GroupBox_Unity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NotifyIcon_Unity
            // 
            this.NotifyIcon_Unity.ContextMenuStrip = this.ContextMenuStrip_Unity;
            this.NotifyIcon_Unity.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon_Unity.Icon")));
            this.NotifyIcon_Unity.Text = "工程管理 - Unity";
            this.NotifyIcon_Unity.Visible = true;
            this.NotifyIcon_Unity.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_Unity_MouseDoubleClick);
            // 
            // ContextMenuStrip_Unity
            // 
            this.ContextMenuStrip_Unity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTitleToolStripMenuItem,
            this.toolStripSeparator4,
            this.MenuSettingToolStripMenuItem,
            this.MenuOptionToolStripMenuItem,
            this.toolStripSeparator2,
            this.MenuCreateNewProjectToolStripMenuItem,
            this.MenuDragBoardToolStripMenuItem,
            this.MenuRecentToolStripMenuItem});
            this.ContextMenuStrip_Unity.Name = "ContextMenuStrip_Unity";
            this.ContextMenuStrip_Unity.Size = new System.Drawing.Size(166, 148);
            // 
            // MenuTitleToolStripMenuItem
            // 
            this.MenuTitleToolStripMenuItem.Name = "MenuTitleToolStripMenuItem";
            this.MenuTitleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MenuTitleToolStripMenuItem.Text = "Unity工程管理器";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(162, 6);
            // 
            // MenuSettingToolStripMenuItem
            // 
            this.MenuSettingToolStripMenuItem.Name = "MenuSettingToolStripMenuItem";
            this.MenuSettingToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MenuSettingToolStripMenuItem.Text = "设置";
            this.MenuSettingToolStripMenuItem.Click += new System.EventHandler(this.MenuSettingToolStripMenuItem_Click);
            // 
            // MenuOptionToolStripMenuItem
            // 
            this.MenuOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHookStateChangeToolStripMenuItem});
            this.MenuOptionToolStripMenuItem.Name = "MenuOptionToolStripMenuItem";
            this.MenuOptionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MenuOptionToolStripMenuItem.Text = "选项";
            // 
            // MenuHookStateChangeToolStripMenuItem
            // 
            this.MenuHookStateChangeToolStripMenuItem.Checked = true;
            this.MenuHookStateChangeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuHookStateChangeToolStripMenuItem.Name = "MenuHookStateChangeToolStripMenuItem";
            this.MenuHookStateChangeToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.MenuHookStateChangeToolStripMenuItem.Text = "监听系统所选Unity文件夹[F9]";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // MenuCreateNewProjectToolStripMenuItem
            // 
            this.MenuCreateNewProjectToolStripMenuItem.Name = "MenuCreateNewProjectToolStripMenuItem";
            this.MenuCreateNewProjectToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MenuCreateNewProjectToolStripMenuItem.Text = "创建新工程";
            // 
            // MenuDragBoardToolStripMenuItem
            // 
            this.MenuDragBoardToolStripMenuItem.Name = "MenuDragBoardToolStripMenuItem";
            this.MenuDragBoardToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MenuDragBoardToolStripMenuItem.Text = "拖拽版";
            // 
            // MenuRecentToolStripMenuItem
            // 
            this.MenuRecentToolStripMenuItem.Name = "MenuRecentToolStripMenuItem";
            this.MenuRecentToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MenuRecentToolStripMenuItem.Text = "最近项目";
            // 
            // TabControl_ProjectGroup
            // 
            this.TabControl_ProjectGroup.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabControl_ProjectGroup.Location = new System.Drawing.Point(12, 12);
            this.TabControl_ProjectGroup.Multiline = true;
            this.TabControl_ProjectGroup.Name = "TabControl_ProjectGroup";
            this.TabControl_ProjectGroup.SelectedIndex = 0;
            this.TabControl_ProjectGroup.Size = new System.Drawing.Size(320, 657);
            this.TabControl_ProjectGroup.TabIndex = 0;
            this.TabControl_ProjectGroup.SelectedIndexChanged += new System.EventHandler(this.TabControl_ProjectGroup_SelectedIndexChanged);
            // 
            // Label_Version
            // 
            this.Label_Version.AutoSize = true;
            this.Label_Version.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Version.Location = new System.Drawing.Point(6, 69);
            this.Label_Version.Name = "Label_Version";
            this.Label_Version.Size = new System.Drawing.Size(63, 21);
            this.Label_Version.TabIndex = 1;
            this.Label_Version.Text = "版本:";
            // 
            // GroupBox_Unity
            // 
            this.GroupBox_Unity.Controls.Add(this.Button_OpenFolder);
            this.GroupBox_Unity.Controls.Add(this.Button_OpenWithVersion);
            this.GroupBox_Unity.Controls.Add(this.Button_Open);
            this.GroupBox_Unity.Controls.Add(this.pictureBox1);
            this.GroupBox_Unity.Controls.Add(this.Label_Info);
            this.GroupBox_Unity.Controls.Add(this.Label_Name);
            this.GroupBox_Unity.Controls.Add(this.Label_Version);
            this.GroupBox_Unity.Font = new System.Drawing.Font("宋体", 15.75F);
            this.GroupBox_Unity.Location = new System.Drawing.Point(338, 12);
            this.GroupBox_Unity.Name = "GroupBox_Unity";
            this.GroupBox_Unity.Size = new System.Drawing.Size(914, 657);
            this.GroupBox_Unity.TabIndex = 2;
            this.GroupBox_Unity.TabStop = false;
            this.GroupBox_Unity.Text = "选择项目";
            this.GroupBox_Unity.Visible = false;
            // 
            // Button_OpenFolder
            // 
            this.Button_OpenFolder.Location = new System.Drawing.Point(10, 604);
            this.Button_OpenFolder.Name = "Button_OpenFolder";
            this.Button_OpenFolder.Size = new System.Drawing.Size(138, 47);
            this.Button_OpenFolder.TabIndex = 7;
            this.Button_OpenFolder.Text = "打开文件夹";
            this.Button_OpenFolder.UseVisualStyleBackColor = true;
            this.Button_OpenFolder.Click += new System.EventHandler(this.Button_OpenFolder_Click);
            // 
            // Button_OpenWithVersion
            // 
            this.Button_OpenWithVersion.Location = new System.Drawing.Point(891, 604);
            this.Button_OpenWithVersion.Name = "Button_OpenWithVersion";
            this.Button_OpenWithVersion.Size = new System.Drawing.Size(17, 47);
            this.Button_OpenWithVersion.TabIndex = 6;
            this.Button_OpenWithVersion.Text = ">";
            this.Button_OpenWithVersion.UseVisualStyleBackColor = true;
            this.Button_OpenWithVersion.Click += new System.EventHandler(this.Button_OpenWithVersion_Click);
            // 
            // Button_Open
            // 
            this.Button_Open.Location = new System.Drawing.Point(747, 604);
            this.Button_Open.Name = "Button_Open";
            this.Button_Open.Size = new System.Drawing.Size(138, 47);
            this.Button_Open.TabIndex = 5;
            this.Button_Open.Text = "打开";
            this.Button_Open.UseVisualStyleBackColor = true;
            this.Button_Open.Click += new System.EventHandler(this.Button_Open_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjectManager.Properties.Resources.没有图片;
            this.pictureBox1.Location = new System.Drawing.Point(10, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(898, 505);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Label_Info
            // 
            this.Label_Info.AutoSize = true;
            this.Label_Info.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Info.Location = new System.Drawing.Point(223, 69);
            this.Label_Info.Name = "Label_Info";
            this.Label_Info.Size = new System.Drawing.Size(63, 21);
            this.Label_Info.TabIndex = 3;
            this.Label_Info.Text = "信息:";
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Name.Location = new System.Drawing.Point(6, 48);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(63, 21);
            this.Label_Name.TabIndex = 2;
            this.Label_Name.Text = "名称:";
            // 
            // Timer_Hook
            // 
            this.Timer_Hook.Enabled = true;
            this.Timer_Hook.Interval = 50;
            this.Timer_Hook.Tick += new System.EventHandler(this.Timer_Hook_Tick);
            // 
            // Form_Unity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.GroupBox_Unity);
            this.Controls.Add(this.TabControl_ProjectGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Unity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工程管理 - Unity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Unity_FormClosing);
            this.Load += new System.EventHandler(this.Form_Unity_Load);
            this.Shown += new System.EventHandler(this.Form_Unity_Shown);
            this.ContextMenuStrip_Unity.ResumeLayout(false);
            this.GroupBox_Unity.ResumeLayout(false);
            this.GroupBox_Unity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon_Unity;
        private System.Windows.Forms.TabControl TabControl_ProjectGroup;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Unity;
        private System.Windows.Forms.ToolStripMenuItem MenuSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuDragBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuRecentToolStripMenuItem;
        private System.Windows.Forms.Label Label_Version;
        private System.Windows.Forms.GroupBox GroupBox_Unity;
        private System.Windows.Forms.Label Label_Info;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Button_OpenWithVersion;
        private System.Windows.Forms.Button Button_Open;
        private System.Windows.Forms.Button Button_OpenFolder;
        private System.Windows.Forms.ToolStripMenuItem MenuOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuHookStateChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Timer Timer_Hook;
        private System.Windows.Forms.ToolStripMenuItem MenuCreateNewProjectToolStripMenuItem;
    }
}