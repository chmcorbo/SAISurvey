using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExAvaliacaoAlunoNaoEstaFechada : Exception
    {
        public ExAvaliacaoAlunoNaoEstaFechada() : base("Avaliação de aluno ainda não está fechada") { }
    }
}
