namespace _02_AdoNet
{
    partial class Ejer03_AccionDepartamento
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
            this.lstDepartamentos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstDepartamentos
            // 
            this.lstDepartamentos.FormattingEnabled = true;
            this.lstDepartamentos.ItemHeight = 15;
            this.lstDepartamentos.Location = new System.Drawing.Point(41, 62);
            this.lstDepartamentos.Name = "lstDepartamentos";
            this.lstDepartamentos.Size = new System.Drawing.Size(213, 169);
            this.lstDepartamentos.TabIndex = 0;
            this.lstDepartamentos.SelectedIndexChanged += new System.EventHandler(this.lstDepartamentos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Departamentos";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(280, 102);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(126, 32);
            this.btnCrear.TabIndex = 3;
            this.btnCrear.Text = "Crear departamento";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(467, 102);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(148, 32);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar departamento";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(280, 199);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(148, 32);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar departamento";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(376, 62);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.PlaceholderText = "Departamento";
            this.txtDepartamento.Size = new System.Drawing.Size(116, 23);
            this.txtDepartamento.TabIndex = 6;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(522, 62);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.PlaceholderText = "Localidad";
            this.txtLocalidad.Size = new System.Drawing.Size(93, 23);
            this.txtLocalidad.TabIndex = 7;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(280, 62);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(72, 23);
            this.txtId.TabIndex = 8;
            // 
            // Ejer03_AccionDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDepartamentos);
            this.Name = "Ejer03_AccionDepartamento";
            this.Text = "Ejer03_AccionDepartamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstDepartamentos;
        private Label label1;
        private Button btnCrear;
        private Button btnModificar;
        private Button btnEliminar;
        private TextBox txtDepartamento;
        private TextBox txtLocalidad;
        private TextBox txtId;
    }
}