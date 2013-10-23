using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExAvaliacaoPeriodoInvalido : Exception
    {
        public ExAvaliacaoPeriodoInvalido() : base("Avaliação com período inválido.") { }
    }
}
