using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class Resposta : EntidadeBase
    {
        public virtual String Descricao { get; set; }
        public virtual Int16 Ordem { get; set; }
    }
}
