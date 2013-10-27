using System;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ConsAvaliacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CadastroAvaliacao.aspx?id=0");
        }

        protected void btnProcurar_Click(object sender, EventArgs e)
        {
            DateTime dataInicial, dataFinal;
            ConectionManager conexao = new ConectionManager();
            RepositorioAvaliacao repositorio = new RepositorioAvaliacao(conexao);
            dataInicial = DateTime.Parse(txtDataInicial.Text);
            dataFinal = DateTime.Parse(txtDataFinal.Text);
            GridView1.DataSource = repositorio.ListarPorPeriodo(dataInicial,dataFinal);
            GridView1.DataBind();
        }
    }
}