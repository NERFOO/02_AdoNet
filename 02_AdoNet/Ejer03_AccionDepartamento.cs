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

        RepositoryDepartamentos bla;
        List<Departamento> listaDepartamentos;

        public Ejer03_AccionDepartamento()
        {
            InitializeComponent();
            this.bla = new RepositoryDepartamentos();
            this.GetDepartamentos();
        }

        public void GetDepartamentos()
        {
            this.listaDepartamentos = bla.GetDepartamentos();
            foreach(Departamento dept in listaDepartamentos)
            {
                this.lstDepartamentos.Items.Add(dept.IdDepartamento + " , " + dept.Nombre + " , " + dept.Localidad);
            }
        }

    }
}
