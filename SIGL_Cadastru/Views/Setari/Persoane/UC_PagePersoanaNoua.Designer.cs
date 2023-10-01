namespace SIGL_Cadastru.Views.Setari.Persoane
{
    partial class UC_PagePersoanaNoua
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
            this.panel_persoanaNoua = new System.Windows.Forms.Panel();
            this.button_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_persoanaNoua
            // 
            this.panel_persoanaNoua.Location = new System.Drawing.Point(21, 65);
            this.panel_persoanaNoua.Name = "panel_persoanaNoua";
            this.panel_persoanaNoua.Size = new System.Drawing.Size(450, 250);
            this.panel_persoanaNoua.TabIndex = 0;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(371, 321);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(100, 40);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "Salvează";
            this.button_save.UseVisualStyleBackColor = true;
            // 
            // UC_PagePersoanaNoua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.panel_persoanaNoua);
            this.Name = "UC_PagePersoanaNoua";
            this.Size = new System.Drawing.Size(677, 553);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_persoanaNoua;
        private Button button_save;
    }
}
