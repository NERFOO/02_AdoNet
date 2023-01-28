using _02_AdoNet.Models;
using _02_AdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_AdoNet
{
    public partial class Ejer03_AccionDepartamento : Form
    {

        RepositoryDepartamentos repo;

        public Ejer03_AccionDepartamento()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentos();
            this.GetDepartamentos();
        }

        public void GetDepartamentos()
        {
            List<Departamento> listaDepartamentos = repo.GetDepartamentos();
            this.lstDepartamentos.Items.Clear();
            foreach(Departamento dept in listaDepartamentos)
            {
                this.lstDepartamentos.Items.Add(dept.Nombre);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string departamento = this.txtDepartamento.Text;
            string localidad = this.txtLocalidad.Text;

            repo.InsertDepartamento(id, departamento, localidad);
            this.GetDepartamentos();
        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Departamento listaDepartamentos = repo.GetEmpleado(this.lstDepartamentos.SelectedItem.ToString());
            this.txtId.Text = listaDepartamentos.IdDepartamento.ToString();
            this.txtDepartamento.Text = listaDepartamentos.Nombre.ToString();
            this.txtLocalidad.Text = listaDepartamentos.Localidad.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string departamento = this.txtDepartamento.Text;
            string localidad = this.txtLocalidad.Text;

            repo.UpdateDepartamento(id, departamento, localidad);
            this.GetDepartamentos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            repo.DeleteDepartamento(int.Parse(this.txtId.Text));
            this.GetDepartamentos();
        }
    }
}
