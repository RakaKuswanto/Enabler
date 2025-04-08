namespace Enabler
{
    partial class Main
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
            this.cmdEnable = new System.Windows.Forms.Button();
            this.lblHWnd = new System.Windows.Forms.Label();
            this.imgTarget = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.TextBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.cmdSetText = new System.Windows.Forms.Button();
            this.txtSetText = new System.Windows.Forms.TextBox();
            this.timerSetText = new System.Windows.Forms.Timer(this.components);
            this.cmdGetText = new System.Windows.Forms.Button();
            this.timerGetText = new System.Windows.Forms.Timer(this.components);
            this.hwndTree = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdEnable
            // 
            this.cmdEnable.Location = new System.Drawing.Point(16, 108);
            this.cmdEnable.Name = "cmdEnable";
            this.cmdEnable.Size = new System.Drawing.Size(104, 32);
            this.cmdEnable.TabIndex = 0;
            this.cmdEnable.Text = "Enable";
            this.cmdEnable.UseVisualStyleBackColor = true;
            this.cmdEnable.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHWnd
            // 
            this.lblHWnd.AutoSize = true;
            this.lblHWnd.Location = new System.Drawing.Point(155, 12);
            this.lblHWnd.Name = "lblHWnd";
            this.lblHWnd.Size = new System.Drawing.Size(91, 13);
            this.lblHWnd.TabIndex = 1;
            this.lblHWnd.Text = "############";
            // 
            // imgTarget
            // 
            this.imgTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgTarget.Location = new System.Drawing.Point(17, 12);
            this.imgTarget.Name = "imgTarget";
            this.imgTarget.Size = new System.Drawing.Size(32, 32);
            this.imgTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgTarget.TabIndex = 2;
            this.imgTarget.TabStop = false;
            this.imgTarget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgTarget_MouseDown);
            this.imgTarget.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgTarget_MouseMove);
            this.imgTarget.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgTarget_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Window Handle :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ClassName         :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClassName
            // 
            this.lblClassName.BackColor = System.Drawing.SystemColors.Control;
            this.lblClassName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblClassName.Location = new System.Drawing.Point(158, 32);
            this.lblClassName.Multiline = true;
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(447, 37);
            this.lblClassName.TabIndex = 7;
            this.lblClassName.Text = "############";
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(137, 108);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(104, 32);
            this.cmdShow.TabIndex = 8;
            this.cmdShow.Text = "Toggle Visible";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // cmdSetText
            // 
            this.cmdSetText.Location = new System.Drawing.Point(391, 108);
            this.cmdSetText.Name = "cmdSetText";
            this.cmdSetText.Size = new System.Drawing.Size(104, 32);
            this.cmdSetText.TabIndex = 9;
            this.cmdSetText.Text = "Set Text (OFF)";
            this.cmdSetText.UseVisualStyleBackColor = true;
            this.cmdSetText.Click += new System.EventHandler(this.cmdSetText_Click);
            // 
            // txtSetText
            // 
            this.txtSetText.Location = new System.Drawing.Point(17, 60);
            this.txtSetText.Multiline = true;
            this.txtSetText.Name = "txtSetText";
            this.txtSetText.Size = new System.Drawing.Size(588, 42);
            this.txtSetText.TabIndex = 10;
            // 
            // timerSetText
            // 
            this.timerSetText.Tick += new System.EventHandler(this.timerText_Tick);
            // 
            // cmdGetText
            // 
            this.cmdGetText.Location = new System.Drawing.Point(501, 108);
            this.cmdGetText.Name = "cmdGetText";
            this.cmdGetText.Size = new System.Drawing.Size(104, 32);
            this.cmdGetText.TabIndex = 11;
            this.cmdGetText.Text = "Get Text (OFF)";
            this.cmdGetText.UseVisualStyleBackColor = true;
            this.cmdGetText.Click += new System.EventHandler(this.cmdGetText_Click);
            // 
            // timerGetText
            // 
            this.timerGetText.Tick += new System.EventHandler(this.timerGetText_Tick);
            // 
            // hwndTree
            // 
            this.hwndTree.Location = new System.Drawing.Point(17, 165);
            this.hwndTree.Name = "hwndTree";
            this.hwndTree.Size = new System.Drawing.Size(588, 244);
            this.hwndTree.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Window Size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 426);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hwndTree);
            this.Controls.Add(this.cmdGetText);
            this.Controls.Add(this.txtSetText);
            this.Controls.Add(this.cmdSetText);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHWnd);
            this.Controls.Add(this.cmdEnable);
            this.Controls.Add(this.imgTarget);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "HWND - Raka Kuswanto";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdEnable;
        private System.Windows.Forms.Label lblHWnd;
        private System.Windows.Forms.PictureBox imgTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lblClassName;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Button cmdSetText;
        private System.Windows.Forms.TextBox txtSetText;
        private System.Windows.Forms.Timer timerSetText;
        private System.Windows.Forms.Button cmdGetText;
        private System.Windows.Forms.Timer timerGetText;
        private System.Windows.Forms.TreeView hwndTree;
        private System.Windows.Forms.Label label3;
    }
}

