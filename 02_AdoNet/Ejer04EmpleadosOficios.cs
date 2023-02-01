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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _02_AdoNet
{
    public partial class Ejer04EmpleadosOficios : Form
    {

        RepositoryOficio repo;

        public Ejer04EmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryOficio();
            this.PintarOficios();
            this.PintarEmpleados();
        }

        public void PintarOficios()
        {
            foreach(string ofi in repo.GetOficios())
            {
                this.comboBoxOficios.Items.Add(ofi);
            }
        }

        public void PintarEmpleados()
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

        public void PintarEmpleados(string nombre)
        {
            List<Empleado> empleado = new List<Empleado>();
            this.lstViewEmpleados.Items.Clear();

            foreach (Empleado emp in repo.CargarEmpleado(nombre))
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
            string nombre = this.comboBoxOficios.SelectedItem.ToString();
            this.PintarEmpleados(nombre);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstViewEmpleados.SelectedItems.Count != 0)
            {
                int eliminado = this.repo.DeleteUser(int.Parse(this.lstViewEmpleados.SelectedItems[0].SubItems[3].Text));

                string nombre = this.comboBoxOficios.SelectedItem.ToString();
                this.PintarEmpleados(nombre);

                MessageBox.Show("Se han eliminado " + eliminado + " registros");
            }
        }

        private void btnIncremento_Click(object sender, EventArgs e)
        {
            int incremento = int.Parse(this.txtIncremento.Text);
            string oficio = this.comboBoxOficios.SelectedItem.ToString();
            repo.IncrementoSalarial(incremento, oficio);

            string nombre = this.comboBoxOficios.SelectedItem.ToString();
            this.PintarEmpleados(nombre);
        }

        private void lstViewEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lstViewEmpleados.SelectedItems[0].SubItems[3].Text);
        }
    }
}
