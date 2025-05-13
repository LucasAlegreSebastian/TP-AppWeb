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
    public partial class PaginaPremios : System.Web.UI.Page
    {
        private List<Articulo> listaPremios;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validación: si no hay voucher en sesión, redirigir a mensaje de error
            if (Session["CodigoVoucher"] == null)
            {
                Session["MensajeRegistro"] = "ErrorPermisos";
                Response.Redirect("PaginaMensaje.aspx", false);
                return;
            }


            ArticuloNegocio premios = new ArticuloNegocio();
            listaPremios = premios.listarConSp();

            if (!IsPostBack)
            {
                RepeaterPremios.DataSource = listaPremios;
                RepeaterPremios.DataBind();
            }
        }

        protected void btnSeleccionarPremios_Click(object sender, EventArgs e)
        {
            int idArticuloACanjear = int.Parse(((Button)sender).CommandArgument);
            Session.Add("IDArticulo", idArticuloACanjear);
            
            Response.Redirect("PaginaDatosCliente.aspx", false);

        }
    }
}