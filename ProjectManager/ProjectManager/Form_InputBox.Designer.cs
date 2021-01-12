namespace ProjectManager
{
    partial class Form_InputBox
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
            this.Text_Input = new System.Windows.Forms.TextBox();
            this.Btn_Confirm = new System.Windows.Forms.Button();
            this.Label_StateShow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Text_Input
            // 
            this.Text_Input.Location = new System.Drawing.Point(12, 12);
            this.Text_Input.Name = "Text_Input";
            this.Text_Input.Size = new System.Drawing.Size(335, 21);
            this.Text_Input.TabIndex = 0;
            this.Text_Input.TextChanged += new System.EventHandler(this.Text_Input_TextChanged);
            // 
            // Btn_Confirm
            // 
            this.Btn_Confirm.Location = new System.Drawing.Point(353, 11);
            this.Btn_Confirm.Name = "Btn_Confirm";
            this.Btn_Confirm.Size = new System.Drawing.Size(69, 23);
            this.Btn_Confirm.TabIndex = 1;
            this.Btn_Confirm.Text = "确定";
            this.Btn_Confirm.UseVisualStyleBackColor = true;
            this.Btn_Confirm.Click += new System.EventHandler(this.Btn_Confirm_Click);
            // 
            // Label_StateShow
            // 
            this.Label_StateShow.AutoSize = true;
            this.Label_StateShow.Location = new System.Drawing.Point(12, 36);
            this.Label_StateShow.Name = "Label_StateShow";
            this.Label_StateShow.Size = new System.Drawing.Size(0, 12);
            this.Label_StateShow.TabIndex = 2;
            // 
            // Form_InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 57);
            this.Controls.Add(this.Label_StateShow);
            this.Controls.Add(this.Btn_Confirm);
            this.Controls.Add(this.Text_Input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "键入文本";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_Input;
        private System.Windows.Forms.Button Btn_Confirm;
        private System.Windows.Forms.Label Label_StateShow;
    }
}