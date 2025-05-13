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
    public partial class PaginaMensaje : System.Web.UI.Page
    {
        private List<Voucher> listaVoucher;
        private List<Voucher> listaVoucherCanjeados;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblVoucherCanjeado.Visible = false;

                string mensajeRegistro = (string)Session["MensajeRegistro"];
                string voucherIngresado = (string)Session["VoucherIngresado"];

                if (mensajeRegistro == "RegistroExitoso")
                {
                    Random random = new Random();
                    int numeroAleatorio = random.Next(0000, 9999);

                    lblVoucherCanjeado.Text = "¡Enhorabuena! Tu voucher fue canjeado correctamente. Nro de comprobante: " + numeroAleatorio +Session["IdArticulo"] + Session["IDCliente"] + ".";
                    lblVoucherCanjeado.Visible = true;
                }
                else if (mensajeRegistro == "ErrorPermisos")
                {
                    lblVoucherCanjeado.Text = "¡No tiene los permisos necesarios!";
                    lblVoucherCanjeado.Visible = true;
                }
                else if (!string.IsNullOrEmpty(voucherIngresado))
                {
                    VoucherNegocio voucherNegocio = new VoucherNegocio();
                    List<Voucher> listaVoucherCanjeados = voucherNegocio.ListarVouchersCanjeados();

                    bool fueCanjeado = listaVoucherCanjeados.Any(v => v.Codigo == voucherIngresado);
                    if (fueCanjeado)
                    {
                        lblVoucherCanjeado.Text = "¡Voucher ya canjeado, intente con uno nuevo!";
                        lblVoucherCanjeado.Visible = true;
                    }
                }

                // Limpio el Session["MensajeRegistro"] para evitar que persista en navegación
                Session["MensajeRegistro"] = null;
            }
        }
        protected void btnIrInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", false);
        }
    }
}