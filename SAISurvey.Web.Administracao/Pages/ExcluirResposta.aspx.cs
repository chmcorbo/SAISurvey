using System;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ExcluirResposta : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private Resposta _objeto;
        private ConectionManager _conexao;
        private IRepositorioResposta _repositorio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _id = Request.QueryString["id"];
                _conexao = new ConectionManager();
                _repositorio = new RepositorioResposta(_conexao);
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
            _conexao = new ConectionManager();
            _objeto = (Resposta)Session["resposta"];
            _repositorio = new RepositorioResposta(_conexao);
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