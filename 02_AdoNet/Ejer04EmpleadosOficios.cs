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
    public partial class Ejer04EmpleadosOficios : Form
    {

        RepositoryOficio repo;

        public Ejer04EmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryOficio();
            this.CargarOficios();
            this.CargarEmpleados();
        }

        public void CargarOficios()
        {
            foreach(string ofi in repo.GetOficios())
            {
                this.comboBoxOficios.Items.Add(ofi);
            }
        }

        public void CargarEmpleados()
        {
            List<Empleado> empleado = new List<Empleado>();
            this.lstViewEmpleados.Items.Clear();

            foreach (Empleado emp in repo.CargarEmpleado())
            {
                ListViewItem it = new ListViewItem();
                it.Text = emp.Apellido;
                it.SubItems.Add(emp.Ocupacion);
                it.SubItems.Add(emp.Salario.ToString());
                it.SubItems.Add(emp.NumEmpleado.ToString());
                this.lstViewEmpleados.Items.Add(it);
            }
        }

        private void comboBoxOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Empleado> empleado = new List<Empleado>();
            this.lstViewEmpleados.Items.Clear();

            foreach (Empleado emp in repo.CargarEmpleado(this.comboBoxOficios.SelectedItem.ToString()))
            {
                ListViewItem it = new ListViewItem();
                it.Text = emp.Apellido;
                it.SubItems.Add(emp.Ocupacion);
                it.SubItems.Add(emp.Salario.ToString());
                this.lstViewEmpleados.Items.Add(it);
            }
        }

        private void lstViewEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.lstViewEmpleados.SelectedItems.ToString());
        }
    }
}
