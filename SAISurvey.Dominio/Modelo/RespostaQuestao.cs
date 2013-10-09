using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class RespostaQuestao : EntidadeBase
    {
        public virtual Avaliacao Avaliacao { get; set; }
        public virtual Questao Questao { get; set; }
        public virtual Resposta Resposta { get; set; }
        public RespostaQuestao()
        {
            Avaliacao = new Avaliacao();
            Questao = new Questao();
            Resposta = new Resposta();
        }
    }
}
