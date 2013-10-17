using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Web.Administracao.IPages;
using SAISurvey.Web.Administracao.Modelo;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class AlterarSenhaUsuario : System.Web.UI.Page, IPaginaCadastroPadrao<Usuario>
    {
        private String _id = String.Empty;
        private Usuario _objeto;
        private IRepositorioUsuario _repositorio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario_logado"] == null)
                    Response.Redirect("~/UsuarioNaoLogado.aspx");

                _objeto = (Usuario)Session["usuario_logado"];
                _id = _objeto.ID;
                Session.Add("usuario", _objeto);
                BindToUI(_objeto);
            }
        }

        public void BindToUI(Usuario pObjeto)
        {
            lbID.Text = pObjeto.ID;
            lbLogin.Text = pObjeto.Login;
            lbNome.Text = pObjeto.Nome;
            lbAdministrador.Text = pObjeto.ObterTextoAdministrador;
        }

        public Usuario BindToModel()
        {
            Usuario usuario = (Usuario)Session["usuario"];
            usuario.Senha = txtSenha.Text;
            return usuario;
        }

        public void Gravar(Usuario pObjeto)
        {
            _repositorio = new RepositorioUsuario();
            _repositorio.Atualizar(pObjeto);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                _objeto = BindToModel();
                Gravar(_objeto);
                btnVoltar_Click(sender, e);
            }
            catch (Exception ex)
            {
                lbMessagem.Visible = true;
                lbMessagem.Text = ex.InnerException.Message;
            }

        }
    }
}