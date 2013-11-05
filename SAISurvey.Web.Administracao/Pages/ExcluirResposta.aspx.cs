using System;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ExcluirResposta : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private Resposta _objeto;
        private ControladorResposta _controlador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _id = Request.QueryString["id"];
                _controlador = new ControladorResposta();
                _objeto = _controlador.ObterPorID(_id);
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
            _controlador = new ControladorResposta();
            _controlador.Excluir(_objeto);
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