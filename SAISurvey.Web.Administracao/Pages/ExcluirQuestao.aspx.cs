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

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ExcluirQuestao : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private Questao _objeto;
        private ControladorQuestao _controlador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _id = Request.QueryString["id"];
                _controlador = new ControladorQuestao();
                _objeto = _controlador.ObterPorID(_id);
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
            _controlador = new ControladorQuestao();
            _controlador.Excluir(_objeto);
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