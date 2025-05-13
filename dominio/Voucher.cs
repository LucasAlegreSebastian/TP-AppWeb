using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Voucher
    {
        public string Codigo { get; set; } //CodigoVoucher
        public Cliente Cliente { get; set; } //obtener IdCliente???
        public DateTime FechaCanje { get; set; }
        public Articulo Articulo { get; set; } //obtener IdArticulo???
    }
}
