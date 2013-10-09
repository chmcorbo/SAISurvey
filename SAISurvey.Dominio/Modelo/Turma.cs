using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class Turma : EntidadeBase
    {
        public virtual String Descricao { get; set; }
        public virtual String Sala { get; set; }
        public virtual DateTime? Data_Inicio { get; set; }
        public virtual DateTime? Data_Fim { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual IList<Aluno> Alunos { get; set; }
        public Turma()
        {
            Professor = new Professor();
            Alunos = new List<Aluno>();
            //Modulo = new Modulo();
        }
    }
}
