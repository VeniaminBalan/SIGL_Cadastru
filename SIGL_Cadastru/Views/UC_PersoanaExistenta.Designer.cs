namespace SIGL_Cadastru.Views
{
    partial class UC_PersoanaExistenta
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
            this.components = new System.ComponentModel.Container();
            this.persoanaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBox_persoane = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.persoanaDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_selectedPerson = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.persoanaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.persoanaDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // persoanaBindingSource
            // 
            this.persoanaBindingSource.DataSource = typeof(SIGL_Cadastru.Repo.Models.Persoana);
            // 
            // listBox_persoane
            // 
            this.listBox_persoane.FormattingEnabled = true;
            this.listBox_persoane.ItemHeight = 20;
            this.listBox_persoane.Location = new System.Drawing.Point(15, 48);
            this.listBox_persoane.Name = "listBox_persoane";
            this.listBox_persoane.Size = new System.Drawing.Size(445, 164);
            this.listBox_persoane.TabIndex = 2;
            this.listBox_persoane.Click += new System.EventHandler(this.listBox_persoane_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cautare:";
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(104, 15);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(356, 27);
            this.textBox_search.TabIndex = 4;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // persoanaDtoBindingSource
            // 
            this.persoanaDtoBindingSource.DataSource = typeof(SIGL_Cadastru.App.Entities.PersoanaDto);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Persoana Selectata:";
            // 
            // label_selectedPerson
            // 
            this.label_selectedPerson.AutoSize = true;
            this.label_selectedPerson.Location = new System.Drawing.Point(178, 235);
            this.label_selectedPerson.Name = "label_selectedPerson";
            this.label_selectedPerson.Size = new System.Drawing.Size(0, 20);
            this.label_selectedPerson.TabIndex = 6;
            // 
            // UC_PersoanaExistenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_selectedPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_persoane);
            this.Name = "UC_PersoanaExistenta";
            this.Size = new System.Drawing.Size(498, 283);
            this.Load += new System.EventHandler(this.UC_PersoanaExistenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.persoanaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.persoanaDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BindingSource persoanaBindingSource;
        private ListBox listBox_persoane;
        private Label label2;
        private TextBox textBox_search;
        private BindingSource persoanaDtoBindingSource;
        private Label label1;
        private Label label_selectedPerson;
    }
}
