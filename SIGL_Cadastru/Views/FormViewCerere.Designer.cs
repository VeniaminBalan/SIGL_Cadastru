﻿namespace SIGL_Cadastru.Views
{
    partial class FormViewCerere
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tipLucrareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lucrareDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_responsabil = new System.Windows.Forms.Label();
            this.label_executant = new System.Windows.Forms.Label();
            this.label_stareaCererii = new System.Windows.Forms.Label();
            this.label_valabilDeLa = new System.Windows.Forms.Label();
            this.label_ValabilPanaLa = new System.Windows.Forms.Label();
            this.label_pretTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_Nume = new System.Windows.Forms.Label();
            this.label_prenume = new System.Windows.Forms.Label();
            this.label_idnp = new System.Windows.Forms.Label();
            this.label_domiciliu = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_telefon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lucrareDtoBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Responsabil:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Executant:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Starea Cererii:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valabil de la:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valabil pana la:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pret total:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipLucrareDataGridViewTextBoxColumn,
            this.pretDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.lucrareDtoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(344, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(554, 222);
            this.dataGridView1.TabIndex = 6;
            // 
            // tipLucrareDataGridViewTextBoxColumn
            // 
            this.tipLucrareDataGridViewTextBoxColumn.DataPropertyName = "TipLucrare";
            this.tipLucrareDataGridViewTextBoxColumn.HeaderText = "TipLucrare";
            this.tipLucrareDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipLucrareDataGridViewTextBoxColumn.Name = "tipLucrareDataGridViewTextBoxColumn";
            this.tipLucrareDataGridViewTextBoxColumn.Width = 450;
            // 
            // pretDataGridViewTextBoxColumn
            // 
            this.pretDataGridViewTextBoxColumn.DataPropertyName = "Pret";
            this.pretDataGridViewTextBoxColumn.HeaderText = "Pret";
            this.pretDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pretDataGridViewTextBoxColumn.Name = "pretDataGridViewTextBoxColumn";
            this.pretDataGridViewTextBoxColumn.Width = 50;
            // 
            // lucrareDtoBindingSource
            // 
            this.lucrareDtoBindingSource.DataSource = typeof(SIGL_Cadastru.App.Entities.LucrareDto);
            // 
            // label_responsabil
            // 
            this.label_responsabil.AutoSize = true;
            this.label_responsabil.Location = new System.Drawing.Point(149, 29);
            this.label_responsabil.Name = "label_responsabil";
            this.label_responsabil.Size = new System.Drawing.Size(50, 20);
            this.label_responsabil.TabIndex = 7;
            this.label_responsabil.Text = "label7";
            // 
            // label_executant
            // 
            this.label_executant.AutoSize = true;
            this.label_executant.Location = new System.Drawing.Point(149, 66);
            this.label_executant.Name = "label_executant";
            this.label_executant.Size = new System.Drawing.Size(50, 20);
            this.label_executant.TabIndex = 8;
            this.label_executant.Text = "label7";
            // 
            // label_stareaCererii
            // 
            this.label_stareaCererii.AutoSize = true;
            this.label_stareaCererii.Location = new System.Drawing.Point(149, 103);
            this.label_stareaCererii.Name = "label_stareaCererii";
            this.label_stareaCererii.Size = new System.Drawing.Size(50, 20);
            this.label_stareaCererii.TabIndex = 9;
            this.label_stareaCererii.Text = "label7";
            // 
            // label_valabilDeLa
            // 
            this.label_valabilDeLa.AutoSize = true;
            this.label_valabilDeLa.Location = new System.Drawing.Point(149, 140);
            this.label_valabilDeLa.Name = "label_valabilDeLa";
            this.label_valabilDeLa.Size = new System.Drawing.Size(50, 20);
            this.label_valabilDeLa.TabIndex = 10;
            this.label_valabilDeLa.Text = "label7";
            // 
            // label_ValabilPanaLa
            // 
            this.label_ValabilPanaLa.AutoSize = true;
            this.label_ValabilPanaLa.Location = new System.Drawing.Point(149, 177);
            this.label_ValabilPanaLa.Name = "label_ValabilPanaLa";
            this.label_ValabilPanaLa.Size = new System.Drawing.Size(50, 20);
            this.label_ValabilPanaLa.TabIndex = 11;
            this.label_ValabilPanaLa.Text = "label7";
            // 
            // label_pretTotal
            // 
            this.label_pretTotal.AutoSize = true;
            this.label_pretTotal.Location = new System.Drawing.Point(149, 214);
            this.label_pretTotal.Name = "label_pretTotal";
            this.label_pretTotal.Size = new System.Drawing.Size(50, 20);
            this.label_pretTotal.TabIndex = 12;
            this.label_pretTotal.Text = "label7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Client:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_telefon);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label_email);
            this.panel1.Controls.Add(this.label_domiciliu);
            this.panel1.Controls.Add(this.label_idnp);
            this.panel1.Controls.Add(this.label_prenume);
            this.panel1.Controls.Add(this.label_Nume);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(112, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 125);
            this.panel1.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(360, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Domiciliu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(97, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "IDNP:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Prenume:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nume:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(360, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Email:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(360, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "Telefon:";
            // 
            // label_Nume
            // 
            this.label_Nume.AutoSize = true;
            this.label_Nume.Location = new System.Drawing.Point(180, 14);
            this.label_Nume.Name = "label_Nume";
            this.label_Nume.Size = new System.Drawing.Size(58, 20);
            this.label_Nume.TabIndex = 6;
            this.label_Nume.Text = "label14";
            // 
            // label_prenume
            // 
            this.label_prenume.AutoSize = true;
            this.label_prenume.Location = new System.Drawing.Point(180, 43);
            this.label_prenume.Name = "label_prenume";
            this.label_prenume.Size = new System.Drawing.Size(58, 20);
            this.label_prenume.TabIndex = 7;
            this.label_prenume.Text = "label14";
            // 
            // label_idnp
            // 
            this.label_idnp.AutoSize = true;
            this.label_idnp.Location = new System.Drawing.Point(180, 73);
            this.label_idnp.Name = "label_idnp";
            this.label_idnp.Size = new System.Drawing.Size(58, 20);
            this.label_idnp.TabIndex = 8;
            this.label_idnp.Text = "label14";
            // 
            // label_domiciliu
            // 
            this.label_domiciliu.AutoSize = true;
            this.label_domiciliu.Location = new System.Drawing.Point(452, 14);
            this.label_domiciliu.Name = "label_domiciliu";
            this.label_domiciliu.Size = new System.Drawing.Size(58, 20);
            this.label_domiciliu.TabIndex = 9;
            this.label_domiciliu.Text = "label14";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(452, 43);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(58, 20);
            this.label_email.TabIndex = 10;
            this.label_email.Text = "label14";
            // 
            // label_telefon
            // 
            this.label_telefon.AutoSize = true;
            this.label_telefon.Location = new System.Drawing.Point(452, 73);
            this.label_telefon.Name = "label_telefon";
            this.label_telefon.Size = new System.Drawing.Size(58, 20);
            this.label_telefon.TabIndex = 11;
            this.label_telefon.Text = "label14";
            // 
            // FormViewCerere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_pretTotal);
            this.Controls.Add(this.label_ValabilPanaLa);
            this.Controls.Add(this.label_valabilDeLa);
            this.Controls.Add(this.label_stareaCererii);
            this.Controls.Add(this.label_executant);
            this.Controls.Add(this.label_responsabil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormViewCerere";
            this.Text = "FormViewCerere";
            this.Load += new System.EventHandler(this.FormViewCerere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lucrareDtoBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn tipLucrareDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pretDataGridViewTextBoxColumn;
        private BindingSource lucrareDtoBindingSource;
        private Label label_responsabil;
        private Label label_executant;
        private Label label_stareaCererii;
        private Label label_valabilDeLa;
        private Label label_ValabilPanaLa;
        private Label label_pretTotal;
        private Label label7;
        private Panel panel1;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label13;
        private Label label12;
        private Label label_telefon;
        private Label label_email;
        private Label label_domiciliu;
        private Label label_idnp;
        private Label label_prenume;
        private Label label_Nume;
    }
}