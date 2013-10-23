using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExAvaliacaoSemQuestoes : Exception
    {
        public ExAvaliacaoSemQuestoes() : base("Avaliação sem nenhuma questão informada.") { }
    }
}
