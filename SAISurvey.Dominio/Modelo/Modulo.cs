using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class Modulo : EntidadeBase
    {
        public virtual Bloco Bloco { get; set; }
        public virtual String Descricao { get; set; }
        public virtual String Sala { get; set; }
        public virtual DateTime Data_Inicio { get; set; }
        public virtual DateTime Data_Fim { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual List<Aluno> Alunos { get; set; }


        public Modulo()
        {
            
        }

        public Modulo(Bloco pBloco)
        {
            Bloco = pBloco;
        }

    }
}
