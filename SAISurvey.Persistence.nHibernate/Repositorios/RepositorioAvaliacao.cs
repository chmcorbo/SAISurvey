using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;


namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioAvaliacao :  RepositorioGenerico<Avaliacao>, IRepositorioAvaliacao
    {
        public IList<Avaliacao> ListarPorPeriodo(DateTime pDataInicial, DateTime pDataFinal)
        {
            IQueryOver<Avaliacao> queryOver = Session.QueryOver<Avaliacao>()
                .Where(a => a.Data_Inicio >= pDataInicial && a.Data_Inicio <= pDataFinal);
            return queryOver.List<Avaliacao>();
        }
    }
}
