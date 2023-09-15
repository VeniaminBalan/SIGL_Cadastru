namespace SIGL_Cadastru.Views.Adaugare_Lucrare
{
    partial class UC_Custom
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_lucrare = new System.Windows.Forms.Panel();
            this.textBox_pret = new System.Windows.Forms.TextBox();
            this.textBox_lucrare = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_lucrare.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_lucrare
            // 
            this.panel_lucrare.Controls.Add(this.textBox_pret);
            this.panel_lucrare.Controls.Add(this.textBox_lucrare);
            this.panel_lucrare.Controls.Add(this.label4);
            this.panel_lucrare.Controls.Add(this.label3);
            this.panel_lucrare.Location = new System.Drawing.Point(139, 134);
            this.panel_lucrare.Name = "panel_lucrare";
            this.panel_lucrare.Size = new System.Drawing.Size(408, 85);
            this.panel_lucrare.TabIndex = 10;
            // 
            // textBox_pret
            // 
            this.textBox_pret.Location = new System.Drawing.Point(328, 36);
            this.textBox_pret.Name = "textBox_pret";
            this.textBox_pret.Size = new System.Drawing.Size(66, 27);
            this.textBox_pret.TabIndex = 3;
            this.textBox_pret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            // 
            // textBox_lucrare
            // 
            this.textBox_lucrare.Location = new System.Drawing.Point(17, 36);
            this.textBox_lucrare.Name = "textBox_lucrare";
            this.textBox_lucrare.Size = new System.Drawing.Size(296, 27);
            this.textBox_lucrare.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pret:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lucrare:";
            // 
            // UC_Custom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_lucrare);
            this.Name = "UC_Custom";
            this.Size = new System.Drawing.Size(700, 350);
            this.panel_lucrare.ResumeLayout(false);
            this.panel_lucrare.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_lucrare;
        private TextBox textBox_pret;
        private TextBox textBox_lucrare;
        private Label label4;
        private Label label3;
    }
}
