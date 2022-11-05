using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Models
{
    public class Municipio
    {
        public int Id_Municipio { get; set; }
        public String NombreMunicipio { get; set; }
        public int Id_Departamento { get; set; }
    }
}