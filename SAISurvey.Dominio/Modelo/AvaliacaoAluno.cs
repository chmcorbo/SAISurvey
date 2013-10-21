using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Excecoes;

namespace SAISurvey.Dominio.Modelo
{
    public class AvaliacaoAluno : EntidadeBase
    {
        public virtual Aluno Aluno { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
        public virtual IList<RespostaQuestao> RespostasQuestoes { get; set; }
        public virtual String Fechada { get; set; }
        private void CriarObjetos()
        {
            Fechada = "N";
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

        public virtual AvaliacaoAluno AdicionarRespostaQuestao(Questao pQuestao, Resposta pResposta)
        {
            RespostaQuestao respostaQuestao;
            respostaQuestao = RespostasQuestoes.Where(q => q.Questao.ID == pQuestao.ID).FirstOrDefault();
            if (respostaQuestao != null)
                RespostasQuestoes.Remove(respostaQuestao);
            respostaQuestao = new RespostaQuestao() { AvaliacaoAluno = this, Questao = pQuestao, Resposta = pResposta };
            RespostasQuestoes.Add(respostaQuestao);
            return this;
        }
    }
}
