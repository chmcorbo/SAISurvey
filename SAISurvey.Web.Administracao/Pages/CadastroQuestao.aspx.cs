using System;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Web.Administracao.Modelo;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class EditarQuestao : System.Web.UI.Page
    {
        private TipoOperacaoUsuario _operacao = TipoOperacaoUsuario.Incluir;
        private String _id = String.Empty;
        private Questao _objeto;
        private ControladorQuestao _controlador;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "0")
                {
                    _id = Request.QueryString["id"];
                    _operacao = TipoOperacaoUsuario.Editar;
                    _controlador = new ControladorQuestao();
                    _objeto = _controlador.ObterPorID(_id);
                }
                else
                {
                    _operacao = TipoOperacaoUsuario.Incluir;
                    _objeto = new Questao();
                }
                Session["operacaoUsuario"]=_operacao;
                Session["questao"]=_objeto;
                BindToUI(_objeto);
            }
        }

        private void BindToUI(Questao pObjeto)
        {
            lbID.Text = pObjeto.ID;
            txtDescricao.Text = pObjeto.Descricao;
        }

        private Questao BindToModel()
        {
            Questao questao = (Questao)Session["questao"];
            questao.Descricao = txtDescricao.Text;
            return questao;
        }

        private void Gravar(Questao pObjeto)
        {
            _controlador = new ControladorQuestao();
            _operacao = (TipoOperacaoUsuario)Session["operacaoUsuario"];
            if (_operacao == TipoOperacaoUsuario.Incluir)
                _controlador.Adicionar(pObjeto);
            else
                _controlador.Atualizar(pObjeto);
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
                lbMessagem.Text = ex.Message;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ConsQuestoes.aspx");
        }
    }
}