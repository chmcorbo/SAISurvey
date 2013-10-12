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
    public partial class ConsUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CadastroUsuario.aspx?id=0");
        }

        protected void btnProcurar_Click(object sender, EventArgs e)
        {
            RepositorioUsuario repositorio = new RepositorioUsuario();
            if (txtNome.Text != String.Empty)
                GridView1.DataSource = repositorio.ListarPorNome(txtNome.Text);
            else
                GridView1.DataSource = repositorio.ListarTudo();
            GridView1.DataBind();
        }
    }
}