using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Models
{
    public class Empleado
    {
        public int Id_Empleado { get; set; }
        public String NombreEmpleado { get; set; }
        public String ApellidoEmpleado { get; set; }        
        public String Genero { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public int Activo { get; set; }
        public String Codigo { get; set; }
        public float Salario { get; set; }
    }
}