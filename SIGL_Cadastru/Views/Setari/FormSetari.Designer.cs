﻿namespace SIGL_Cadastru.Views.Setari
{
    partial class FormSetari
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.linkLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(882, 553);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(11, 8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(129, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Editeaza Persoane";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FormSetari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSetari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSetari";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSetari_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private LinkLabel linkLabel1;
    }
}