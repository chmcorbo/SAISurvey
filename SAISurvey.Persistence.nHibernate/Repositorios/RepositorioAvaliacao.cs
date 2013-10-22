using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Dominio.Repositorios;


namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioAvaliacao :  RepositorioGenerico<Avaliacao>, IRepositorioAvaliacao
    {
        private Boolean VerificaConsistencia(Avaliacao pAvaliacao)
        {
            Boolean erro = true;

            if (String.IsNullOrEmpty(pAvaliacao.Objetivo))
                throw new ExAvaliacaoSemObjetivo("Avaliação sem objetivo");

            if (pAvaliacao.Data_Inicio==null || 
                pAvaliacao.Data_Fim==null || 
                pAvaliacao.Data_Fim<pAvaliacao.Data_Inicio)
                throw new ExAvaliacaoPeriodoInvalido("Periodo de avaliação inválido");

            if (pAvaliacao.Turma == null)
                throw new ExAvaliacaoSemTurma("Avaliação sem turma");

            if (pAvaliacao.Questoes == null || pAvaliacao.Questoes.Count() == 0)
                throw new ExAvaliacaoSemQuestoes("Avaliação sem questões");

            erro = false;

            return !erro;
        }

        public virtual IList<Avaliacao> ListarPorPeriodo(DateTime pDataInicial, DateTime pDataFinal)
        {
            IQueryOver<Avaliacao> queryOver = Session.QueryOver<Avaliacao>()
                .Where(a => a.Data_Inicio >= pDataInicial && a.Data_Inicio <= pDataFinal);
            return queryOver.List<Avaliacao>();
        }

        public override void Adicionar(Avaliacao pEntidadeBase)
        {
            if (VerificaConsistencia(pEntidadeBase))
                base.Adicionar(pEntidadeBase);
        }

        public override void Atualizar(Avaliacao pEntidadeBase)
        {
            if (VerificaConsistencia(pEntidadeBase))
                base.Atualizar(pEntidadeBase);
        }


        public IList<Avaliacao> ListarSemConvite(DateTime pDataReferencia)
        {
            IQueryOver<Avaliacao> queryOver = Session.QueryOver<Avaliacao>()
                .Where(a => pDataReferencia >= a.Data_Inicio && pDataReferencia <= a.Data_Fim && a.ConviteEnviado == "N");
            return queryOver.List<Avaliacao>();
        }
    }
}
