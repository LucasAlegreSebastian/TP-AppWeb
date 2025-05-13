using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }


        public Marca Marca { get; set; } //obtener IDMarca

        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; } //obtener IDCategoria

        public float Precio { get; set; }
        public List<Imagen> Imagenes { get; set; } // para guardar las imagenes de un articulo
    }
}
