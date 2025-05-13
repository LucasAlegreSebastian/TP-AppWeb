using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWeb_equipo_12B
{
    public partial class Inicio : System.Web.UI.Page
    {
        private List<Voucher> listaVoucher;
        private List<Voucher> listaVoucherCanjeados;
        protected void Page_Load(object sender, EventArgs e)
        {

            VoucherNegocio voucherNegocio = new VoucherNegocio();
            listaVoucher = voucherNegocio.ListarVouchers();
            listaVoucherCanjeados = voucherNegocio.ListarVouchersCanjeados();

            ///Obtenemos dos listas de vouchers, los disponibles y los canjeados
        }

        protected void btnAceptarVoucher_Click(object sender, EventArgs e)
        {

            ///Verificamos el voucher si esta canjeado o no 
            ///si esta disponible vamos a la pagina de premios para poder canjearlo
            ///sino mostramos un label de error de voucher o que esta canjeado

            lblVoucherInvalido.Visible = false;
            Session["VoucherIngresado"] = txtboxVoucher.Text;

            for (int i = 0; i < listaVoucher.Count; i++)
            {
                if (txtboxVoucher.Text == listaVoucher[i].Codigo)
                {
                    ///Si existe el voucher y ESTÁ DISPONIBLE, avanzamos a canjear el premio
                    Session.Add("CodigoVoucher", listaVoucher[i].Codigo);
                    Response.Redirect("PaginaPremios.aspx", false);

                }
                
            }

            for (int i = 0; i < listaVoucherCanjeados.Count; i++)
            {
                if (txtboxVoucher.Text == listaVoucherCanjeados[i].Codigo)
                {
                    ///Redirige a la pantalla de mensaje
                    Response.Redirect("PaginaMensaje.aspx", false);
                }
                else
                {
                    lblVoucherInvalido.Visible = true;
                }


            }
        }
    }
}