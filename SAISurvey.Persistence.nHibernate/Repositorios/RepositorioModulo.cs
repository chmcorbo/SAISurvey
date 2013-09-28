using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SAISurvey.Dominio;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;


namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioModulo : RepositorioGenerico<Modulo>, IRepositorioModulo
    {
        public IList<Modulo> ObterPorDescricao(string pDescricao)
        {
            IQueryOver<Modulo> queryOver = Session.QueryOver<Modulo>().Where(t => t.Descricao == pDescricao);
            return queryOver.List<Modulo>().ToList();
        }
    }
}
