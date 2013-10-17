using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class RespostaQuestao : EntidadeBase
    {
        public virtual AvaliacaoAluno AvaliacaoAluno { get; set; }
        public virtual Questao Questao { get; set; }
        public virtual Resposta Resposta { get; set; }
        public RespostaQuestao()
        {
            AvaliacaoAluno = new AvaliacaoAluno();
            Questao = new Questao();
            Resposta = new Resposta();
        }
    }
}
