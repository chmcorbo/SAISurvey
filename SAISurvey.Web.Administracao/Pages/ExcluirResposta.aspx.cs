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
    public partial class ExcluirResposta : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private Resposta _objeto;
        private IRepositorioResposta _repositorio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _id = Request.QueryString["id"];
                _repositorio = new RepositorioResposta();
                _objeto = _repositorio.ObterPorID(_id);
                Session.Add("questao", _objeto);
                BindToUI(_objeto);
            }
        }

        private void BindToUI(Resposta pObjeto)
        {
            lbID.Text = pObjeto.ID;
            lbDescricao.Text = pObjeto.Descricao;
        }

        private void Excluir()
        {
            _objeto = (Resposta)Session["resposta"];
            _repositorio = new RepositorioResposta();
            _repositorio.Excluir(_objeto);
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            Excluir();
            Response.Redirect("~/pages/ConsRespostas.aspx");
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/ConsQuestoes.aspx");
        }
    }
}