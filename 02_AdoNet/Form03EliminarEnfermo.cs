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
using System.Diagnostics;

namespace _02_AdoNet
{
    public partial class Form03EliminarEnfermo : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Form03EliminarEnfermo()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
            
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadEnfermos();
        }

        private void LoadEnfermos()
        {
            string sql = "select * from enfermo";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEnfermos.Items.Clear();
            while(this.reader.Read())
            {
                string inscripcion = this.reader["INSCRIPCION"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEnfermos.Items.Add(inscripcion + " - " + apellido);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int inscripcion = int.Parse(this.txtInscripcion.Text);

            //string sql = "delete from enfermo where inscripcion=" + inscripcion;
            string sql = "delete from enfermo where inscripcion=@inscripcion";

            //CREAMOS UN NUEVO OBJETO PARAMETRO
            SqlParameter paminscripcion = new SqlParameter("@inscripcion", inscripcion);
            //paminscripcion.ParameterName = "@inscripcion";
            //paminscripcion.Value = inscripcion;
            ////TIPO DE DATO
            //paminscripcion.DbType = DbType.Int32;
            ////paminscripcion.SqlDbType = SqlDbType.Int;
            ////DIRECTION NO ES NECESARIO A NO SER QUE DESEEMOS CAMBIAR SU VALOR POR DEFECTO (INPUT)
            //paminscripcion.Direction = ParameterDirection.Input;
            //DEBEMOS AÑADIR A LA COLECCION DEL COMMAND LOS PARAMETROS
            this.com.Parameters.Add(paminscripcion);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            MessageBox.Show("Enfermos eliminados " + eliminados);
            this.LoadEnfermos();
        }
    }
}
