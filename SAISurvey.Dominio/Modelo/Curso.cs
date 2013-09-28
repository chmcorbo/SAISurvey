using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Excecoes;

namespace SAISurvey.Dominio.Modelo
{
    public class Curso : FormatoCursoPadrao
    {
        private IList<Bloco> _blocos;

        public virtual IList<Bloco> Blocos
        {
            get { return _blocos; }
            protected set { _blocos = value; }
        }
        
        public Curso()
        {
            _blocos = new List<Bloco>();
        }

        public virtual Bloco AdicionarBloco(String pDescricao)
        {
            // Implementar teste unitário
            Bloco bloco = new Bloco(this) { Descricao = pDescricao };
            _blocos.Add(bloco);
            return bloco;
        }

        public virtual void AdicionarBloco(Bloco pBloco)
        {
            if (pBloco.Curso != this)
            {
                throw new ExBlocoNaoRefereciadoNoCurso("O módulo inserido não tem referência do blobo em questão");
            }
            _blocos.Add(pBloco);
        }

        public virtual void ExcluirBloco(String pDescricao)
        {
            // Implementar teste unitário
            Bloco bloco = _blocos.Where(m => m.Descricao == pDescricao).FirstOrDefault();
            if (bloco != null)
                _blocos.Remove(bloco);
        }

    }
}
