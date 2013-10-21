using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Excecoes;

namespace SAISurvey.Dominio.Modelo
{
    [Serializable]
    public class Bloco : EntidadeBase
    {
        public virtual Curso Curso { get; set; }
        public virtual String Descricao { get; set; }
        public virtual IList<Modulo> Modulos { get; set; }

        public Bloco()
        {
            Modulos = new List<Modulo>();
        }

        public Bloco(Curso pCurso)
        {
            this.Curso = pCurso;
            Modulos = new List<Modulo>();
        }

        public virtual Bloco AdicionarModulo(String pDescricao)
        {
            // Implementar teste unitário
            Modulo modulo = new Modulo(this) { Descricao = pDescricao };
            Modulos.Add(modulo);
            return this;
        }

        public virtual void AdicionarModulo(Modulo pModulo)
        {
            if (pModulo.Bloco != this)
            {
                throw new ExBlocoNaoRefereciadoNoCurso("O módulo inserido não tem referência do bloco em questão");
            }
            Modulos.Add(pModulo);
        }

        public virtual void ExcluirModulo(String pDescricao)
        {
            // Implementar teste unitário
            Modulo modulo = Modulos.Where(m => m.Descricao == pDescricao).FirstOrDefault();
            if (modulo != null)
                Modulos.Remove(modulo);
        }


    }
}
