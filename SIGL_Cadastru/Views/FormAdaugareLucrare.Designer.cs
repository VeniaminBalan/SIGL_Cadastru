namespace SIGL_Cadastru.Views
{
    partial class FormAdaugareLucrare
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxPuncte = new System.Windows.Forms.GroupBox();
            this.labelNodeSelected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_suma = new System.Windows.Forms.Label();
            this.groupBoxPuncte.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(26, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(288, 368);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puncte: ";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(88, 35);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(34, 27);
            this.maskedTextBox1.TabIndex = 2;
            this.maskedTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            this.maskedTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Adaugare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxPuncte
            // 
            this.groupBoxPuncte.Controls.Add(this.label1);
            this.groupBoxPuncte.Controls.Add(this.maskedTextBox1);
            this.groupBoxPuncte.Location = new System.Drawing.Point(336, 25);
            this.groupBoxPuncte.Name = "groupBoxPuncte";
            this.groupBoxPuncte.Size = new System.Drawing.Size(177, 93);
            this.groupBoxPuncte.TabIndex = 4;
            this.groupBoxPuncte.TabStop = false;
            this.groupBoxPuncte.Visible = false;
            // 
            // labelNodeSelected
            // 
            this.labelNodeSelected.AutoSize = true;
            this.labelNodeSelected.Location = new System.Drawing.Point(336, 246);
            this.labelNodeSelected.Name = "labelNodeSelected";
            this.labelNodeSelected.Size = new System.Drawing.Size(0, 20);
            this.labelNodeSelected.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(336, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Suma: ";
            // 
            // label_suma
            // 
            this.label_suma.AutoSize = true;
            this.label_suma.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_suma.Location = new System.Drawing.Point(397, 317);
            this.label_suma.Name = "label_suma";
            this.label_suma.Size = new System.Drawing.Size(0, 19);
            this.label_suma.TabIndex = 7;
            // 
            // FormAdaugareLucrare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 418);
            this.Controls.Add(this.label_suma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNodeSelected);
            this.Controls.Add(this.groupBoxPuncte);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "FormAdaugareLucrare";
            this.Text = "FormAdaugareLucrare";
            this.groupBoxPuncte.ResumeLayout(false);
            this.groupBoxPuncte.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView treeView1;
        private Label label1;
        private MaskedTextBox maskedTextBox1;
        private Button button1;
        private GroupBox groupBoxPuncte;
        private Label labelNodeSelected;
        private Label label2;
        private Label label_suma;
    }
}