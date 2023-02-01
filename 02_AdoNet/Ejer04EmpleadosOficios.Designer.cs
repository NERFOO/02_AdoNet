namespace _02_AdoNet
{
    partial class Ejer04EmpleadosOficios
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
            this.comboBoxOficios = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIncremento = new System.Windows.Forms.TextBox();
            this.btnIncremento = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstViewEmpleados = new System.Windows.Forms.ListView();
            this.Apellido = new System.Windows.Forms.ColumnHeader();
            this.Oficio = new System.Windows.Forms.ColumnHeader();
            this.Salario = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oficios";
            // 
            // comboBoxOficios
            // 
            this.comboBoxOficios.FormattingEnabled = true;
            this.comboBoxOficios.Location = new System.Drawing.Point(63, 102);
            this.comboBoxOficios.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxOficios.Name = "comboBoxOficios";
            this.comboBoxOficios.Size = new System.Drawing.Size(188, 33);
            this.comboBoxOficios.TabIndex = 1;
            this.comboBoxOficios.SelectedIndexChanged += new System.EventHandler(this.comboBoxOficios_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(292, 87);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(233, 60);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Incremento";
            // 
            // txtIncremento
            // 
            this.txtIncremento.Location = new System.Drawing.Point(556, 77);
            this.txtIncremento.Margin = new System.Windows.Forms.Padding(5);
            this.txtIncremento.Name = "txtIncremento";
            this.txtIncremento.Size = new System.Drawing.Size(207, 32);
            this.txtIncremento.TabIndex = 5;
            // 
            // btnIncremento
            // 
            this.btnIncremento.Location = new System.Drawing.Point(556, 125);
            this.btnIncremento.Margin = new System.Windows.Forms.Padding(5);
            this.btnIncremento.Name = "btnIncremento";
            this.btnIncremento.Size = new System.Drawing.Size(209, 48);
            this.btnIncremento.TabIndex = 6;
            this.btnIncremento.Text = "Incrementar";
            this.btnIncremento.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Empleados";
            // 
            // lstViewEmpleados
            // 
            this.lstViewEmpleados.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstViewEmpleados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Apellido,
            this.Oficio,
            this.Salario});
            this.lstViewEmpleados.FullRowSelect = true;
            this.lstViewEmpleados.Location = new System.Drawing.Point(49, 202);
            this.lstViewEmpleados.Margin = new System.Windows.Forms.Padding(5);
            this.lstViewEmpleados.Name = "lstViewEmpleados";
            this.lstViewEmpleados.Size = new System.Drawing.Size(716, 224);
            this.lstViewEmpleados.TabIndex = 8;
            this.lstViewEmpleados.UseCompatibleStateImageBehavior = false;
            this.lstViewEmpleados.View = System.Windows.Forms.View.Details;
            this.lstViewEmpleados.SelectedIndexChanged += new System.EventHandler(this.lstViewEmpleados_SelectedIndexChanged);
            // 
            // Apellido
            // 
            this.Apellido.Text = "APELLIDO";
            this.Apellido.Width = 150;
            // 
            // Oficio
            // 
            this.Oficio.Text = "OFICIO";
            this.Oficio.Width = 150;
            // 
            // Salario
            // 
            this.Salario.Text = "SALARIO";
            this.Salario.Width = 150;
            // 
            // Ejer04EmpleadosOficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 458);
            this.Controls.Add(this.lstViewEmpleados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnIncremento);
            this.Controls.Add(this.txtIncremento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.comboBoxOficios);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Ejer04EmpleadosOficios";
            this.Text = "Ejer04EmpleadosOficios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboBoxOficios;
        private Button btnEliminar;
        private Label label2;
        private TextBox txtIncremento;
        private Button btnIncremento;
        private Label label3;
        private ListView lstViewEmpleados;
        private ColumnHeader Apellido;
        private ColumnHeader Oficio;
        private ColumnHeader Salario;
    }
}