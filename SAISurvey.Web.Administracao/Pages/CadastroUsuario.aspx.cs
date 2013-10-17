using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Web.Administracao.IPages;
using SAISurvey.Web.Administracao.Modelo;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class CadastroUsuario : System.Web.UI.Page, IPaginaCadastroPadrao<Usuario>
    {
        private TipoOperacaoUsuario _operacao = TipoOperacaoUsuario.Incluir;
        private String _id = String.Empty;
        private IRepositorioUsuario _repositorio;
        private Usuario _objeto;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "0")
                {
                    _id = Request.QueryString["id"];
                    _operacao = TipoOperacaoUsuario.Editar;
                    _repositorio = new RepositorioUsuario();
                    _objeto = _repositorio.ObterPorID(_id);
                }
                else
                {
                    _operacao = TipoOperacaoUsuario.Incluir;
                    _objeto = new Usuario();
                }
                Session["operacaoUsuario"] = _operacao;
                Session["usuario"] = _objeto;
                BindToUI(_objeto);
            }
        }

        public void BindToUI(Usuario pObjeto)
        {
            lbID.Text = pObjeto.ID;
            txtLogin.Text = pObjeto.Login;
            txtNome.Text = pObjeto.Nome;
            ddlAdministrador.SelectedValue=pObjeto.Administrador;
        }

        public Usuario BindToModel()
        {
            Usuario usuario = (Usuario)Session["usuario"];
            usuario.Login = txtLogin.Text;
            usuario.Nome = txtNome.Text;
            usuario.Administrador = ddlAdministrador.SelectedValue;
            return usuario;
        }

        public void Gravar(Usuario pObjeto)
        {
            _repositorio = new RepositorioUsuario();
            _operacao = (TipoOperacaoUsuario)Session["operacaoUsuario"];
            if (_operacao == TipoOperacaoUsuario.Incluir)
            {
                _objeto.Senha = _objeto.Login;
                _repositorio.Adicionar(pObjeto);
            }
            else
                _repositorio.Atualizar(pObjeto);

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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ConsUsuarios.aspx");
        }
    }
}