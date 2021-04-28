namespace ReportRenamer
{
    partial class Form1
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
            this.btnRename = new System.Windows.Forms.Button();
            this.txtJobNum = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhase = new System.Windows.Forms.TextBox();
            this.chbShared = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.lblRevision = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRevisionEx = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSaddleClips = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(123, 118);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(266, 43);
            this.btnRename.TabIndex = 4;
            this.btnRename.Text = "Move and Rename Files";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.BtnRename_Click);
            // 
            // txtJobNum
            // 
            this.txtJobNum.Location = new System.Drawing.Point(123, 12);
            this.txtJobNum.Name = "txtJobNum";
            this.txtJobNum.Size = new System.Drawing.Size(266, 20);
            this.txtJobNum.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Job Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Phase:";
            // 
            // txtPhase
            // 
            this.txtPhase.Location = new System.Drawing.Point(123, 38);
            this.txtPhase.Name = "txtPhase";
            this.txtPhase.Size = new System.Drawing.Size(266, 20);
            this.txtPhase.TabIndex = 1;
            // 
            // chbShared
            // 
            this.chbShared.AutoSize = true;
            this.chbShared.Location = new System.Drawing.Point(395, 121);
            this.chbShared.Name = "chbShared";
            this.chbShared.Size = new System.Drawing.Size(98, 17);
            this.chbShared.TabIndex = 3;
            this.chbShared.Text = "Shared Model?";
            this.chbShared.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ex: JME1-ISS1";
            // 
            // txtRevision
            // 
            this.txtRevision.Location = new System.Drawing.Point(123, 64);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(266, 20);
            this.txtRevision.TabIndex = 2;
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.Location = new System.Drawing.Point(26, 67);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(91, 13);
            this.lblRevision.TabIndex = 9;
            this.lblRevision.Text = "Revision Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "ex: 20-704 OR SJ49849";
            // 
            // lblRevisionEx
            // 
            this.lblRevisionEx.AutoSize = true;
            this.lblRevisionEx.Location = new System.Drawing.Point(392, 67);
            this.lblRevisionEx.Name = "lblRevisionEx";
            this.lblRevisionEx.Size = new System.Drawing.Size(126, 13);
            this.lblRevisionEx.TabIndex = 11;
            this.lblRevisionEx.Text = "Just the number, no letter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Extra Saddle Clips Required:";
            // 
            // txtSaddleClips
            // 
            this.txtSaddleClips.Location = new System.Drawing.Point(205, 90);
            this.txtSaddleClips.Name = "txtSaddleClips";
            this.txtSaddleClips.Size = new System.Drawing.Size(100, 20);
            this.txtSaddleClips.TabIndex = 13;
            this.txtSaddleClips.Validating += new System.ComponentModel.CancelEventHandler(this.txtSaddleClips_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 173);
            this.Controls.Add(this.txtSaddleClips);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRevisionEx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.txtRevision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbShared);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPhase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJobNum);
            this.Controls.Add(this.btnRename);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox txtJobNum;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhase;
        private System.Windows.Forms.CheckBox chbShared;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRevisionEx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaddleClips;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

