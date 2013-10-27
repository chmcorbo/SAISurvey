using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Persistence.nHibernate.Repositorios;


namespace SAISurvey.Persistence.nHibernate.Servicos
{
    public class ServValidadorConsistenciaAvaliacao : IServValidadorConsistenciaAvaliacao
    {
        public bool Execute(Avaliacao pAvaliacao)
        {
            Boolean erro = true;

            if (String.IsNullOrEmpty(pAvaliacao.Objetivo))
                throw new ExAvaliacaoSemObjetivo();

            if (pAvaliacao.Data_Inicio == null ||
                pAvaliacao.Data_Fim == null ||
                pAvaliacao.Data_Fim < pAvaliacao.Data_Inicio)
                throw new ExAvaliacaoPeriodoInvalido();

            if (pAvaliacao.Turma == null)
                throw new ExAvaliacaoSemTurma();

            if (pAvaliacao.Questoes == null || pAvaliacao.Questoes.Count() == 0)
                throw new ExAvaliacaoSemQuestoes();

            erro = false;

            return !erro;
        }
    }
}
