using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


#region PROCEDIMIENTOS ALMACENADOS
/*
 CREATE PROCEDURE SP_DEPARTAMENTOS
AS
	SELECT * FROM DEPT
GO
EXEC SP_DEPARTAMENTOS

ALTER PROCEDURE SP_INSERT_DEPARTAMENTO
(@NUM INT, @NOM NVARCHAR(50), @LOC NVARCHAR (50))
AS
	INSERT INTO DEPT VALUES (@NUM, @NOM, @LOC)
GO
 */
#endregion

namespace _02_AdoNet
{
    public partial class Form08MensajesServidor : Form
    {
        
        SqlCommand command;
        SqlConnection connection;
        SqlDataReader reader;

        public Form08MensajesServidor()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
            this.CargarDepartamentos();
        }

        private void CargarDepartamentos()
        {
            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_DEPARTAMENTOS";

            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            this.lstDepartamentos.Items.Clear();
            while(this.reader.Read())
            {
                string deptNum = this.reader["DEPT_NO"].ToString();
                string deptNom = this.reader["DNOMBRE"].ToString();
                string deptLoc = this.reader["LOC"].ToString();
                this.lstDepartamentos.Items.Add(deptNum + " - " + deptNom + " - " + deptLoc);
            }
            this.reader.Close();
            this.connection.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nom = this.txtNombre.Text;
            string loc = this.txtLocalidad.Text;

            SqlParameter paramId = new SqlParameter("@NUM", id);
            SqlParameter paramNom = new SqlParameter("@NOM", nom);
            SqlParameter paramLoc = new SqlParameter("@LOC", loc);

            this.command.Parameters.Add(paramId);
            this.command.Parameters.Add(paramNom);
            this.command.Parameters.Add(paramLoc);

            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_INSERT_DEPARTAMENTO";
            this.connection.Open();
            int resultado = this.command.ExecuteNonQuery();

            this.reader.Close();
            this.connection.Close();
            this.command.Parameters.Clear();

            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtLocalidad.Text = "";

            this.CargarDepartamentos();

            MessageBox.Show("Se han añadido " + resultado + " departamento");
        }
    }
}
