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
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
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
            while (this.reader.Read())
            {
                string deptNom = this.reader["NOMBRE"].ToString();
                this.comboBoxHospitales.Items.Add(deptNom);
            }
            this.reader.Close();
            this.connection.Close();
        }
    }
}
