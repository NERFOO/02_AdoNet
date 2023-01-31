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

#region PROCEDURES
/*
CREATE PROCEDURE SP_DEPARTAMENTOS
AS
	SELECT * FROM DEPT
GO
EXEC SP_DEPARTAMENTOS


ALTER PROCEDURE SP_EMPLEADOS (@NOMBRE NVARCHAR(50))
AS
	SELECT * FROM EMP
	INNER JOIN DEPT
	ON EMP.DEPT_NO = DEPT.DEPT_NO
	WHERE DNOMBRE = @NOMBRE
GO


ATERNATIVA
CREATE PROCEDURE SP_EMPLEADOS_DEPARTAMENTO
(@NOMBRE NVARCHAR(50)) AS
	DECLARE @IDDEPARTAMENTO INT
	SELECT @IDDEPARTAMENTO = DEPT_NO FROM DEPT
	WHERE DNOMBRE = @NOMBRE
	SELECT * FROM EMP WHERE DEPT_NO=@IDDEPARTAMENTO
GO

MEJORA PARA LA SUMA MEDIA Y DEMAS
CREATE PROCEDURE SP_EMPLEADOS_DEPARTAMENTO
(@NOMBRE NVARCHAR(50), @SUMA INT OUT, @MEDIA INT OUT, @PERSONAS INT OUT) AS
	DECLARE @IDDEPARTAMENTO INT
	SELECT @IDDEPARTAMENTO = DEPT_NO FROM DEPT
	WHERE DNOMBRE = @NOMBRE
	SELECT * FROM EMP WHERE DEPT_NO=@IDDEPARTAMENTO
	SELECT @SUMA = SUM(SALARIO), @MEDIA = AVG(SALARIO), @PERSONAS = COUNT(EMP_NO) FROM EMP
	WHERE DEPT_NO = @IDDEPARTAMENTO
GO
 */
#endregion

namespace _02_AdoNet
{
    public partial class Form09ParametrosSalida : Form
    {

        SqlCommand command;
        SqlConnection connection;
        SqlDataReader reader;

        public Form09ParametrosSalida()
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
            this.comboBoxDepartamentos.Items.Clear();
            while (this.reader.Read())
            {
                string deptNom = this.reader["DNOMBRE"].ToString();
                this.comboBoxDepartamentos.Items.Add(deptNom);
            }
            this.reader.Close();
            this.connection.Close();
        }

        private void CargarEmpleados()
        {
            //DECLARAMOS LOS PARAMETROS DE SALIDA
            SqlParameter pamsuma = new SqlParameter();
            pamsuma.ParameterName = "@SUMA";
            pamsuma.Value = 0;
            pamsuma.Direction = ParameterDirection.Output;
            this.command.Parameters.Add(pamsuma);
            SqlParameter pammedia = new SqlParameter();
            pammedia.ParameterName = "@MEDIA";
            pammedia.Value = 0;
            pammedia.Direction = ParameterDirection.Output;
            this.command.Parameters.Add(pammedia);
            SqlParameter pampersonas = new SqlParameter();
            pampersonas.ParameterName = "@PERSONAS";
            pampersonas.Value = 0;
            pampersonas.Direction = ParameterDirection.Output;
            this.command.Parameters.Add(pampersonas);

            string nombreDept = this.comboBoxDepartamentos.SelectedItem.ToString();

            SqlParameter paramNom = new SqlParameter("@NOMBRE", nombreDept);

            this.command.Parameters.Add(paramNom);

            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_EMPLEADOS_DEPARTAMENTO";
            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            this.lstEmpleados.Items.Clear();

            while (this.reader.Read())
            {
                string deptNom = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(deptNom);
            }

            this.reader.Close();
            
            this.txtSuma.Text = pamsuma.Value.ToString();
            this.txtMedia.Text = pammedia.Value.ToString();
            this.txtPersonas.Text = pampersonas.Value.ToString();

            this.connection.Close();
            this.command.Parameters.Clear();
        }

        private void comboBoxDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarEmpleados();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }
    }
}
