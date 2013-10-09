using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class Avaliacao : EntidadeBase
    {
        public virtual String Objetivo { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual List<Questao> Questoes { get; set; }
        public virtual DateTime? Data_Inicio { get; set; }
        public virtual DateTime? Data_Fim { get; set; }
        public Avaliacao()
        {
            Turma = new Turma();
            Questoes = new List<Questao>();
        }
 


    }
}
