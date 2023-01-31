namespace _02_AdoNet
{
    partial class Form07ProcedimientoUpdatePlantilla
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHospitales = new System.Windows.Forms.ComboBox();
            this.btnSalario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstPlantilla = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hospitales";
            // 
            // comboBoxHospitales
            // 
            this.comboBoxHospitales.FormattingEnabled = true;
            this.comboBoxHospitales.Location = new System.Drawing.Point(31, 45);
            this.comboBoxHospitales.Name = "comboBoxHospitales";
            this.comboBoxHospitales.Size = new System.Drawing.Size(121, 23);
            this.comboBoxHospitales.TabIndex = 1;
            // 
            // btnSalario
            // 
            this.btnSalario.Location = new System.Drawing.Point(209, 27);
            this.btnSalario.Name = "btnSalario";
            this.btnSalario.Size = new System.Drawing.Size(104, 42);
            this.btnSalario.TabIndex = 2;
            this.btnSalario.Text = "Modificar salarios";
            this.btnSalario.UseVisualStyleBackColor = true;
            this.btnSalario.Click += new System.EventHandler(this.btnSalario_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plantilla";
            // 
            // lstPlantilla
            // 
            this.lstPlantilla.FormattingEnabled = true;
            this.lstPlantilla.ItemHeight = 15;
            this.lstPlantilla.Location = new System.Drawing.Point(31, 121);
            this.lstPlantilla.Name = "lstPlantilla";
            this.lstPlantilla.Size = new System.Drawing.Size(282, 94);
            this.lstPlantilla.TabIndex = 4;
            // 
            // Form07ProcedimientoUpdatePlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstPlantilla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalario);
            this.Controls.Add(this.comboBoxHospitales);
            this.Controls.Add(this.label1);
            this.Name = "Form07ProcedimientoUpdatePlantilla";
            this.Text = "Form07ProcedimientoUpdatePlantilla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboBoxHospitales;
        private Button btnSalario;
        private Label label2;
        private ListBox lstPlantilla;
    }
}