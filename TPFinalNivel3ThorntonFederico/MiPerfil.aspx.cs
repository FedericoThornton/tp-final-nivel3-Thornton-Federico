using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinalNivel3ThorntonFederico
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["SesionActiva"]))
                    {
                        Usuario user = (Usuario)Session["SesionActiva"];
                        txtEmail.Text = user.Email;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;

                        imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }




            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                Usuario user = (Usuario)Session["SesionActiva"];
                UsuarioNegocio negocio = new UsuarioNegocio();
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }
               
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                negocio.actualizar(user);

                Image img = (Image)Master.FindControl("ImgAvatar");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}