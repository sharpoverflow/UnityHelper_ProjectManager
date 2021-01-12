namespace ProjectManager
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.NotifyIcon_Mian = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon_Mian
            // 
            this.NotifyIcon_Mian.ContextMenuStrip = this.ContextMenuStrip_Main;
            this.NotifyIcon_Mian.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon_Mian.Icon")));
            this.NotifyIcon_Mian.Text = "工程管理 - 设置";
            this.NotifyIcon_Mian.Visible = true;
            // 
            // ContextMenuStrip_Main
            // 
            this.ContextMenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuShowToolStripMenuItem,
            this.MenuCloseToolStripMenuItem});
            this.ContextMenuStrip_Main.Name = "ContextMenuStrip_Main";
            this.ContextMenuStrip_Main.Size = new System.Drawing.Size(101, 48);
            // 
            // MenuShowToolStripMenuItem
            // 
            this.MenuShowToolStripMenuItem.Name = "MenuShowToolStripMenuItem";
            this.MenuShowToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.MenuShowToolStripMenuItem.Text = "显示";
            this.MenuShowToolStripMenuItem.Click += new System.EventHandler(this.MenuShowToolStripMenuItem_Click);
            // 
            // MenuCloseToolStripMenuItem
            // 
            this.MenuCloseToolStripMenuItem.Name = "MenuCloseToolStripMenuItem";
            this.MenuCloseToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.MenuCloseToolStripMenuItem.Text = "关闭";
            this.MenuCloseToolStripMenuItem.Click += new System.EventHandler(this.MenuCloseToolStripMenuItem_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 354);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ContextMenuStrip_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon_Mian;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem MenuShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuCloseToolStripMenuItem;
    }
}

