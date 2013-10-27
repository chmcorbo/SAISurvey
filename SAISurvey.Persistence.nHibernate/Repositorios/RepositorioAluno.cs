using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;


namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioAluno : RepositorioGenerico<Aluno>, IRepositorioAluno
    {
        public RepositorioAluno(ConectionManager pConexao) : base(pConexao)
        {

        }

        public Aluno ObterPorMatricula(string pMatricula)
        {
            IQueryOver<Aluno> queryOver = Session.QueryOver<Aluno>()
                .Where(a => a.Matricula == pMatricula);
            return queryOver.List<Aluno>().FirstOrDefault();
        }

        public IList<Aluno> ObterPorNome(string pNome)
        {
            IQueryOver<Aluno> queryOver = Session.QueryOver<Aluno>()
                .WhereRestrictionOn(a => a.Nome)
                .IsLike(pNome + "%")
                .OrderBy(a => a.Nome).Asc;
            return queryOver.List<Aluno>();
        }
    }
}
