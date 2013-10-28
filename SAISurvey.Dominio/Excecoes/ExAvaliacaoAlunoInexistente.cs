using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExAvaliacaoAlunoInexistente : Exception
    {
        public ExAvaliacaoAlunoInexistente() : base("Avaliação de aluno inexistente.") { }
    }
}
