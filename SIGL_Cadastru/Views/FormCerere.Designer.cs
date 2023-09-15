namespace SIGL_Cadastru.Views
{
    partial class FormCerere
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
            this.button_Vizualizare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_NrCadasrtral = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxLucrari = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label_suma = new System.Windows.Forms.Label();
            this.label_modificator = new System.Windows.Forms.Label();
            this.textBox_adaos = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker_dataSolicitarii = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_termen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Executant = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Responsabil = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelUC = new System.Windows.Forms.Panel();
            this.buttonPNoua = new System.Windows.Forms.Button();
            this.buttonPExistenta = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_comment = new System.Windows.Forms.TextBox();
            this.comboBox_transport = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_UC_Documente = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Vizualizare
            // 
            this.button_Vizualizare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Vizualizare.Location = new System.Drawing.Point(349, 643);
            this.button_Vizualizare.Name = "button_Vizualizare";
            this.button_Vizualizare.Size = new System.Drawing.Size(109, 39);
            this.button_Vizualizare.TabIndex = 2;
            this.button_Vizualizare.Text = "Creare";
            this.button_Vizualizare.UseVisualStyleBackColor = true;
            this.button_Vizualizare.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(427, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cerere";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nr. cadastral";
            // 
            // maskedTextBox_NrCadasrtral
            // 
            this.maskedTextBox_NrCadasrtral.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox_NrCadasrtral.Location = new System.Drawing.Point(143, 22);
            this.maskedTextBox_NrCadasrtral.Mask = "00-00-0-00-0000";
            this.maskedTextBox_NrCadasrtral.Name = "maskedTextBox_NrCadasrtral";
            this.maskedTextBox_NrCadasrtral.Size = new System.Drawing.Size(133, 28);
            this.maskedTextBox_NrCadasrtral.TabIndex = 5;
            this.maskedTextBox_NrCadasrtral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(22, 268);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 19);
            this.label14.TabIndex = 22;
            this.label14.Text = "Rog sa efectuati:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(186, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 39);
            this.button1.TabIndex = 23;
            this.button1.Text = "Adaugare Serviciu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_AdaugareServiciu_Click);
            // 
            // listBoxLucrari
            // 
            this.listBoxLucrari.FormattingEnabled = true;
            this.listBoxLucrari.ItemHeight = 20;
            this.listBoxLucrari.Location = new System.Drawing.Point(22, 293);
            this.listBoxLucrari.Name = "listBoxLucrari";
            this.listBoxLucrari.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLucrari.Size = new System.Drawing.Size(339, 104);
            this.listBoxLucrari.TabIndex = 24;
            this.listBoxLucrari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxLucrari_KeyPress);
            this.listBoxLucrari.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxLucrari_KeyUp);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(61, 587);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 19);
            this.label16.TabIndex = 27;
            this.label16.Text = "Transport:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(710, 647);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 25);
            this.label15.TabIndex = 30;
            this.label15.Text = "Suma: ";
            // 
            // label_suma
            // 
            this.label_suma.AutoSize = true;
            this.label_suma.Location = new System.Drawing.Point(809, 652);
            this.label_suma.Name = "label_suma";
            this.label_suma.Size = new System.Drawing.Size(0, 20);
            this.label_suma.TabIndex = 31;
            // 
            // label_modificator
            // 
            this.label_modificator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_modificator.AutoSize = true;
            this.label_modificator.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_modificator.Location = new System.Drawing.Point(61, 625);
            this.label_modificator.Name = "label_modificator";
            this.label_modificator.Size = new System.Drawing.Size(67, 22);
            this.label_modificator.TabIndex = 32;
            this.label_modificator.Text = "Adaos:";
            // 
            // textBox_adaos
            // 
            this.textBox_adaos.Location = new System.Drawing.Point(145, 623);
            this.textBox_adaos.Name = "textBox_adaos";
            this.textBox_adaos.Size = new System.Drawing.Size(66, 27);
            this.textBox_adaos.TabIndex = 33;
            this.textBox_adaos.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker_dataSolicitarii);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox_termen);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_Executant);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox_Responsabil);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(22, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 163);
            this.panel1.TabIndex = 34;
            // 
            // dateTimePicker_dataSolicitarii
            // 
            this.dateTimePicker_dataSolicitarii.Location = new System.Drawing.Point(121, 89);
            this.dateTimePicker_dataSolicitarii.Name = "dateTimePicker_dataSolicitarii";
            this.dateTimePicker_dataSolicitarii.Size = new System.Drawing.Size(208, 27);
            this.dateTimePicker_dataSolicitarii.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "zile";
            // 
            // textBox_termen
            // 
            this.textBox_termen.Location = new System.Drawing.Point(121, 124);
            this.textBox_termen.Name = "textBox_termen";
            this.textBox_termen.Size = new System.Drawing.Size(70, 27);
            this.textBox_termen.TabIndex = 7;
            this.textBox_termen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Termen:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data Solicitarii:";
            // 
            // comboBox_Executant
            // 
            this.comboBox_Executant.FormattingEnabled = true;
            this.comboBox_Executant.Location = new System.Drawing.Point(121, 53);
            this.comboBox_Executant.Name = "comboBox_Executant";
            this.comboBox_Executant.Size = new System.Drawing.Size(151, 28);
            this.comboBox_Executant.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Executant:";
            // 
            // comboBox_Responsabil
            // 
            this.comboBox_Responsabil.FormattingEnabled = true;
            this.comboBox_Responsabil.Location = new System.Drawing.Point(121, 17);
            this.comboBox_Responsabil.Name = "comboBox_Responsabil";
            this.comboBox_Responsabil.Size = new System.Drawing.Size(151, 28);
            this.comboBox_Responsabil.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Responsabil:";
            // 
            // panelUC
            // 
            this.panelUC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelUC.Location = new System.Drawing.Point(519, 112);
            this.panelUC.Name = "panelUC";
            this.panelUC.Size = new System.Drawing.Size(450, 250);
            this.panelUC.TabIndex = 35;
            // 
            // buttonPNoua
            // 
            this.buttonPNoua.Location = new System.Drawing.Point(519, 71);
            this.buttonPNoua.Name = "buttonPNoua";
            this.buttonPNoua.Size = new System.Drawing.Size(162, 41);
            this.buttonPNoua.TabIndex = 36;
            this.buttonPNoua.Text = "Client Nou";
            this.buttonPNoua.UseVisualStyleBackColor = true;
            this.buttonPNoua.Click += new System.EventHandler(this.buttonPNoua_Click);
            // 
            // buttonPExistenta
            // 
            this.buttonPExistenta.Location = new System.Drawing.Point(687, 71);
            this.buttonPExistenta.Name = "buttonPExistenta";
            this.buttonPExistenta.Size = new System.Drawing.Size(162, 41);
            this.buttonPExistenta.TabIndex = 37;
            this.buttonPExistenta.Text = "Client Existent";
            this.buttonPExistenta.UseVisualStyleBackColor = true;
            this.buttonPExistenta.Click += new System.EventHandler(this.buttonPExistenta_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(22, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 22);
            this.label8.TabIndex = 38;
            this.label8.Text = "Comentariu:";
            // 
            // textBox_comment
            // 
            this.textBox_comment.Location = new System.Drawing.Point(22, 437);
            this.textBox_comment.Multiline = true;
            this.textBox_comment.Name = "textBox_comment";
            this.textBox_comment.Size = new System.Drawing.Size(339, 104);
            this.textBox_comment.TabIndex = 39;
            // 
            // comboBox_transport
            // 
            this.comboBox_transport.FormattingEnabled = true;
            this.comboBox_transport.Location = new System.Drawing.Point(145, 582);
            this.comboBox_transport.Name = "comboBox_transport";
            this.comboBox_transport.Size = new System.Drawing.Size(151, 28);
            this.comboBox_transport.TabIndex = 40;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(483, 642);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 39);
            this.button2.TabIndex = 41;
            this.button2.Text = "Vizualizare";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button_vizualizare_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(369, 412);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 22);
            this.label9.TabIndex = 42;
            this.label9.Text = "Documente:";
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataSource = typeof(SIGL_Cadastru.Repo.Models.Document);
            // 
            // panel_UC_Documente
            // 
            this.panel_UC_Documente.Location = new System.Drawing.Point(369, 437);
            this.panel_UC_Documente.Name = "panel_UC_Documente";
            this.panel_UC_Documente.Size = new System.Drawing.Size(600, 150);
            this.panel_UC_Documente.TabIndex = 43;
            // 
            // FormCerere
            // 
            this.AcceptButton = this.button_Vizualizare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.panel_UC_Documente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox_transport);
            this.Controls.Add(this.textBox_comment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonPExistenta);
            this.Controls.Add(this.buttonPNoua);
            this.Controls.Add(this.panelUC);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_adaos);
            this.Controls.Add(this.label_modificator);
            this.Controls.Add(this.label_suma);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.listBoxLucrari);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.maskedTextBox_NrCadasrtral);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Vizualizare);
            this.MaximumSize = new System.Drawing.Size(1000, 750);
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "FormCerere";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cerere Noua";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCerere_FormClosed);
            this.Load += new System.EventHandler(this.FormCerere_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button_Vizualizare;
        private Label label1;
        private Label label2;
        private MaskedTextBox maskedTextBox_NrCadasrtral;
        private Label label14;
        private Button button1;
        private ListBox listBoxLucrari;
        private Label label16;
        private Label label15;
        private Label label_suma;
        private Label label_modificator;
        private TextBox textBox_adaos;
        private Panel panel1;
        private ComboBox comboBox_Executant;
        private Label label4;
        private ComboBox comboBox_Responsabil;
        private Label label3;
        private Panel panelUC;
        private Button buttonPNoua;
        private Button buttonPExistenta;
        private Label label6;
        private Label label5;
        private TextBox textBox_termen;
        private Label label7;
        private DateTimePicker dateTimePicker_dataSolicitarii;
        private Label label8;
        private TextBox textBox_comment;
        private ComboBox comboBox_transport;
        private Button button2;
        private Label label9;
        private BindingSource documentBindingSource;
        private Panel panel_UC_Documente;
    }
}