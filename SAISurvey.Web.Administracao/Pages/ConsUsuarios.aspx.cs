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
            ControladorUsuario _controlador = new ControladorUsuario();
            if (txtNome.Text != String.Empty)
                GridView1.DataSource = _controlador.ListarPorNome(txtNome.Text);
            else
                GridView1.DataSource = _controlador.ListarTudo();
            GridView1.DataBind();
        }
    }
}