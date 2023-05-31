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
            this.aside_navbar = new System.Windows.Forms.Panel();
            this.panel_content = new System.Windows.Forms.Panel();
            this.userControl11 = new SIGL_Cadastru.Views.UserControl1();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.aside_navbar.SuspendLayout();
            this.panel_content.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_cerere_noua
            // 
            this.button_cerere_noua.Location = new System.Drawing.Point(0, 76);
            this.button_cerere_noua.Name = "button_cerere_noua";
            this.button_cerere_noua.Size = new System.Drawing.Size(104, 40);
            this.button_cerere_noua.TabIndex = 3;
            this.button_cerere_noua.Text = "Cerere Noua";
            this.button_cerere_noua.UseVisualStyleBackColor = true;
            this.button_cerere_noua.Click += new System.EventHandler(this.button_cerere_noua_Click);
            // 
            // aside_navbar
            // 
            this.aside_navbar.Controls.Add(this.button_cerere_noua);
            this.aside_navbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.aside_navbar.Location = new System.Drawing.Point(0, 0);
            this.aside_navbar.Name = "aside_navbar";
            this.aside_navbar.Size = new System.Drawing.Size(103, 540);
            this.aside_navbar.TabIndex = 4;
            // 
            // panel_content
            // 
            this.panel_content.Controls.Add(this.userControl11);
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_content.Location = new System.Drawing.Point(103, 0);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(836, 540);
            this.panel_content.TabIndex = 5;
            // 
            // userControl11
            // 
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.ParentForm = null;
            this.userControl11.Size = new System.Drawing.Size(836, 540);
            this.userControl11.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 540);
            this.Controls.Add(this.panel_content);
            this.Controls.Add(this.aside_navbar);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.aside_navbar.ResumeLayout(false);
            this.panel_content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button button_cerere_noua;
        private Panel aside_navbar;
        private Panel panel_content;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private UserControl1 userControl11;
    }
}