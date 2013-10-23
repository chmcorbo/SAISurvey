using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExAvaliacaoSemObjetivo : Exception
    {
        public ExAvaliacaoSemObjetivo() : base("Avaliação sem objetivo.") { }
    }
}
