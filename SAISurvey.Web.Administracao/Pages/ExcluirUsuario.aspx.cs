using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Web.Administracao.IPages;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ExcluirUsuario : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private Usuario _objeto;
        private ConectionManager _conexao;
        private IRepositorioUsuario _repositorio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _id = Request.QueryString["id"];
                _conexao = new ConectionManager();
                _repositorio = new RepositorioUsuario(_conexao);
                _objeto = _repositorio.ObterPorID(_id);
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
            _conexao = new ConectionManager();
            _repositorio = new RepositorioUsuario(_conexao);
            _repositorio.Excluir(_objeto);
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