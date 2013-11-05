using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Web.Administracao.IPages;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ExcluirUsuario : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private Usuario _objeto;
        private ControladorUsuario _controlador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _id = Request.QueryString["id"];
                _controlador = new ControladorUsuario();
                _objeto = _controlador.ObterPorID(_id);
                Session.Add("usuario", _objeto);
                BindToUI(_objeto);
            }
        }

        private void BindToUI(Usuario pObjeto)
        {
            lbID.Text = pObjeto.ID;
            lbLogin.Text = pObjeto.Login;
            lbNome.Text = pObjeto.Nome;
            lbAdministrador.Text = pObjeto.ObterTextoAdministrador;
        }

        private void Excluir()
        {
            _objeto = (Usuario)Session["usuario"];
            _controlador = new ControladorUsuario();
            _controlador.Excluir(_objeto);
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            Excluir();
            Response.Redirect("~/pages/ConsUsuarios.aspx");
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/ConsUsuarios.aspx");
        }
    }
}