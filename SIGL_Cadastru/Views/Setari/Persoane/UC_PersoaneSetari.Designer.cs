using System.Windows.Forms;

namespace SIGL_Cadastru.Views.Setari
{
    partial class UC_PersoaneSetari
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
            foreach (Control control in panel_persoane.Controls)
            {

                control.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_persoane = new System.Windows.Forms.Panel();
            this.button_edit = new System.Windows.Forms.Button();
            this.panel_edit = new System.Windows.Forms.Panel();
            this.button_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_persoane
            // 
            this.panel_persoane.Location = new System.Drawing.Point(3, 3);
            this.panel_persoane.Name = "panel_persoane";
            this.panel_persoane.Size = new System.Drawing.Size(450, 250);
            this.panel_persoane.TabIndex = 0;
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(3, 259);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(102, 38);
            this.button_edit.TabIndex = 0;
            this.button_edit.Text = "Editeaza";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // panel_edit
            // 
            this.panel_edit.Location = new System.Drawing.Point(3, 300);
            this.panel_edit.Name = "panel_edit";
            this.panel_edit.Size = new System.Drawing.Size(550, 250);
            this.panel_edit.TabIndex = 1;
            // 
            // button_delete
            // 
            this.button_delete.ForeColor = System.Drawing.Color.Red;
            this.button_delete.Location = new System.Drawing.Point(111, 259);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(102, 38);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Șterge";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // UC_PersoaneSetari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.panel_edit);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.panel_persoane);
            this.Name = "UC_PersoaneSetari";
            this.Size = new System.Drawing.Size(677, 553);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.UC_PersoaneSetari_ControlRemoved);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_persoane;
        private Button button_edit;
        private Panel panel_edit;
        private Button button_delete;
    }
}
