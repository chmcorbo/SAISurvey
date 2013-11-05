using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Dominio.Modelo;


namespace SAISurvey.Web.Administracao.Pages
{
    public partial class SelecionarQuestoes : System.Web.UI.Page
    {
        private ConectionManager _conexao;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProcurar_Click(object sender, EventArgs e)
        {
            ObjectDataSource1.DataBind();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/CadastroAvaliacao.aspx?id="+((Avaliacao)Session["avaliacao"]).ID);
        }

        protected void cbTituloSelecionado_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("cbLinhaSelecionada");
                if (cb != null)
                {
                    cb.Checked = !cb.Checked;
                }
            }
        }

        protected void btnAdicionarQuestoesSelecionadas_Click(object sender, EventArgs e)
        {
            ControladorQuestao _controlador = new ControladorQuestao();
            Avaliacao avaliacao = (Avaliacao)Session["avaliacao"];
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("cbLinhaSelecionada");
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        String id_questao = row.Cells[2].Text;
                        if (avaliacao.Questoes.Where(q => q.ID == id_questao).Count() == 0)
                        {
                            Questao questao = _controlador.ObterPorID(id_questao);
                            avaliacao.Questoes.Add(questao);
                        }
                    }
                }
            }
            Session["avaliacao"] = avaliacao;
        }
    }
}