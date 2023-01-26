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
    public partial class Ejer01ModificarSalas : Form
    {

        //DECLARACION DE LAS VARIABLES DE SQL
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public Ejer01ModificarSalas()
        {
            InitializeComponent();
            //CADENA DE CONEXION CON SQL
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
            string connectionStringCasa = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";

            //SE ESTABLECE LA CONEXION DE CONSUMO
            this.connection = new SqlConnection(connectionStringCasa);

            this.command = new SqlCommand();
            this.command.Connection = this.connection;

            //SE CARGAN LAS SALAS AL INICIAR EL COMPONENTE
            this.CargarSalas();
        }

        //FUNCION PARA CARGAR LAS SALAS EN LA LISTA
        private void CargarSalas()
        {
            //CREACION Y DECLARACION DE LA CONSULTA A LA BBDD
            string consulta = "SELECT NOMBRE FROM SALAPRUEBA GROUP BY NOMBRE";
            //DECLARACION DEL TIPO DE CONSULTA
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            //SE ABRE LA CONEXION
            this.connection.Open();

            //SE EJECUTA LA CONSULTA CON LA CONEXION ABIERTA
            this.reader = this.command.ExecuteReader();

            //SE LIMIA LA LISTA EN CASO DE TENER CONTENIDO
            this.lstSalas.Items.Clear();

            while(this.reader.Read())
            {
                string sala = this.reader["NOMBRE"].ToString();
                this.lstSalas.Items.Add(sala);
            }

            //SE CIERRA EL READER Y LA CONEXION
            this.reader.Close();
            this.connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreSala = this.txtNewName.Text;
            string nomLista = this.lstSalas.SelectedItem.ToString();

            string consulta = "UPDATE SALAPRUEBA SET NOMBRE = @nombreSala WHERE NOMBRE = @nomLista";

            SqlParameter paramNombreSala = new SqlParameter("@nombreSala", nombreSala);
            SqlParameter paramNomLista = new SqlParameter("@nomLista", nomLista);
            this.command.Parameters.Add(paramNombreSala);
            this.command.Parameters.Add(paramNomLista);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();

            this.reader = this.command.ExecuteReader();
            MessageBox.Show("Se ha actualizado la sala");

            this.lstSalas.Items.Clear();
            this.command.Parameters.Clear();

            this.reader.Close();
            this.connection.Close();
            this.CargarSalas();
        }
    }
}
