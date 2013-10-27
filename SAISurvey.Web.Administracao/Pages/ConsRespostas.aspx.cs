using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;


namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ConsRespostas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProcurar_Click(object sender, EventArgs e)
        {
            ConectionManager conexao = new ConectionManager();
            RepositorioResposta repositorio = new RepositorioResposta(conexao);
            if (txtDescricao.Text != String.Empty)
                GridView1.DataSource = repositorio.ObterPorDescricao(txtDescricao.Text);
            else
                GridView1.DataSource = repositorio.ListarTudo().OrderBy(r => r.Descricao);
            GridView1.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CadastroResposta.aspx?id=0");
        }
    }
}