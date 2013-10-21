using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Excecoes;

namespace SAISurvey.Dominio.Modelo
{
    [Serializable]
    public class Curso : EntidadeBase
    {

        public virtual String Descricao { get; set; }
        public virtual IList<Bloco> Blocos { get; set; }
        
        public Curso()
        {
            Blocos = new List<Bloco>();
        }

        public virtual Bloco AdicionarBloco(String pDescricao)
        {
            // Implementar teste unitário
            Bloco bloco = new Bloco(this) { Descricao = pDescricao };
            Blocos.Add(bloco);
            return bloco;
        }

        public virtual void AdicionarBloco(Bloco pBloco)
        {
            if (pBloco.Curso != this)
            {
                throw new ExBlocoNaoRefereciadoNoCurso("O bloco inserido não tem referência do curso em questão");
            }
            Blocos.Add(pBloco);
        }

        public virtual void ExcluirBloco(String pDescricao)
        {
            // Implementar teste unitário
            Bloco bloco = Blocos.Where(m => m.Descricao == pDescricao).FirstOrDefault();
            if (bloco != null)
                Blocos.Remove(bloco);
        }

    }
}
