using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class Professor : EntidadeBase
    {
        public virtual String Matricula { get; set; }
        public virtual String Nome { get; set; }
    }
}
