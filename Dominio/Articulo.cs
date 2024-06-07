using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo


    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public Categoria Tipo { get; set; }

        public Marca Marca { get; set; }  

        public string ImagenUrl { get; set; }

  
        public decimal Precio { get; set; }


        public override string ToString()
        {
           
            return Precio.ToString();
        }
    

    }
}
