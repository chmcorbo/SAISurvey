using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Web.Questionario
{
    public partial class _Default : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private AvaliacaoAluno _avaliacaAluno;
        private ControladorAvaliacaoAluno _controlador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    _id = Request.QueryString["ID"];
                    _controlador = new ControladorAvaliacaoAluno();
                    if (Session["avaliacaoAluno"] == null || ((AvaliacaoAluno)Session["avaliacaoAluno"]).ID != _id)
                    {
                        _avaliacaAluno = _controlador.ObterPorID(_id);
                        if (_avaliacaAluno == null)
                        {
                            Session.Abandon();
                            Response.Redirect("AvaliacaoNaoEncontrada.aspx");
                        }
                        else if (_avaliacaAluno.Fechada=="S")
                        {
                            Session.Abandon();
                            Response.Redirect("AvaliacaoEncerrada.aspx");
                        }

                        Session["avaliacaoAluno"] = _avaliacaAluno;
                    }
                    else
                        _avaliacaAluno = Session["avaliacaoAluno"] as AvaliacaoAluno;
                    Session["usuario"] = _avaliacaAluno.Aluno.Nome;
                    NomearTitulos(_controlador);
                    BindToUI(_avaliacaAluno);
                }
                else
                {
                    Session.Remove("avaliacaoAluno");
                    Response.Redirect("AvaliacaoNaoEncontrada.aspx");
                }
            }
        }

        public void BindToUI(AvaliacaoAluno pObjeto)
        {
            lbCurso.Text=pObjeto.Avaliacao.Turma.Modulo.Bloco.Curso.Descricao;
            lbModulo.Text=pObjeto.Avaliacao.Turma.Modulo.Descricao;
            lbTurma.Text=pObjeto.Avaliacao.Turma.Descricao;
            lbProfessor.Text = pObjeto.Avaliacao.Turma.Professor.Nome;
            txtComentarios.Text = pObjeto.Comentarios;
        }
        public List<RespostaQuestao> ListarQuestoes()
        {
            if (Session["avaliacaoAluno"] != null)
            {
                return ((AvaliacaoAluno)Session["avaliacaoAluno"]).RespostasQuestoes.OrderBy(r => r.Questao.Descricao).ToList();
            }
            else
                return null;
        }

        private void NomearTitulos(ControladorAvaliacaoAluno pControlador)
        {
            List<Resposta> lstReposta = pControlador.ListarRespostas();
            Int32 contador = 2;
            foreach (Resposta resposta in lstReposta)
            {
                if (contador > 7)
                    break;
                GridView1.Columns[contador].HeaderText = resposta.Descricao;
                contador++;
            }
        }

        private void BindGrid()
        {
            _avaliacaAluno = Session["avaliacaoAluno"] as AvaliacaoAluno;
            foreach (GridViewRow row in GridView1.Rows)
            {
                String _id_questao = ((HiddenField)row.FindControl("hdfID")).Value;
                RespostaQuestao repostaQuestao = _avaliacaAluno.RespostasQuestoes.Where(r => r.Questao.ID == _id_questao).FirstOrDefault();
                if (repostaQuestao != null && repostaQuestao.Resposta!=null)
                    ((RadioButton)row.FindControl("rbResposta" + repostaQuestao.Resposta.Ordem)).Checked = true;
            }
        }

        private void SalvarRespostasNaSecao()
        {
            _avaliacaAluno = Session["avaliacaoAluno"] as AvaliacaoAluno;
            _controlador = new ControladorAvaliacaoAluno();
            List<Resposta> lstRespostas = _controlador.ListarRespostas();
            Int32 _ordem = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                String _id_questao = ((HiddenField)row.FindControl("hdfID")).Value;

                if (((RadioButton)row.FindControl("rbResposta1")).Checked)
                    _ordem = 1;
                else if (((RadioButton)row.FindControl("rbResposta2")).Checked)
                    _ordem = 2;
                else if (((RadioButton)row.FindControl("rbResposta3")).Checked)
                    _ordem = 3;
                else if (((RadioButton)row.FindControl("rbResposta4")).Checked)
                    _ordem = 4;
                else if (((RadioButton)row.FindControl("rbResposta5")).Checked)
                    _ordem = 5;
                else if (((RadioButton)row.FindControl("rbResposta6")).Checked)
                    _ordem = 6;

                if (_ordem != 0)
                {
                    Resposta _respostaEscolhida = lstRespostas.Where(r => r.Ordem == _ordem).FirstOrDefault();
                    if (_respostaEscolhida != null)
                    {
                        RespostaQuestao _respostaQuestao = _avaliacaAluno.RespostasQuestoes.Where(q => q.Questao.ID == _id_questao).FirstOrDefault();
                        _respostaQuestao.Resposta = _respostaEscolhida;
                        _avaliacaAluno.AdicionarRespostaQuestao(_respostaQuestao.Questao, _respostaQuestao.Resposta);
                    }
                    _ordem = 0;
                }
            }
            _avaliacaAluno.Comentarios = txtComentarios.Text;
            Session["avaliacaoAluno"] = _avaliacaAluno;
        }

        private void Salvar(Boolean pFecharAvaliacao)
        {
            _avaliacaAluno = (Session["avaliacaoAluno"] as AvaliacaoAluno);
            if (pFecharAvaliacao)
                _avaliacaAluno.Fechada = "S";
            else
                _avaliacaAluno.Fechada = "N";
            _controlador = new ControladorAvaliacaoAluno();
            _controlador.Atualizar(_avaliacaAluno);
        }

        protected void rbResposta_CheckedChanged(Object sender, System.EventArgs e)
        {
            //Clear the existing selected row 
            /*foreach (GridViewRow oldrow in GridView1.Rows)
            {
                ((RadioButton)oldrow.FindControl("rbResposta1")).Checked = false;
            }
            */

            //Set the new selected row
            /*RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("rbResposta1")).Checked = true;*/
        }

        protected void btnDescartarResponderDepois_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("ContinuarDepois.aspx");
        }

        protected void btnSalvarContinuar_Click(object sender, EventArgs e)
        {
            SalvarRespostasNaSecao();
            Salvar(false);
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SalvarRespostasNaSecao();
        }

        protected void btnSalvarFechar_Click(object sender, EventArgs e)
        {
            SalvarRespostasNaSecao();
            Salvar(false);
            Session.Abandon();
            Response.Redirect("ContinuarDepois.aspx");
        }

        protected void btnSalvarEncerrar_Click(object sender, EventArgs e)
        {
            SalvarRespostasNaSecao();
            Salvar(true);
            Session.Abandon();
            ServExportadorAvaliacaoCSV servExportadorAvaliacaoCSV = new ServExportadorAvaliacaoCSV(ConfigurationManager.AppSettings["CaminhoExportacaoCSV"]);
            servExportadorAvaliacaoCSV.Execute(_avaliacaAluno);
            Response.Redirect("Agradecimento.aspx");
        }
    }
}
