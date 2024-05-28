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
    public partial class Master : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            ImgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";

            if (!(Page is Login || Page is Registro || Page is Default || Page is DetalleArticulo || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["sesionActiva"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            if (Session["sesionActiva"] != null)
            {
                Usuario user = (Usuario)Session["SesionActiva"];
                lblUser.Text = user.Email;
                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    ImgAvatar.ImageUrl = "~/Images/" + ((Usuario)Session["SesionActiva"]).ImagenPerfil;
                }

            }


        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}