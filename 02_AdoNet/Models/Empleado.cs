using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AdoNet.Models
{
    public class Empleado
    {
        public int NumEmpleado { get; set; }
        public string Apellido { get; set; }
        public string Ocupacion { get; set; }
        public int Salario { get; set; }
    }
}
