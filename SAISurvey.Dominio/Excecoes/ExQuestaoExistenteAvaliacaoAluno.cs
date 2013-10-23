using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExQuestaoExistenteAvaliacaoAluno : Exception
    {
        public ExQuestaoExistenteAvaliacaoAluno() : base("Questão inexistente na avaliação do aluno") { }
    }
}
