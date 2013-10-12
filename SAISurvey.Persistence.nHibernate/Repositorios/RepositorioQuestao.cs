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
    public class RepositorioQuestao : RepositorioGenerico<Questao>, IRepositorioQuestao
    {
        public IList<Questao> ObterPorDescricao(string pDescricao)
        {
            IQueryOver<Questao> queryOver = Session.QueryOver<Questao>().
                WhereRestrictionOn(c => c.Descricao)
                .IsLike("%" + pDescricao + "%")
                .OrderBy(c => c.Descricao).Asc;
            return queryOver.List<Questao>();
        }
    }
}
