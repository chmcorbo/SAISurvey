using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;


namespace SAISurvey.Web.Administracao.Pages
{
    public partial class ConsRespostas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProcurar_Click(object sender, EventArgs e)
        {
            ControladorResposta _controlador = new ControladorResposta();
            if (txtDescricao.Text != String.Empty)
                GridView1.DataSource = _controlador.ObterPorDescricao(txtDescricao.Text);
            else
                GridView1.DataSource = _controlador.ListarTudo();
            GridView1.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CadastroResposta.aspx?id=0");
        }
    }
}