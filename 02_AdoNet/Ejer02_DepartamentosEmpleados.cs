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

namespace _02_AdoNet
{
    public partial class Ejer02_DepartamentosEmpleados : Form
    {

        SqlCommand command;
        SqlConnection connection;
        SqlDataReader reader;
        int numDepartamento;

        public Ejer02_DepartamentosEmpleados()
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
            string consulta = "SELECT DNOMBRE, DEPT_NO FROM DEPT";

            this.connection.Open();
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.reader = this.command.ExecuteReader();

            this.lstDepartamentos.Items.Clear();

            while(this.reader.Read())
            {
                string departamento = this.reader["DNOMBRE"].ToString();
                numDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
                this.lstDepartamentos.Items.Add(departamento);
            }

            this.reader.Close();
            this.connection.Close();
        }

        private void CargarEmpleado()
        {
            string consulta = "SELECT APELLIDO FROM EMP WHERE DEPT_NO = @no_dept";

            SqlParameter num_dept = new SqlParameter("@no_dept", this.numDepartamento);
            this.command.Parameters.Add(num_dept);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();

            this.reader = this.command.ExecuteReader();

            this.lstEmpleados.Items.Clear();

            while(this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(apellido);
            }

            this.command.Parameters.Clear();
            this.reader.Close();
            this.connection.Close();

        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarEmpleado();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
