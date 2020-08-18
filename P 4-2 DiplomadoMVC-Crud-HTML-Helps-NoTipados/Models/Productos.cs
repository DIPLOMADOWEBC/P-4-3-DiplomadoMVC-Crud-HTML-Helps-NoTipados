using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_4_2_DiplomadoMVC_Crud_HTML_Helps_NoTipados.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public float Precio { get; set; }
    }
}