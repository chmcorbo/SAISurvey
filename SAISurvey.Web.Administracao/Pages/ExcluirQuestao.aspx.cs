using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ExcluirQuestao : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private Questao _objeto;
        private IRepositorioQuestao _repositorio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _id = Request.QueryString["id"];
                _repositorio = new RepositorioQuestao();
                _objeto = _repositorio.ObterPorID(_id);
                Session.Add("questao", _objeto);
                BindToUI(_objeto);
            }
        }

        private void BindToUI(Questao pObjeto)
        {
            lbID.Text = pObjeto.ID;
            lbDescricao.Text = pObjeto.Descricao;
        }

        private void Excluir()
        {
            _objeto = (Questao)Session["questao"];
            _repositorio = new RepositorioQuestao();
            _repositorio.Excluir(_objeto);
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            Excluir();
            Response.Redirect("~/pages/ConsQuestoes.aspx");
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/ConsQuestoes.aspx");
        }
    }
}