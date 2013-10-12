using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class PesqQuestoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProcurar_Click(object sender, EventArgs e)
        {
            RepositorioQuestao repositorioQuestao = new RepositorioQuestao();
            if (txtDescricao.Text != String.Empty)
                GridView1.DataSource = repositorioQuestao.ObterPorDescricao(txtDescricao.Text);
            else
                GridView1.DataSource = repositorioQuestao.ListarTudo();
            GridView1.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CadastroQuestao.aspx?id=0");
        }
    }
}