using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Excecoes;

namespace SAISurvey.Dominio.Modelo
{
    public class Bloco : EntidadeBase
    {
        private IList<Modulo> _modulos;

        public virtual String Descricao { get; set; }
        public virtual Curso Curso { get; set; }

        private void CriarObjetos()
        {
            Curso = new Curso();
            _modulos = new List<Modulo>();
        }

        public Bloco()
        {
            CriarObjetos();
        }

        public Bloco(Curso pCurso)
        {
            CriarObjetos();
            this.Curso = pCurso;
        }

        public virtual IList<Modulo> Modulos
        {
            get { return _modulos; }
            protected set { _modulos = value; }
        }

        public virtual Modulo AdicionarModulo(String pDescricao)
        {
            // Implementar teste unitário
            Modulo modulo =new Modulo(this){Descricao=pDescricao};
            _modulos.Add(modulo);
            return modulo;
        }

        public virtual void AdicionarModulo(Modulo pModulo)
        {
            if (pModulo.Bloco != pModulo.Bloco)
            {
                throw new ExBlocoInexistentenoCurso("O módulo inserido não tem referência do blobo em questão");
            }
            _modulos.Add(pModulo);
        }

        public virtual void ExcluirModulo(String pDescricao)
        {
            // Implementar teste unitário
            Modulo modulo = _modulos.Where(m => m.Descricao == pDescricao).FirstOrDefault();
            if (modulo != null)
                _modulos.Remove(modulo);
        }
    }
}
