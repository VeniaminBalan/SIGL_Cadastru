namespace SIGL_Cadastru.Views
{
    partial class UC_DocumentsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.denumireaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mentiuniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exemplareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 

            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.AllowUserToAddRows = true;
            this.dataGridView1.AllowUserToDeleteRows = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.denumireaDataGridViewTextBoxColumn,
            this.nrDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.mentiuniDataGridViewTextBoxColumn,
            this.exemplareDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.documentBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(600, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // denumireaDataGridViewTextBoxColumn
            // 
            this.denumireaDataGridViewTextBoxColumn.DataPropertyName = "Denumirea";
            this.denumireaDataGridViewTextBoxColumn.HeaderText = "Denumirea";
            this.denumireaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.denumireaDataGridViewTextBoxColumn.Name = "denumireaDataGridViewTextBoxColumn";
            this.denumireaDataGridViewTextBoxColumn.Width = 200;
            // 
            // nrDataGridViewTextBoxColumn
            // 
            this.nrDataGridViewTextBoxColumn.DataPropertyName = "Nr";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nrDataGridViewTextBoxColumn.HeaderText = "Nr";
            this.nrDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nrDataGridViewTextBoxColumn.Name = "nrDataGridViewTextBoxColumn";
            this.nrDataGridViewTextBoxColumn.Width = 50;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.dataDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.Width = 85;
            // 
            // mentiuniDataGridViewTextBoxColumn
            // 
            this.mentiuniDataGridViewTextBoxColumn.DataPropertyName = "Mentiuni";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mentiuniDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.mentiuniDataGridViewTextBoxColumn.HeaderText = "Mentiuni";
            this.mentiuniDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mentiuniDataGridViewTextBoxColumn.Name = "mentiuniDataGridViewTextBoxColumn";
            this.mentiuniDataGridViewTextBoxColumn.Width = 120;
            // 
            // exemplareDataGridViewTextBoxColumn
            // 
            this.exemplareDataGridViewTextBoxColumn.DataPropertyName = "Exemplare";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.exemplareDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.exemplareDataGridViewTextBoxColumn.HeaderText = "Exemplare";
            this.exemplareDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.exemplareDataGridViewTextBoxColumn.Name = "exemplareDataGridViewTextBoxColumn";
            this.exemplareDataGridViewTextBoxColumn.Width = 90;
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataSource = typeof(SIGL_Cadastru.Repo.Models.Document);
            // 
            // UC_DocumentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "UC_DocumentsView";
            this.Size = new System.Drawing.Size(600, 150);
            this.Load += new System.EventHandler(this.UC_DocumentsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BindingSource documentBindingSource;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn denumireaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nrDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mentiuniDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn exemplareDataGridViewTextBoxColumn;
    }
}
