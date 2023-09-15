namespace SIGL_Cadastru.Views
{
    partial class UC_Main
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cerereDtoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cerereDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.maskedTextBox_panaLa = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox_inceput = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_Eliberat = new System.Windows.Forms.CheckBox();
            this.checkBox_Respins = new System.Windows.Forms.CheckBox();
            this.checkBox_laReceptie = new System.Windows.Forms.CheckBox();
            this.checkBox_inLucru = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsabil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrCadastral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valabilDeLa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valabilPanaLa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prelungit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stareaCererii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laReceptie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.respins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliberat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerereDtoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerereDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nr,
            this.client,
            this.executant,
            this.responsabil,
            this.nrCadastral,
            this.valabilDeLa,
            this.valabilPanaLa,
            this.prelungit,
            this.stareaCererii,
            this.laReceptie,
            this.respins,
            this.eliberat});
            this.dataGridView1.DataSource = this.cerereDtoBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1507, 528);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // cerereDtoBindingSource1
            // 
            this.cerereDtoBindingSource1.DataSource = typeof(SIGL_Cadastru.App.Entities.CerereDto);
            // 
            // cerereDtoBindingSource
            // 
            this.cerereDtoBindingSource.DataSource = typeof(SIGL_Cadastru.App.Entities.CerereDto);
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
            this.splitContainer1.Panel1.Controls.Add(this.maskedTextBox_panaLa);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.maskedTextBox_inceput);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_Eliberat);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_Respins);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_laReceptie);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_inLucru);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1678, 530);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 1;
            // 
            // maskedTextBox_panaLa
            // 
            this.maskedTextBox_panaLa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox_panaLa.Location = new System.Drawing.Point(13, 332);
            this.maskedTextBox_panaLa.Mask = "00-00-0000";
            this.maskedTextBox_panaLa.Name = "maskedTextBox_panaLa";
            this.maskedTextBox_panaLa.Size = new System.Drawing.Size(96, 30);
            this.maskedTextBox_panaLa.TabIndex = 10;
            this.maskedTextBox_panaLa.TextChanged += new System.EventHandler(this.maskedTextBox_panaLa_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pana la:";
            // 
            // maskedTextBox_inceput
            // 
            this.maskedTextBox_inceput.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox_inceput.Location = new System.Drawing.Point(13, 270);
            this.maskedTextBox_inceput.Mask = "00-00-0000";
            this.maskedTextBox_inceput.Name = "maskedTextBox_inceput";
            this.maskedTextBox_inceput.Size = new System.Drawing.Size(96, 30);
            this.maskedTextBox_inceput.TabIndex = 8;
            this.maskedTextBox_inceput.TextChanged += new System.EventHandler(this.maskedTextBox_inceput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Valabil incepand cu:";
            // 
            // checkBox_Eliberat
            // 
            this.checkBox_Eliberat.AutoSize = true;
            this.checkBox_Eliberat.Checked = true;
            this.checkBox_Eliberat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Eliberat.Location = new System.Drawing.Point(13, 204);
            this.checkBox_Eliberat.Name = "checkBox_Eliberat";
            this.checkBox_Eliberat.Size = new System.Drawing.Size(82, 24);
            this.checkBox_Eliberat.TabIndex = 6;
            this.checkBox_Eliberat.Text = "Eliberat";
            this.checkBox_Eliberat.UseVisualStyleBackColor = true;
            this.checkBox_Eliberat.CheckedChanged += new System.EventHandler(this.checkBox_Eliberat_CheckedChanged);
            // 
            // checkBox_Respins
            // 
            this.checkBox_Respins.AutoSize = true;
            this.checkBox_Respins.Checked = true;
            this.checkBox_Respins.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Respins.Location = new System.Drawing.Point(13, 174);
            this.checkBox_Respins.Name = "checkBox_Respins";
            this.checkBox_Respins.Size = new System.Drawing.Size(81, 24);
            this.checkBox_Respins.TabIndex = 5;
            this.checkBox_Respins.Text = "Respins";
            this.checkBox_Respins.UseVisualStyleBackColor = true;
            this.checkBox_Respins.CheckedChanged += new System.EventHandler(this.checkBox_Eliberat_CheckedChanged);
            // 
            // checkBox_laReceptie
            // 
            this.checkBox_laReceptie.AutoSize = true;
            this.checkBox_laReceptie.Checked = true;
            this.checkBox_laReceptie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_laReceptie.Location = new System.Drawing.Point(13, 145);
            this.checkBox_laReceptie.Name = "checkBox_laReceptie";
            this.checkBox_laReceptie.Size = new System.Drawing.Size(108, 24);
            this.checkBox_laReceptie.TabIndex = 4;
            this.checkBox_laReceptie.Text = "La Receptie";
            this.checkBox_laReceptie.UseVisualStyleBackColor = true;
            this.checkBox_laReceptie.CheckedChanged += new System.EventHandler(this.checkBox_Eliberat_CheckedChanged);
            // 
            // checkBox_inLucru
            // 
            this.checkBox_inLucru.AutoSize = true;
            this.checkBox_inLucru.Checked = true;
            this.checkBox_inLucru.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_inLucru.Location = new System.Drawing.Point(13, 115);
            this.checkBox_inLucru.Name = "checkBox_inLucru";
            this.checkBox_inLucru.Size = new System.Drawing.Size(82, 24);
            this.checkBox_inLucru.TabIndex = 3;
            this.checkBox_inLucru.Text = "In Lucru";
            this.checkBox_inLucru.UseVisualStyleBackColor = true;
            this.checkBox_inLucru.CheckedChanged += new System.EventHandler(this.checkBox_Eliberat_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Nr",
            "Client",
            "Responsabil",
            "Executant",
            "Nr Cadastral",
            "Comentariu"});
            this.comboBox1.Location = new System.Drawing.Point(3, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cautare:";
            // 
            // Nr
            // 
            this.Nr.DataPropertyName = "Nr";
            this.Nr.HeaderText = "Nr";
            this.Nr.MinimumWidth = 6;
            this.Nr.Name = "Nr";
            this.Nr.ReadOnly = true;
            this.Nr.Width = 125;
            // 
            // client
            // 
            this.client.DataPropertyName = "Client";
            this.client.HeaderText = "Client";
            this.client.MinimumWidth = 6;
            this.client.Name = "client";
            this.client.ReadOnly = true;
            this.client.Width = 125;
            // 
            // executant
            // 
            this.executant.DataPropertyName = "Executant";
            this.executant.HeaderText = "Executant";
            this.executant.MinimumWidth = 6;
            this.executant.Name = "executant";
            this.executant.ReadOnly = true;
            this.executant.Width = 125;
            // 
            // responsabil
            // 
            this.responsabil.DataPropertyName = "Responsabil";
            this.responsabil.HeaderText = "Responsabil";
            this.responsabil.MinimumWidth = 6;
            this.responsabil.Name = "responsabil";
            this.responsabil.ReadOnly = true;
            this.responsabil.Width = 125;
            // 
            // nrCadastral
            // 
            this.nrCadastral.DataPropertyName = "NrCadastral";
            this.nrCadastral.HeaderText = "Nr Cadastral";
            this.nrCadastral.MinimumWidth = 6;
            this.nrCadastral.Name = "nrCadastral";
            this.nrCadastral.ReadOnly = true;
            this.nrCadastral.Width = 125;
            // 
            // valabilDeLa
            // 
            this.valabilDeLa.DataPropertyName = "ValabilDeLa";
            this.valabilDeLa.HeaderText = "Valabil de la";
            this.valabilDeLa.MinimumWidth = 6;
            this.valabilDeLa.Name = "valabilDeLa";
            this.valabilDeLa.ReadOnly = true;
            this.valabilDeLa.Width = 125;
            // 
            // valabilPanaLa
            // 
            this.valabilPanaLa.DataPropertyName = "ValabilPanaLa";
            this.valabilPanaLa.HeaderText = "Valabil pana la";
            this.valabilPanaLa.MinimumWidth = 6;
            this.valabilPanaLa.Name = "valabilPanaLa";
            this.valabilPanaLa.ReadOnly = true;
            this.valabilPanaLa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.valabilPanaLa.Width = 140;
            // 
            // prelungit
            // 
            this.prelungit.DataPropertyName = "Prelungit";
            this.prelungit.HeaderText = "Prelungit";
            this.prelungit.MinimumWidth = 6;
            this.prelungit.Name = "prelungit";
            this.prelungit.ReadOnly = true;
            this.prelungit.Width = 125;
            // 
            // stareaCererii
            // 
            this.stareaCererii.DataPropertyName = "StareaCererii";
            this.stareaCererii.HeaderText = "Starea Cererii";
            this.stareaCererii.MinimumWidth = 6;
            this.stareaCererii.Name = "stareaCererii";
            this.stareaCererii.ReadOnly = true;
            this.stareaCererii.Width = 125;
            // 
            // laReceptie
            // 
            this.laReceptie.DataPropertyName = "LaReceptie";
            this.laReceptie.HeaderText = "La Receptie";
            this.laReceptie.MinimumWidth = 6;
            this.laReceptie.Name = "laReceptie";
            this.laReceptie.ReadOnly = true;
            this.laReceptie.Width = 125;
            // 
            // respins
            // 
            this.respins.DataPropertyName = "Respins";
            this.respins.HeaderText = "Respins";
            this.respins.MinimumWidth = 6;
            this.respins.Name = "respins";
            this.respins.ReadOnly = true;
            this.respins.Width = 125;
            // 
            // eliberat
            // 
            this.eliberat.DataPropertyName = "Eliberat";
            this.eliberat.HeaderText = "Eliberat";
            this.eliberat.MinimumWidth = 6;
            this.eliberat.Name = "eliberat";
            this.eliberat.ReadOnly = true;
            this.eliberat.Width = 125;
            // 
            // UC_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UC_Main";
            this.Size = new System.Drawing.Size(1678, 530);
            this.Load += new System.EventHandler(this.UC_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerereDtoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerereDtoBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn costTotalDataGridViewTextBoxColumn;
        private BindingSource cerereDtoBindingSource;
        private SplitContainer splitContainer1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label1;
        private CheckBox checkBox_Eliberat;
        private CheckBox checkBox_Respins;
        private CheckBox checkBox_laReceptie;
        private CheckBox checkBox_inLucru;
        private BindingSource cerereDtoBindingSource1;
        private Label label2;
        private MaskedTextBox maskedTextBox_panaLa;
        private Label label3;
        private MaskedTextBox maskedTextBox_inceput;
        private DataGridViewTextBoxColumn Nr;
        private DataGridViewTextBoxColumn client;
        private DataGridViewTextBoxColumn executant;
        private DataGridViewTextBoxColumn responsabil;
        private DataGridViewTextBoxColumn nrCadastral;
        private DataGridViewTextBoxColumn valabilDeLa;
        private DataGridViewTextBoxColumn valabilPanaLa;
        private DataGridViewTextBoxColumn prelungit;
        private DataGridViewTextBoxColumn stareaCererii;
        private DataGridViewTextBoxColumn laReceptie;
        private DataGridViewTextBoxColumn respins;
        private DataGridViewTextBoxColumn eliberat;
    }
}
