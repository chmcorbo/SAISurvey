using System;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;

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
            ControladorAvaliacao controlador = new ControladorAvaliacao();
            dataInicial = DateTime.Parse(txtDataInicial.Text);
            dataFinal = DateTime.Parse(txtDataFinal.Text);
            GridView1.DataSource = controlador.ListarPorPeriodo(dataInicial, dataFinal);
            GridView1.DataBind();
        }
    }
}