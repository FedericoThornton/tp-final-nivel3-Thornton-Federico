using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinalNivel3ThorntonFederico
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
       
            try
            {
                if (!IsPostBack)
                {
                    CategoriaNegocio Categorianegocio = new CategoriaNegocio();
                    List<Categoria> listaCategoria = Categorianegocio.listar();
                    MarcaNegocio MarcaNegocio = new MarcaNegocio();
                    List<Marca> listaMarca = MarcaNegocio.listar();


                    ddlTipo.DataSource = listaCategoria;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if (id != "" && !IsPostBack)

                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = negocio.listar(id)[0];

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.ImagenUrl;
                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    TxtPrecio.Text = seleccionado.Precio.ToString();
                    txtUrlImagen_TextChanged(sender, e);


                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
           
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            ImageArticulos.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtUrlImagen.Text;
                nuevo.Precio = decimal.Parse(TxtPrecio.Text);
                nuevo.Tipo = new Categoria();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {

                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }


                else
                {
                    negocio.agregarconSP(nuevo);
                }
              
                Response.Redirect("ArticulosLista.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

     

        protected void btnConfirmaeliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaeliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ArticulosLista.aspx", false);
                }
           

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
            ConfirmaEliminacion = true;
        }

     
    }
}