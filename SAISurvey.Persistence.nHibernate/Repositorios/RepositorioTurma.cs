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
    public class RepositorioTurma : RepositorioGenerico<Turma>, IRepositorioTurma
    {
        public RepositorioTurma(ConectionManager pConexao)
            : base(pConexao)
        {

        }

        public IList<Turma> ListarPorModulo(String pID_Modulo)
        {
            IQueryOver<Turma> queryOver = Session.QueryOver<Turma>()
                .Where(t => t.Modulo.ID==pID_Modulo);
            return queryOver.List<Turma>();
        }
    }
}
