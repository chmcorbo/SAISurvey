using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using NHibernate;

namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioProfessor : RepositorioGenerico<Professor>, IRepositorioProfessor
    {
        public Professor ObterPorMatricula(string pMatricula)
        {
            IQueryOver<Professor> queryOver = Session.QueryOver<Professor>()
                .Where(p => p.Matricula == pMatricula);
            return queryOver.List<Professor>().FirstOrDefault();
        }

        public IList<Professor> ObterPorNome(string pNome)
        {
            IQueryOver<Professor> queryOver = Session.QueryOver<Professor>()
                .WhereRestrictionOn(a => a.Nome)
                .IsLike(pNome + "%")
                .OrderBy(a => a.Nome).Asc;
            return queryOver.List<Professor>();
        }
    }
}
