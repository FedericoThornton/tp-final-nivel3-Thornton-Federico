using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3ThorntonFederico
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Page.Validate();
                if(!Page.IsValid)
                {
                    return;
                }
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
               if(negocio.Login(usuario))
                {
                    Session.Add("SesionActiva", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
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