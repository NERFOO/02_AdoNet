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

        public Ejer02_DepartamentosEmpleados()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
            string connectionStringCasa = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";

            this.connection = new SqlConnection(connectionStringCasa);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
            this.CargarDepartamentos();
        }

        private void CargarDepartamentos()
        {
            string consulta = "SELECT DNOMBRE FROM DEPT";

            this.connection.Open();
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.reader = this.command.ExecuteReader();

            this.lstDepartamentos.Items.Clear();

            while(this.reader.Read())
            {
                string departamento = this.reader["DNOMBRE"].ToString();
                this.lstDepartamentos.Items.Add(departamento);
            }

            this.reader.Close();
            this.connection.Close();
        }

        private void CargarEmpleado()
        {
            string nomDept = this.lstDepartamentos.SelectedItem.ToString();
            string consulta = "SELECT EMP.APELLIDO FROM EMP INNER JOIN DEPT ON EMP.DEPT_NO = DEPT.DEPT_NO WHERE DEPT.DNOMBRE = @NOM_DEPT";

            SqlParameter num_dept = new SqlParameter("@NOM_DEPT", nomDept);
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

            this.reader.Close();
            this.connection.Close();
            this.command.Parameters.Clear();
        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarEmpleado();
        }

        private void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string apellido = this.lstEmpleados.SelectedItem.ToString();
            string consulta = "SELECT OFICIO, SALARIO FROM EMP WHERE APELLIDO = @APELLIDO";
            SqlParameter paramApellido = new SqlParameter("@APELLIDO", apellido);
            this.command.Parameters.Add(paramApellido);
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            while(this.reader.Read())
            {
                this.txtOficio.Text = this.reader["OFICIO"].ToString();
                this.txtSalario.Text = this.reader["SALARIO"].ToString();
            }
            this.connection.Close();
            this.reader.Close();
            this.command.Parameters.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string apellido = this.lstEmpleados.SelectedItem.ToString();
            string oficio = this.txtOficio.Text;
            int salario = int.Parse(this.txtSalario.Text);
            string consulta = "UPDATE EMP SET OFICIO = @OFICIO, SALARIO = @SALARIO WHERE APELLIDO = @APELLIDO";

            SqlParameter paramApellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter paramOficio = new SqlParameter("@OFICIO", oficio);
            SqlParameter paramSalario = new SqlParameter("@SALARIO", salario);

            this.command.Parameters.Add(paramApellido);
            this.command.Parameters.Add(paramOficio);
            this.command.Parameters.Add(paramSalario);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;
            this.connection.Open();

            this.command.ExecuteNonQuery();

            this.connection.Close();
            this.command.Parameters.Clear();
            MessageBox.Show("Se han actualizado los datos");
        }
    }
}
