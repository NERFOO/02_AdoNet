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
        int idModificar;

        public Ejer03_AccionDepartamento()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentos();
            this.GetDepartamentos();
        }

        public void GetDepartamentos()
        {
            List<Departamento> listaDepartamentos = this.repo.GetDepartamentos();
            this.lstDepartamentos.Items.Clear();
            foreach(Departamento dept in listaDepartamentos)
            {
                this.lstDepartamentos.Items.Add(dept.Nombre);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string departamento = this.txtDepartamento.Text;
            string localidad = this.txtLocalidad.Text;

            this.repo.InsertDepartamento(departamento, localidad);
            this.GetDepartamentos();
        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstDepartamentos.SelectedItems.Count != -1)
            {
                Departamento listaDepartamentos = this.repo.GetEmpleado(this.lstDepartamentos.SelectedItem.ToString());
                this.txtId.Text = listaDepartamentos.IdDepartamento.ToString();
                this.txtDepartamento.Text = listaDepartamentos.Nombre.ToString();
                this.txtLocalidad.Text = listaDepartamentos.Localidad.ToString();

                this.idModificar = int.Parse(this.txtId.Text);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = this.idModificar;
            string departamento = this.txtDepartamento.Text;
            string localidad = this.txtLocalidad.Text;

            this.repo.UpdateDepartamento(id, departamento, localidad);
            this.GetDepartamentos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.repo.DeleteDepartamento(int.Parse(this.txtId.Text));
            this.GetDepartamentos();
        }
    }
}
