using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Persistence.nHibernate.Servicos;
using SAISurvey.Dominio.Servicos;

namespace SAISurvey.Web.Administracao.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private IServValidadorAcessoUsuario servValidadorAcessoUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                servValidadorAcessoUsuario = new ServValidadorAcessoUsuario();
                Usuario usuario =  servValidadorAcessoUsuario.Execute(txtLogin.Text, txtSenha.Text);
                Session.Add("usuario_logado", usuario);
                Response.Redirect("~/default.aspx");
            }
            catch (Exception ex)
            {
                lbMensagem.Visible = true;
                lbMensagem.Text = ex.Message;
            }

        }
    }
}
