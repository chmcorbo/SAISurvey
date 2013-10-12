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
    public class RepositorioResposta : RepositorioGenerico<Resposta>, IRepositorioResposta
    {
        public IList<Resposta> ObterPorDescricao(String pDescricao)
        {
            IQueryOver<Resposta> queryOver = Session.QueryOver<Resposta>().
                WhereRestrictionOn(c => c.Descricao)
                .IsLike("%" + pDescricao + "%")
                .OrderBy(c => c.Descricao).Asc;
            return queryOver.List<Resposta>();
        }
    }
}
