namespace SIGL_Cadastru.Views
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
            this.label_valabilDeLa = new System.Windows.Forms.Label();
            this.label_ValabilPanaLa = new System.Windows.Forms.Label();
            this.label_pretTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_telefon = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_domiciliu = new System.Windows.Forms.Label();
            this.label_idnp = new System.Windows.Forms.Label();
            this.label_prenume = new System.Windows.Forms.Label();
            this.label_Nume = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewStatus = new System.Windows.Forms.DataGridView();
            this.createdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stareaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cerereStatusDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_StareCererii = new System.Windows.Forms.Label();
            this.button_adaugareStare = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_Comment = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label_Nr = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_uc_doc = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lucrareDtoBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerereStatusDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Responsabil:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Executant:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Starea Cererii:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valabil de la:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valabil pana la:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pret total:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipLucrareDataGridViewTextBoxColumn,
            this.pretDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.lucrareDtoBindingSource;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(307, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(600, 206);
            this.dataGridView1.TabIndex = 6;
            // 
            // tipLucrareDataGridViewTextBoxColumn
            // 
            this.tipLucrareDataGridViewTextBoxColumn.DataPropertyName = "TipLucrare";
            this.tipLucrareDataGridViewTextBoxColumn.HeaderText = "TipLucrare";
            this.tipLucrareDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipLucrareDataGridViewTextBoxColumn.Name = "tipLucrareDataGridViewTextBoxColumn";
            this.tipLucrareDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipLucrareDataGridViewTextBoxColumn.Width = 495;
            // 
            // pretDataGridViewTextBoxColumn
            // 
            this.pretDataGridViewTextBoxColumn.DataPropertyName = "Pret";
            this.pretDataGridViewTextBoxColumn.HeaderText = "Pret";
            this.pretDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pretDataGridViewTextBoxColumn.Name = "pretDataGridViewTextBoxColumn";
            this.pretDataGridViewTextBoxColumn.ReadOnly = true;
            this.pretDataGridViewTextBoxColumn.Width = 50;
            // 
            // lucrareDtoBindingSource
            // 
            this.lucrareDtoBindingSource.DataSource = typeof(SIGL_Cadastru.App.Entities.LucrareDto);
            // 
            // label_responsabil
            // 
            this.label_responsabil.AutoSize = true;
            this.label_responsabil.Location = new System.Drawing.Point(149, 52);
            this.label_responsabil.Name = "label_responsabil";
            this.label_responsabil.Size = new System.Drawing.Size(18, 20);
            this.label_responsabil.TabIndex = 7;
            this.label_responsabil.Text = "...";
            // 
            // label_executant
            // 
            this.label_executant.AutoSize = true;
            this.label_executant.Location = new System.Drawing.Point(149, 89);
            this.label_executant.Name = "label_executant";
            this.label_executant.Size = new System.Drawing.Size(18, 20);
            this.label_executant.TabIndex = 8;
            this.label_executant.Text = "...";
            // 
            // label_valabilDeLa
            // 
            this.label_valabilDeLa.AutoSize = true;
            this.label_valabilDeLa.Location = new System.Drawing.Point(149, 163);
            this.label_valabilDeLa.Name = "label_valabilDeLa";
            this.label_valabilDeLa.Size = new System.Drawing.Size(18, 20);
            this.label_valabilDeLa.TabIndex = 10;
            this.label_valabilDeLa.Text = "...";
            // 
            // label_ValabilPanaLa
            // 
            this.label_ValabilPanaLa.AutoSize = true;
            this.label_ValabilPanaLa.Location = new System.Drawing.Point(149, 200);
            this.label_ValabilPanaLa.Name = "label_ValabilPanaLa";
            this.label_ValabilPanaLa.Size = new System.Drawing.Size(18, 20);
            this.label_ValabilPanaLa.TabIndex = 11;
            this.label_ValabilPanaLa.Text = "...";
            // 
            // label_pretTotal
            // 
            this.label_pretTotal.AutoSize = true;
            this.label_pretTotal.Location = new System.Drawing.Point(149, 237);
            this.label_pretTotal.Name = "label_pretTotal";
            this.label_pretTotal.Size = new System.Drawing.Size(18, 20);
            this.label_pretTotal.TabIndex = 12;
            this.label_pretTotal.Text = "...";
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
            this.panel1.Location = new System.Drawing.Point(307, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 125);
            this.panel1.TabIndex = 14;
            // 
            // label_telefon
            // 
            this.label_telefon.AutoSize = true;
            this.label_telefon.Location = new System.Drawing.Point(387, 73);
            this.label_telefon.Name = "label_telefon";
            this.label_telefon.Size = new System.Drawing.Size(18, 20);
            this.label_telefon.TabIndex = 11;
            this.label_telefon.Text = "...";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(387, 43);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(18, 20);
            this.label_email.TabIndex = 10;
            this.label_email.Text = "...";
            // 
            // label_domiciliu
            // 
            this.label_domiciliu.AutoSize = true;
            this.label_domiciliu.Location = new System.Drawing.Point(387, 14);
            this.label_domiciliu.Name = "label_domiciliu";
            this.label_domiciliu.Size = new System.Drawing.Size(18, 20);
            this.label_domiciliu.TabIndex = 9;
            this.label_domiciliu.Text = "...";
            // 
            // label_idnp
            // 
            this.label_idnp.AutoSize = true;
            this.label_idnp.Location = new System.Drawing.Point(155, 73);
            this.label_idnp.Name = "label_idnp";
            this.label_idnp.Size = new System.Drawing.Size(18, 20);
            this.label_idnp.TabIndex = 8;
            this.label_idnp.Text = "...";
            // 
            // label_prenume
            // 
            this.label_prenume.AutoSize = true;
            this.label_prenume.Location = new System.Drawing.Point(155, 43);
            this.label_prenume.Name = "label_prenume";
            this.label_prenume.Size = new System.Drawing.Size(18, 20);
            this.label_prenume.TabIndex = 7;
            this.label_prenume.Text = "...";
            // 
            // label_Nume
            // 
            this.label_Nume.AutoSize = true;
            this.label_Nume.Location = new System.Drawing.Point(155, 14);
            this.label_Nume.Name = "label_Nume";
            this.label_Nume.Size = new System.Drawing.Size(18, 20);
            this.label_Nume.TabIndex = 6;
            this.label_Nume.Text = "...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(295, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "Telefon:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(295, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Email:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(295, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Domiciliu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "IDNP:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Prenume:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nume:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 495);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 50);
            this.button1.TabIndex = 16;
            this.button1.Text = "Actualizare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewStatus
            // 
            this.dataGridViewStatus.AutoGenerateColumns = false;
            this.dataGridViewStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.createdDataGridViewTextBoxColumn,
            this.stareaDataGridViewTextBoxColumn});
            this.dataGridViewStatus.DataSource = this.cerereStatusDtoBindingSource;
            this.dataGridViewStatus.Location = new System.Drawing.Point(913, 12);
            this.dataGridViewStatus.Name = "dataGridViewStatus";
            this.dataGridViewStatus.ReadOnly = true;
            this.dataGridViewStatus.RowHeadersWidth = 51;
            this.dataGridViewStatus.RowTemplate.Height = 29;
            this.dataGridViewStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStatus.Size = new System.Drawing.Size(279, 315);
            this.dataGridViewStatus.TabIndex = 17;
            this.dataGridViewStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStatus_CellContentClick);
            // 
            // createdDataGridViewTextBoxColumn
            // 
            this.createdDataGridViewTextBoxColumn.DataPropertyName = "Created";
            this.createdDataGridViewTextBoxColumn.HeaderText = "Data";
            this.createdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.createdDataGridViewTextBoxColumn.Name = "createdDataGridViewTextBoxColumn";
            this.createdDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdDataGridViewTextBoxColumn.Width = 125;
            // 
            // stareaDataGridViewTextBoxColumn
            // 
            this.stareaDataGridViewTextBoxColumn.DataPropertyName = "Starea";
            this.stareaDataGridViewTextBoxColumn.HeaderText = "Starea";
            this.stareaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.stareaDataGridViewTextBoxColumn.Name = "stareaDataGridViewTextBoxColumn";
            this.stareaDataGridViewTextBoxColumn.ReadOnly = true;
            this.stareaDataGridViewTextBoxColumn.Width = 125;
            // 
            // cerereStatusDtoBindingSource
            // 
            this.cerereStatusDtoBindingSource.DataSource = typeof(SIGL_Cadastru.App.Entities.DataTransferObjects.CerereStatusDto);
            // 
            // label_StareCererii
            // 
            this.label_StareCererii.AutoSize = true;
            this.label_StareCererii.Location = new System.Drawing.Point(149, 126);
            this.label_StareCererii.Name = "label_StareCererii";
            this.label_StareCererii.Size = new System.Drawing.Size(18, 20);
            this.label_StareCererii.TabIndex = 18;
            this.label_StareCererii.Text = "...";
            // 
            // button_adaugareStare
            // 
            this.button_adaugareStare.Location = new System.Drawing.Point(996, 333);
            this.button_adaugareStare.Name = "button_adaugareStare";
            this.button_adaugareStare.Size = new System.Drawing.Size(113, 49);
            this.button_adaugareStare.TabIndex = 19;
            this.button_adaugareStare.Text = "Adaugare";
            this.button_adaugareStare.UseVisualStyleBackColor = true;
            this.button_adaugareStare.Click += new System.EventHandler(this.button_adaugareStare_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(1129, 333);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(63, 29);
            this.button_reset.TabIndex = 20;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(913, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 29);
            this.button2.TabIndex = 21;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(205, 495);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 50);
            this.button3.TabIndex = 22;
            this.button3.Text = "Stergere";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_Comment
            // 
            this.textBox_Comment.Location = new System.Drawing.Point(12, 292);
            this.textBox_Comment.Multiline = true;
            this.textBox_Comment.Name = "textBox_Comment";
            this.textBox_Comment.Size = new System.Drawing.Size(287, 184);
            this.textBox_Comment.TabIndex = 23;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(133, 495);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 34);
            this.button4.TabIndex = 24;
            this.button4.Text = "Pdf";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label_Nr
            // 
            this.label_Nr.AutoSize = true;
            this.label_Nr.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Nr.Location = new System.Drawing.Point(157, 12);
            this.label_Nr.Name = "label_Nr";
            this.label_Nr.Size = new System.Drawing.Size(22, 23);
            this.label_Nr.TabIndex = 26;
            this.label_Nr.Text = "...";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(118, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 23);
            this.label15.TabIndex = 25;
            this.label15.Text = "Nr:";
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataSource = typeof(SIGL_Cadastru.Repo.Models.Document);
            // 
            // panel_uc_doc
            // 
            this.panel_uc_doc.Location = new System.Drawing.Point(307, 224);
            this.panel_uc_doc.Name = "panel_uc_doc";
            this.panel_uc_doc.Size = new System.Drawing.Size(600, 150);
            this.panel_uc_doc.TabIndex = 27;
            // 
            // FormViewCerere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 550);
            this.Controls.Add(this.panel_uc_doc);
            this.Controls.Add(this.label_Nr);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox_Comment);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_adaugareStare);
            this.Controls.Add(this.label_StareCererii);
            this.Controls.Add(this.dataGridViewStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_pretTotal);
            this.Controls.Add(this.label_ValabilPanaLa);
            this.Controls.Add(this.label_valabilDeLa);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cerere";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormViewCerere_FormClosed);
            this.Load += new System.EventHandler(this.FormViewCerere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lucrareDtoBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerereStatusDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
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
        private BindingSource lucrareDtoBindingSource;
        private Label label_responsabil;
        private Label label_executant;
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
        private Button button1;
        private DataGridView dataGridViewStatus;
        private Label label_StareCererii;
        private Button button_adaugareStare;
        private DataGridViewTextBoxColumn createdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stareaDataGridViewTextBoxColumn;
        private BindingSource cerereStatusDtoBindingSource;
        private Button button_reset;
        private Button button2;
        private Button button3;
        private TextBox textBox_Comment;
        private Button button4;
        private Label label_Nr;
        private Label label15;
        private BindingSource documentBindingSource;
        private DataGridViewTextBoxColumn tipLucrareDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pretDataGridViewTextBoxColumn;
        private Panel panel_uc_doc;
    }
}