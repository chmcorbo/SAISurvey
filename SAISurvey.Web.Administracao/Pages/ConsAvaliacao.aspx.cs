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
            RepositorioAvaliacao repositorio = new RepositorioAvaliacao();
            dataInicial = DateTime.Parse(txtDataInicial.Text);
            dataFinal = DateTime.Parse(txtDataFinal.Text);
            GridView1.DataSource = repositorio.ListarPorPeriodo(dataInicial,dataFinal);
            GridView1.DataBind();
        }
    }
}