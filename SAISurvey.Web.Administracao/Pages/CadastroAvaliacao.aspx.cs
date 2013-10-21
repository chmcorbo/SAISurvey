using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Web.Administracao.IPages;
using SAISurvey.Web.Administracao.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;


namespace SAISurvey.Web.Administracao.Pages
{
    public partial class CadastroAvaliacao : System.Web.UI.Page, IPaginaCadastroPadrao<Avaliacao>
    {
        private TipoOperacaoUsuario _operacao = TipoOperacaoUsuario.Incluir;
        private String _id = String.Empty;
        private IRepositorioAvaliacao _repositorio;
        private IRepositorioCurso _repositorioCurso;
        private IRepositorioTurma _repositorioTurma;
        private Avaliacao _objeto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheListaCursos();

                if (Request.QueryString["id"] != "0")
                {
                    _id = Request.QueryString["id"];
                    if (Session["avaliacao"] != null && ((Avaliacao)Session["avaliacao"]).ID == _id)
                    {
                        _operacao = (TipoOperacaoUsuario)Session["operacaoUsuario"];
                        _objeto = (Avaliacao)Session["avaliacao"];
                    }
                    else
                    {
                        _operacao = TipoOperacaoUsuario.Editar;
                        _repositorio = new RepositorioAvaliacao();
                        _objeto = _repositorio.ObterPorID(_id);
                    }
                }
                else
                {
                    _operacao = TipoOperacaoUsuario.Incluir;
                    _objeto = new Avaliacao();
                }
                Session["operacaoUsuario"] = _operacao;
                Session["avaliacao"] = _objeto;

                BindToUI(_objeto);
            }

        }

        public List<Questao> ListarQuestoes()
        {
            return ((Avaliacao)Session["avaliacao"]).Questoes.OrderBy(q => q.Descricao).ToList();
        }

        private void LimparLista(DropDownList pLista)
        {
            ListItem item = new ListItem("Selecione", "0");
            pLista.Items.Clear();
            pLista.Items.Add(item);
        }

        private void PreencheListaCursos()
        {
            LimparLista(ddlCurso);
            _repositorioCurso = new RepositorioCurso();
            ddlCurso.DataSource = _repositorioCurso.ListarTudo().OrderBy(c => c.Descricao);
            ddlCurso.DataValueField = "ID";
            ddlCurso.DataTextField = "Descricao";
            ddlCurso.DataBind();
        }

        private void PreencheListaBlocos(Curso pCurso)
        {
            LimparLista(ddlBloco);
            ddlBloco.DataSource = pCurso.Blocos.OrderBy(b => b.Descricao);
            ddlBloco.DataValueField = "ID";
            ddlBloco.DataTextField = "Descricao";
            ddlBloco.DataBind();
        }

        private void PreencheListaModulos(Bloco pBloco)
        {
            LimparLista(ddlModulo);
            ddlModulo.DataSource = pBloco.Modulos.OrderBy(m => m.Descricao);
            ddlModulo.DataValueField = "ID";
            ddlModulo.DataTextField = "Descricao";
            ddlModulo.DataBind();
        }

        private void PreencheListaTurmas(String pID_Modulo)
        {
            _repositorioTurma = new RepositorioTurma();
            LimparLista(ddlTurma);
            ddlTurma.DataValueField = "ID";
            ddlTurma.DataTextField = "Descricao";
            ddlTurma.DataSource = _repositorioTurma.ListarPorModulo(pID_Modulo);
            ddlTurma.DataBind();
        }

        public void BindToUI(Avaliacao pObjeto)
        {
            lbID.Text = pObjeto.ID;
            txtObjetivo.Text = pObjeto.Objetivo;
            txtDataInicial.Text = pObjeto.Data_Inicio.ToString();
            txtDataFinal.Text = pObjeto.Data_Fim.ToString();
            if (pObjeto.Turma != null)
            {
                PreencheListaCursos();
                ddlCurso.SelectedValue = pObjeto.Turma.Modulo.Bloco.Curso.ID;
                ddlCurso_SelectedIndexChanged(pObjeto, EventArgs.Empty);
                
                ddlBloco.SelectedValue = pObjeto.Turma.Modulo.Bloco.ID;
                ddlBloco_SelectedIndexChanged(pObjeto, EventArgs.Empty);
                
                ddlModulo.SelectedValue = pObjeto.Turma.Modulo.ID;
                ddlModulo_SelectedIndexChanged(pObjeto, EventArgs.Empty);

                ddlTurma.SelectedValue = pObjeto.Turma.ID;
            }
            GridView1.DataSource = pObjeto.Questoes;
            GridView1.DataBind();
        }

        public Avaliacao BindToModel()
        {
            _repositorioTurma = new RepositorioTurma();
            Avaliacao avaliacao = (Avaliacao)Session["avaliacao"];
            avaliacao.Objetivo = txtObjetivo.Text;
            avaliacao.Data_Inicio = DateTime.Parse(txtDataInicial.Text);
            avaliacao.Data_Fim = DateTime.Parse(txtDataFinal.Text);
            avaliacao.Turma = _repositorioTurma.ObterPorID(ddlTurma.SelectedValue);
            return avaliacao;
        }

        public void Gravar(Avaliacao pObjeto)
        {
            _repositorio = new RepositorioAvaliacao();
            _operacao = (TipoOperacaoUsuario)Session["operacaoUsuario"];
            if (_operacao == TipoOperacaoUsuario.Incluir)
            {
                _repositorio.Adicionar(pObjeto);
            }
            else
                _repositorio.Atualizar(pObjeto);
        }

        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCurso.SelectedValue != String.Empty)
            {
                _repositorioCurso = new RepositorioCurso();
                Curso curso = _repositorioCurso.ObterPorID(ddlCurso.SelectedValue);
                Session.Add("curso", curso);
                PreencheListaBlocos(curso);
            }
            else
            {
                LimparLista(ddlBloco);
                LimparLista(ddlModulo);
            }
        }

        protected void ddlBloco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Curso)Session["curso"] != null && ddlBloco.SelectedValue != null)
            {
                Curso curso = (Curso)Session["curso"];
                PreencheListaModulos(curso.Blocos.Where(b => b.ID==ddlBloco.SelectedValue).FirstOrDefault());
            }
            else
            {
                ddlModulo.Items.Clear();
            }
        }

        protected void ddlModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModulo.SelectedValue != null)
            {
                PreencheListaTurmas(ddlModulo.SelectedValue);
            }
            else
            {
                LimparLista(ddlTurma);
            }
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
            Response.Redirect("~/Pages/ConsAvaliacao.aspx");
        }

        protected void btnDefinirQuestoes_Click(object sender, EventArgs e)
        {
            Session["avaliacao"] = BindToModel(); 
            Response.Redirect("~/Pages/SelecionarQuestoes.aspx");
        }

    }
}