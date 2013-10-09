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
        public IList<Curso> ObterPorDescricao(string pDescricao)
        {
            IQueryOver<Curso> queryOver = Session.QueryOver<Curso>().
                WhereRestrictionOn(c => c.Descricao).
                IsLike("%" + pDescricao + "%").
                OrderBy(c => c.Descricao).Asc;
            return queryOver.List<Curso>();
        }
        
        public IList<Bloco> ObterBlocos(string pDescricaoBloco)
        {
            IQueryOver<Bloco> queryOver = Session.QueryOver<Bloco>().
                WhereRestrictionOn(c => c.Descricao).
                IsLike("%" + pDescricaoBloco + "%").
                OrderBy(c => c.Descricao).Asc;
            return queryOver.List<Bloco>();
        }
    }
}
