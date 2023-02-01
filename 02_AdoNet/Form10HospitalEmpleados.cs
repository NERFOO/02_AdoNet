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
using Microsoft.Extensions.Configuration;
using _02_AdoNet.Helpers;

#region
/*
 ALTER PROCEDURE SP_HOSPITALES
    AS
	    SELECT * FROM HOSPITAL
    GO

 */
#endregion

namespace _02_AdoNet
{
    public partial class Form10HospitalEmpleados : Form
    {

        SqlCommand command;
        SqlConnection connection;
        SqlDataReader reader;

        public Form10HospitalEmpleados()
        {

            InitializeComponent();
            //string connectionStringCasa = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
            //string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";

            //ESTA VARIABLE IRIA EN LA CONEXION SI NO SE IMPLEMENTA DIRECTAMENTE
            //string connectionString = HelperConfiguration.GetConnectionString();
            this.connection = new SqlConnection(HelperConfiguration.GetConnectionString());
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
            while (this.reader.Read())
            {
                string deptNom = this.reader["NOMBRE"].ToString();
                this.comboBoxHospitales.Items.Add(deptNom);
            }
            this.reader.Close();
            this.connection.Close();
        }

        private void comboBoxHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DECLARAMOS LOS PARAMETROS DE SALIDA
            SqlParameter pamsuma = new SqlParameter();
            pamsuma.ParameterName = "@SUMA";
            pamsuma.Value = 0;
            pamsuma.Direction = ParameterDirection.Output;
            this.command.Parameters.Add(pamsuma);

            SqlParameter pammedia = new SqlParameter("@MEDIA", 0);
            pammedia.Direction = ParameterDirection.Output;
            this.command.Parameters.Add(pammedia);

            SqlParameter pampersonas = new SqlParameter();
            pampersonas.ParameterName = "@PERSONAS";
            pampersonas.Value = 0;
            pampersonas.Direction = ParameterDirection.Output;
            this.command.Parameters.Add(pampersonas);


            string hospital = this.comboBoxHospitales.SelectedItem.ToString();

            SqlParameter paramHospital = new SqlParameter("@NOM", hospital);
            this.command.Parameters.Add(paramHospital);

            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_EMPLEADOS_HOSPITAL";

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            this.lstPlantillaDoctores.Items.Clear();

            while(this.reader.Read())
            {
                string trabajador = this.reader["APELLIDO"].ToString();
                string salario = this.reader["SALARIO"].ToString();

                this.lstPlantillaDoctores.Items.Add(trabajador + " - " + salario);
            }
            this.reader.Close();

            this.txtSuma.Text = pamsuma.Value.ToString();
            this.txtMedia.Text = pammedia.Value.ToString();
            this.txtPersonas.Text = pampersonas.Value.ToString();

            this.connection.Close();
            this.command.Parameters.Clear();
        }
    }
}
