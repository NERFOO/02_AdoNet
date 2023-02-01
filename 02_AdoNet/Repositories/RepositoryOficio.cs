using _02_AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using _02_AdoNet.Helpers;

namespace _02_AdoNet.Repositories
{
	public class RepositoryOficio
	{

		private SqlCommand command;
		private SqlConnection connection;
		private SqlDataReader reader;
		

        public RepositoryOficio()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public List<string> GetOficios()
		{
			List<string> oficios = new List<string>();

			string consulta = "SELECT DISTINCT OFICIO FROM EMP";

			this.command.CommandType = CommandType.Text;
			this.command.CommandText = consulta;

			this.connection.Open();
			this.reader = this.command.ExecuteReader();

			while(this.reader.Read())
			{
				string oficio = this.reader["OFICIO"].ToString();

                oficios.Add(oficio);
			}

			this.connection.Close();
			this.reader.Close();

			return oficios;
		}

		public List<Empleado> CargarEmpleado()
		{
			List<Empleado> empleados = new List<Empleado>();

			string consulta = "SELECT EMP_NO, APELLIDO, OFICIO, SALARIO FROM EMP";

			this.command.CommandType = CommandType.Text;
			this.command.CommandText = consulta;

			this.connection.Open();
			this.reader = this.command.ExecuteReader();

			while(this.reader.Read())
			{
				//int id = int.Parse(this.reader["EMP_NO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                string oficio = this.reader["OFICIO"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());

				Empleado emp = new Empleado();

				//emp.NumEmpleado = id;
				emp.Apellido = apellido;
				emp.Ocupacion = oficio;
				emp.Salario = salario;

				empleados.Add(emp);
            }
			this.reader.Close();
			this.connection.Close();

			return empleados;
		}

        public List<Empleado> CargarEmpleado(string nombre)
        {
            List<Empleado> empleados = new List<Empleado>();

            string consulta = "SELECT EMP_NO, APELLIDO, OFICIO, SALARIO FROM EMP WHERE OFICIO = @NOM";
			SqlParameter paramNom = new SqlParameter("@NOM", nombre);
			this.command.Parameters.Add(paramNom);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            while (this.reader.Read())
            {
                //int id = int.Parse(this.reader["EMP_NO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                string oficio = this.reader["OFICIO"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());

                Empleado emp = new Empleado();

                //emp.NumEmpleado = id;
                emp.Apellido = apellido;
                emp.Ocupacion = oficio;
                emp.Salario = salario;

                empleados.Add(emp);
            }
            this.reader.Close();
            this.connection.Close();
			this.command.Parameters.Clear();

            return empleados;
        }

		public int DeleteUser()
		{

			return 0;
		}
    }
}
