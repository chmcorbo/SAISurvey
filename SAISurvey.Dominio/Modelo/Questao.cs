using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio;

namespace SAISurvey.Dominio.Modelo
{
    public class Questao : EntidadeBase
    {
        public virtual String Descricao { get; set; }
    }
}
