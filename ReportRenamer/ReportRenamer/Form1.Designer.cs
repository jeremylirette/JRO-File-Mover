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
            this.lblStruct2 = new System.Windows.Forms.Label();
            this.lblStruct = new System.Windows.Forms.Label();
            this.txtStruct = new System.Windows.Forms.TextBox();
            this.chbSplit = new System.Windows.Forms.CheckBox();
            this.rdoPowerfab = new System.Windows.Forms.RadioButton();
            this.rdoFabtrol = new System.Windows.Forms.RadioButton();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.gbType.SuspendLayout();
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
            this.chbShared.Checked = true;
            this.chbShared.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShared.Location = new System.Drawing.Point(395, 121);
            this.chbShared.Name = "chbShared";
            this.chbShared.Size = new System.Drawing.Size(98, 17);
            this.chbShared.TabIndex = 8;
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
            // lblStruct2
            // 
            this.lblStruct2.AutoSize = true;
            this.lblStruct2.Location = new System.Drawing.Point(392, 93);
            this.lblStruct2.Name = "lblStruct2";
            this.lblStruct2.Size = new System.Drawing.Size(57, 13);
            this.lblStruct2.TabIndex = 14;
            this.lblStruct2.Text = "ex: 20-704";
            // 
            // lblStruct
            // 
            this.lblStruct.AutoSize = true;
            this.lblStruct.Location = new System.Drawing.Point(19, 93);
            this.lblStruct.Name = "lblStruct";
            this.lblStruct.Size = new System.Drawing.Size(98, 13);
            this.lblStruct.TabIndex = 13;
            this.lblStruct.Text = "Struct Job Number:";
            // 
            // txtStruct
            // 
            this.txtStruct.Location = new System.Drawing.Point(123, 90);
            this.txtStruct.Name = "txtStruct";
            this.txtStruct.Size = new System.Drawing.Size(266, 20);
            this.txtStruct.TabIndex = 3;
            // 
            // chbSplit
            // 
            this.chbSplit.AutoSize = true;
            this.chbSplit.Location = new System.Drawing.Point(395, 144);
            this.chbSplit.Name = "chbSplit";
            this.chbSplit.Size = new System.Drawing.Size(97, 17);
            this.chbSplit.TabIndex = 9;
            this.chbSplit.Text = "Split Numbers?";
            this.chbSplit.UseVisualStyleBackColor = true;
            this.chbSplit.CheckedChanged += new System.EventHandler(this.chbSplit_CheckedChanged);
            // 
            // rdoPowerfab
            // 
            this.rdoPowerfab.AutoSize = true;
            this.rdoPowerfab.Location = new System.Drawing.Point(6, 9);
            this.rdoPowerfab.Name = "rdoPowerfab";
            this.rdoPowerfab.Size = new System.Drawing.Size(70, 17);
            this.rdoPowerfab.TabIndex = 0;
            this.rdoPowerfab.TabStop = true;
            this.rdoPowerfab.Text = "Powerfab";
            this.rdoPowerfab.UseVisualStyleBackColor = true;
            // 
            // rdoFabtrol
            // 
            this.rdoFabtrol.AutoSize = true;
            this.rdoFabtrol.Location = new System.Drawing.Point(5, 34);
            this.rdoFabtrol.Name = "rdoFabtrol";
            this.rdoFabtrol.Size = new System.Drawing.Size(57, 17);
            this.rdoFabtrol.TabIndex = 1;
            this.rdoFabtrol.TabStop = true;
            this.rdoFabtrol.Text = "Fabtrol";
            this.rdoFabtrol.UseVisualStyleBackColor = true;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rdoPowerfab);
            this.gbType.Controls.Add(this.rdoFabtrol);
            this.gbType.Location = new System.Drawing.Point(12, 109);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(96, 52);
            this.gbType.TabIndex = 10;
            this.gbType.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 173);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.chbSplit);
            this.Controls.Add(this.lblStruct2);
            this.Controls.Add(this.lblStruct);
            this.Controls.Add(this.txtStruct);
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
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
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
        private System.Windows.Forms.Label lblStruct2;
        private System.Windows.Forms.Label lblStruct;
        private System.Windows.Forms.TextBox txtStruct;
        private System.Windows.Forms.CheckBox chbSplit;
        private System.Windows.Forms.RadioButton rdoPowerfab;
        private System.Windows.Forms.RadioButton rdoFabtrol;
        private System.Windows.Forms.GroupBox gbType;
    }
}

