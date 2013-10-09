using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class AvaliacaoAluno : EntidadeBase
    {
        public virtual Aluno Aluno { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
        public virtual IList<RespostaQuestao> RespostasQuestoes { get; set; }
        private void CriarObjetos()
        {
            Avaliacao = new Avaliacao();
            RespostasQuestoes = new List<RespostaQuestao>();
        }
        public AvaliacaoAluno()
        {
            Aluno = new Aluno();
            CriarObjetos();
        }
        public AvaliacaoAluno(Aluno pAluno)
        {
            Aluno = pAluno;
            CriarObjetos();
        }
    }
}
