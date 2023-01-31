using _02_AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AdoNet.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public RepositoryDepartamentos()
        {
            string connectionStringCasa = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public Departamento GetEmpleado(string dNombre)
        {
            string consulta = "SELECT * FROM DEPT WHERE DNOMBRE = @DNOMBRE";
            SqlParameter paramNombre = new SqlParameter("@DNOMBRE", dNombre);
            this.command.Parameters.Add(paramNombre);

            Departamento empleado = new Departamento();

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();

            this.reader = this.command.ExecuteReader();

            while (this.reader.Read())
            {
                int id = int.Parse(this.reader["DEPT_NO"].ToString());
                string nombre = this.reader["DNOMBRE"].ToString();
                string localidad = this.reader["LOC"].ToString();

                empleado.IdDepartamento = id;
                empleado.Nombre = nombre;
                empleado.Localidad = localidad;
            }

            this.connection.Close();
            this.reader.Close();
            this.command.Parameters.Clear();

            return empleado;
        }

        public List<Departamento> GetDepartamentos()
        {
            string consulta = "SELECT * FROM DEPT";

            List<Departamento> departamentos = new List<Departamento>();

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();

            this.reader = this.command.ExecuteReader();

            while(this.reader.Read())
            {
                int id = int.Parse(this.reader["DEPT_NO"].ToString());
                string nombre = this.reader["DNOMBRE"].ToString();
                string localidad = this.reader["LOC"].ToString();

                Departamento dept = new Departamento();

                dept.IdDepartamento = id;
                dept.Nombre = nombre;
                dept.Localidad = localidad;

                departamentos.Add(dept);
            }

            this.connection.Close();
            this.reader.Close();

            return departamentos;
        }

        public int DeleteDepartamento(int id)
        {
            string consulta = "DELETE FROM DEPT WHERE DEPT_NO = @NUMERO";

            SqlParameter paramId = new SqlParameter("@NUMERO", id);

            this.command.Parameters.Add(paramId);

            this.command.CommandType = System.Data.CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();

            int eliminados = this.command.ExecuteNonQuery();

            this.connection.Close();
            this.command.Parameters.Clear();

            return eliminados;
        }

        public int UpdateDepartamento(int id, string nombre, string localidad)
        {
            string consulta = "UPDATE DEPT SET DNOMBRE = @NOMBRE, LOC = @LOCALIDAD WHERE DEPT_NO = @ID";

            SqlParameter paramNombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter paramLocalidad = new SqlParameter("@LOCALIDAD", localidad);
            SqlParameter paramId = new SqlParameter("@ID", id);

            this.command.Parameters.Add(paramNombre);
            this.command.Parameters.Add(paramLocalidad);
            this.command.Parameters.Add(paramId);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();

            int modificados = this.command.ExecuteNonQuery();

            this.connection.Close();
            this.command.Parameters.Clear();
            this.reader.Close();

            return modificados;
        }

        private int GetMaxIdDepart()
        {
            string sql = "SELECT MAX(DEPT_NO) + 1 AS MAXIMO FROM DEPT";
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = sql;
            this.connection.Open();
            //Si la consulta solamente contiene una fila y un dato
            //no es necesario un reader, podemos usar el metodo executescalar()
            int max = Convert.ToInt32(this.command.ExecuteScalar());
            this.connection.Close();
            return max;
        }

        public int InsertDepartamento(string nombre, string localidad)
        {
            int id = this.GetMaxIdDepart();
            string consulta = "INSERT INTO DEPT VALUES (@NUM, @NOM, @LOC)";
            SqlParameter paramNum = new SqlParameter("@NUM", id);
            SqlParameter paramNom = new SqlParameter("@NOM", nombre);
            SqlParameter paramLoc = new SqlParameter("@LOC", localidad);

            this.command.Parameters.Add(paramNum);
            this.command.Parameters.Add(paramNom);
            this.command.Parameters.Add(paramLoc);

            this.command.CommandType = System.Data.CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            int insertados = this.command.ExecuteNonQuery();

            this.connection.Close();
            this.command.Parameters.Clear();

            return insertados;
        }
    }
}
