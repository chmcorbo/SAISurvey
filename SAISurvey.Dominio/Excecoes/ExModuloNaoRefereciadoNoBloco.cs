using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExBlocoNaoRefereciadoNoCurso:  Exception
    {
        public ExBlocoNaoRefereciadoNoCurso() : base("Bloco não referenciado no curso em questão.") { }
    }
}
