using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioAvaliacao :  RepositorioGenerico<Avaliacao>, IRepositorioAvaliacao
    {

        public RepositorioAvaliacao(ConectionManager pConexao) : base(pConexao)
        {

        }

        public virtual IList<Avaliacao> ListarPorPeriodo(DateTime pDataInicial, DateTime pDataFinal)
        {
            IQueryOver<Avaliacao> queryOver = Session.QueryOver<Avaliacao>()
                .Where(a => a.Data_Inicio >= pDataInicial && a.Data_Inicio <= pDataFinal);
            return queryOver.List<Avaliacao>();
        }

        public IList<Avaliacao> ListarSemConvite(DateTime pDataReferencia)
        {
            IQueryOver<Avaliacao> queryOver = Session.QueryOver<Avaliacao>()
                .Where(a => pDataReferencia >= a.Data_Inicio && pDataReferencia <= a.Data_Fim && a.ConviteEnviado == "N");
            return queryOver.List<Avaliacao>();
        }


        public override void Adicionar(Avaliacao pEntidadeBase)
        {
            IServValidadorConsistenciaAvaliacao servValidadorConsistenciaAvaliacao = new ServValidadorConsistenciaAvaliacao();
            if (servValidadorConsistenciaAvaliacao.Execute(pEntidadeBase))
                base.Adicionar(pEntidadeBase);
        }

        public override void Atualizar(Avaliacao pEntidadeBase)
        {
            IServValidadorConsistenciaAvaliacao servValidadorConsistenciaAvaliacao = new ServValidadorConsistenciaAvaliacao();
            if (servValidadorConsistenciaAvaliacao.Execute(pEntidadeBase))
                base.Atualizar(pEntidadeBase);
        }

    }
}
