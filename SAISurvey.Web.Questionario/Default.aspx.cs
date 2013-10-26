using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Web.Questionario
{
    public partial class _Default : System.Web.UI.Page
    {
        private String _id = String.Empty;
        private AvaliacaoAluno _avaliacaAluno;
        private RepositorioGenerico<AvaliacaoAluno> _repAvaliacaoAluno;
        private ConectionManager _conectionManager;
        private List<Resposta> _lstRespostas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    //_lstRespostas = RepositorioGenerico<Resposta>.
                    _id = Request.QueryString["ID"];
                    _conectionManager = new ConectionManager();
                    _repAvaliacaoAluno = new RepositorioGenerico<AvaliacaoAluno>(_conectionManager);
                    _avaliacaAluno = _repAvaliacaoAluno.ObterPorID(_id);
                    Session["avaliacaoAluno"] = _avaliacaAluno;
                    BindToUI(_avaliacaAluno);
                }
                else
                    Session.Remove("avaliacaoAluno");
            }
        }

        public void BindToUI(AvaliacaoAluno pObjeto)
        {
            lbCurso.Text=pObjeto.Avaliacao.Turma.Modulo.Bloco.Curso.Descricao;
            lbModulo.Text=pObjeto.Avaliacao.Turma.Modulo.Descricao;
            lbTurma.Text=pObjeto.Avaliacao.Turma.Descricao;
            lbAluno.Text=pObjeto.Aluno.Nome;
            lbProfessor.Text = pObjeto.Avaliacao.Turma.Professor.Nome;
        }
        public List<RespostaQuestao> ListarQuestoes()
        {
            if (Session["avaliacaoAluno"] != null)
            {
                return ((AvaliacaoAluno)Session["avaliacaoAluno"]).RespostasQuestoes.ToList();
            }
            else
                return null;
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
            _avaliacaAluno = Session["avaliacaoAluno"] as AvaliacaoAluno;

            
            foreach (GridViewRow oldrow in GridView1.Rows)
            {
                
               /* ((RadioButton)oldrow.FindControl("rbResposta1")).Checked = _avaliacaAluno.RespostasQuestoes.Where(r => r.ID==oldrow.Cells[0]);
                ((RadioButton)oldrow.FindControl("rbResposta2")).Checked = false;
                ((RadioButton)oldrow.FindControl("rbResposta3")).Checked = false;
                ((RadioButton)oldrow.FindControl("rbResposta4")).Checked = false;
                ((RadioButton)oldrow.FindControl("rbResposta5")).Checked = false;
                ((RadioButton)oldrow.FindControl("rbResposta6")).Checked = false;
                */
            }
            

            //Set the new selected row
            /*RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("rbResposta1")).Checked = true;*/


        }
    }
}
