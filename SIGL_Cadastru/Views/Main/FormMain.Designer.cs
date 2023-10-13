namespace SIGL_Cadastru.Views
{
    partial class FormMain
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
            this.button_cerere_noua = new System.Windows.Forms.Button();
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_setari = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel_content.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_cerere_noua
            // 
            this.button_cerere_noua.Location = new System.Drawing.Point(12, 12);
            this.button_cerere_noua.Name = "button_cerere_noua";
            this.button_cerere_noua.Size = new System.Drawing.Size(100, 50);
            this.button_cerere_noua.TabIndex = 3;
            this.button_cerere_noua.Text = "Cerere Noua";
            this.button_cerere_noua.UseVisualStyleBackColor = true;
            this.button_cerere_noua.Click += new System.EventHandler(this.button_cerere_noua_Click);
            // 
            // panel_content
            // 
            this.panel_content.Controls.Add(this.panel1);
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_content.Location = new System.Drawing.Point(0, 0);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(1190, 627);
            this.panel_content.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_setari);
            this.panel1.Controls.Add(this.button_cerere_noua);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 73);
            this.panel1.TabIndex = 5;
            // 
            // button_setari
            // 
            this.button_setari.Location = new System.Drawing.Point(118, 12);
            this.button_setari.Name = "button_setari";
            this.button_setari.Size = new System.Drawing.Size(100, 50);
            this.button_setari.TabIndex = 4;
            this.button_setari.Text = "Setari";
            this.button_setari.UseVisualStyleBackColor = true;
            this.button_setari.Click += new System.EventHandler(this.button_setari_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 627);
            this.Controls.Add(this.panel_content);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_content.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button button_cerere_noua;
        private Panel panel_content;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button_setari;
        private Panel panel1;
    }
}