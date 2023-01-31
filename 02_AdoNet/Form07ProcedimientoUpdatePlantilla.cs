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
 ALTER PROCEDURE SP_HOSPITALES
AS
	SELECT * FROM HOSPITAL
GO


ALTER PROCEDURE SP_UPDATESALARIOSHOSPITAL (@NOMBRE NVARCHAR(50)) AS
    DECLARE @HOSPITALCOD INT
    DECLARE @SUMASALARIAL INT     SELECT @HOSPITALCOD = HOSPITAL_COD FROM HOSPITAL
    WHERE NOMBRE = @NOMBRE     SELECT @SUMASALARIAL = SUM(CONVERT(int,SALARIO)) FROM PLANTILLA 
    WHERE HOSPITAL_COD = @HOSPITALCOD     IF (@SUMASALARIAL > 1000000)
    BEGIN
        UPDATE PLANTILLA SET SALARIO = SALARIO - 10000
        WHERE HOSPITAL_COD = @HOSPITALCOD
        PRINT 'BAJANDO SALARIOS: ' + CAST(@SUMASALARIAL AS NVARCHAR)
    END
    ELSE
    BEGIN
        UPDATE PLANTILLA SET SALARIO = SALARIO + 10000
        WHERE HOSPITAL_COD = @HOSPITALCOD
        PRINT 'SUBIENDO SALARIOS: ' + CAST(@SUMASALARIAL AS NVARCHAR)
    END
	SELECT * FROM PLANTILLA WHERE HOSPITAL_COD = @HOSPITALCOD
GO
 */
#endregion

namespace _02_AdoNet
{
    public partial class Form07ProcedimientoUpdatePlantilla : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public Form07ProcedimientoUpdatePlantilla()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
            this.CargarHospitales();
        }

        private void CargarHospitales()
        {
            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_HOSPITALES";
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            this.comboBoxHospitales.Items.Clear();
            while(this.reader.Read())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.comboBoxHospitales.Items.Add(nombre);
            }
            this.reader.Close();
            this.connection.Close();
        }

        private void btnSalario_Click(object sender, EventArgs e)
        {
            string nombre = this.comboBoxHospitales.SelectedItem.ToString();
            SqlParameter paramNombre = new SqlParameter("@NOMBRE", nombre);
            this.command.Parameters.Add(paramNombre);
            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_UPDATESALARIOSHOSPITAL";
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            this.lstPlantilla.Items.Clear();
            while(this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                string funcion = this.reader["FUNCION"].ToString();
                string salario = this.reader["SALARIO"].ToString();
                this.lstPlantilla.Items.Add(apellido + ", " + funcion + ", " + salario);
            }
            this.reader.Close();
            this.connection.Close();
            this.command.Parameters.Clear();
        }
    }
}
