using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3ThorntonFederico
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            try
            {
                if (id != "" && !IsPostBack)

                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = negocio.listar(id)[0];


                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    ImageArticulos.ImageUrl = seleccionado.ImagenUrl;
                    txtTipo.Text = seleccionado.Tipo.Descripcion.ToString();
                    txtMarca.Text = seleccionado.Marca.Descripcion.ToString();
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    txtNombre.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    txtTipo.ReadOnly = true;
                    txtMarca.ReadOnly = true;
                    txtPrecio.ReadOnly = true;

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
           
        }

      
    }
}