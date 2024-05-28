using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinalNivel3ThorntonFederico
{
    public partial class ArticulosLista : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }
        public bool reiniciarFiltro { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["sesionActiva"]))
            {
                Session.Add("error", "Lo siento, debe tener credenciales de Administrador");
                Response.Redirect("Error.aspx", false);
            }
            if (!IsPostBack)
            {
                filtroAvanzado = false;
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulo", negocio.listarconSP());
                DgvArticulos.DataSource = Session["listaArticulo"];
                DgvArticulos.DataBind();
            }

        }



        protected void DgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DgvArticulos.PageIndex = e.NewPageIndex;
            DgvArticulos.DataBind();
        }

        protected void DgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = DgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulos.aspx?Id=" + id);
        }

        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
            List<Articulo> listafiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(txtfiltro.Text.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            DgvArticulos.DataSource = listafiltrada;
            DgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chkAvanzado.Checked;
            txtfiltro.Enabled = !filtroAvanzado;
        }

        protected void DdlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DdlCriterio.Items.Clear();
                if (DdlCampo.SelectedItem.ToString() == "Precio")
                {
                    DdlCriterio.Items.Add("Igual a");
                    DdlCriterio.Items.Add("Mayor a");
                    DdlCriterio.Items.Add("Menor a");

                }
                else
                {
                    DdlCriterio.Items.Add("Contiene");
                    DdlCriterio.Items.Add("Comienza con");
                    DdlCriterio.Items.Add("Termina con");

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
                
            }
          
        }

        protected void DdlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        public bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }

            return true;
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                ArticuloNegocio negocio = new ArticuloNegocio();

                if (!string.IsNullOrEmpty(TxtFiltroavanzado.Text))
                {
                   
                    DgvArticulos.DataSource = negocio.filtrar(DdlCampo.SelectedItem.ToString(),
                    DdlCriterio.SelectedItem.ToString(),
                    TxtFiltroavanzado.Text);
                    DgvArticulos.DataBind();

                } 

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void reinicioFiltro_CheckedChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (chkreinicioFiltro.Checked)
            {
                DgvArticulos.DataSource = negocio.listarconSP();
                DgvArticulos.DataBind();
            }
           
        }
    }
}