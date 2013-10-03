using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Excecoes;

namespace SAISurvey.Dominio.Modelo
{
    public class Bloco : EntidadeBase
    {
        public virtual Curso Curso { get; set; }
        public virtual String Descricao { get; set; }

        public Bloco()
        {
            Curso = new Curso();
        }

        public Bloco(Curso pCurso)
        {
            this.Curso = pCurso;
        }
    }
}
