using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;
using NHibernate;

namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioCurso: RepositorioGenerico<Curso>, IRepositorioCurso
    {
        public IList<Curso> ObterPorDescricao(string pDescricaoCurso)
        {
            IQueryOver<Curso> queryOver = Session.QueryOver<Curso>().
                WhereRestrictionOn(c => c.Descricao).
                IsLike("%" + pDescricaoCurso + "%").
                OrderBy(c => c.Descricao).Asc;
            return queryOver.List<Curso>();
        }
        
        public IList<Modulo> ObterModulosPorDescricao(string pDescricaoModulo)
        {
            IQueryOver<Modulo> queryOver = Session.QueryOver<Modulo>()
                .WhereRestrictionOn(c => c.Descricao)
                .IsLike("%" + pDescricaoModulo + "%");
            return queryOver.List<Modulo>();
        }

        public Curso ObterCursoPorIDModulo(String pID_Modulo)
        {
            IQueryOver<Modulo> queryOver = Session.QueryOver<Modulo>()
                .Where(m => m.ID == pID_Modulo);

            Modulo modulo = queryOver.List().FirstOrDefault();

            return modulo.Bloco.Curso;
        }
    }
}
