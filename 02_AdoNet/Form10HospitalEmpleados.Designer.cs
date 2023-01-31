namespace _02_AdoNet
{
    partial class Form10HospitalEmpleados
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
            this.txtPersonas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstPlantillaDoctores = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxHospitales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPersonas
            // 
            this.txtPersonas.Location = new System.Drawing.Point(163, 270);
            this.txtPersonas.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtPersonas.Name = "txtPersonas";
            this.txtPersonas.Size = new System.Drawing.Size(155, 32);
            this.txtPersonas.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 270);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Personas";
            // 
            // txtMedia
            // 
            this.txtMedia.Location = new System.Drawing.Point(163, 192);
            this.txtMedia.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(155, 32);
            this.txtMedia.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Media";
            // 
            // txtSuma
            // 
            this.txtSuma.Location = new System.Drawing.Point(163, 128);
            this.txtSuma.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.Size = new System.Drawing.Size(155, 32);
            this.txtSuma.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Suma";
            // 
            // lstPlantillaDoctores
            // 
            this.lstPlantillaDoctores.FormattingEnabled = true;
            this.lstPlantillaDoctores.ItemHeight = 25;
            this.lstPlantillaDoctores.Location = new System.Drawing.Point(423, 53);
            this.lstPlantillaDoctores.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lstPlantillaDoctores.Name = "lstPlantillaDoctores";
            this.lstPlantillaDoctores.Size = new System.Drawing.Size(246, 379);
            this.lstPlantillaDoctores.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Plantilla y Doctores";
            // 
            // comboBoxHospitales
            // 
            this.comboBoxHospitales.FormattingEnabled = true;
            this.comboBoxHospitales.Location = new System.Drawing.Point(22, 53);
            this.comboBoxHospitales.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBoxHospitales.Name = "comboBoxHospitales";
            this.comboBoxHospitales.Size = new System.Drawing.Size(221, 33);
            this.comboBoxHospitales.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Hospitales";
            // 
            // Form10HospitalEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 453);
            this.Controls.Add(this.txtPersonas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSuma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstPlantillaDoctores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxHospitales);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form10HospitalEmpleados";
            this.Text = "Form10HospitalEmpleados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtPersonas;
        private Label label5;
        private TextBox txtMedia;
        private Label label4;
        private TextBox txtSuma;
        private Label label3;
        private ListBox lstPlantillaDoctores;
        private Label label2;
        private ComboBox comboBoxHospitales;
        private Label label1;
    }
}